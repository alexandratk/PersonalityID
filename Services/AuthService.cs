using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using Microsoft.IdentityModel.Tokens;
using PersonalityIdentification.Helpers;
using System.Security.Cryptography;
using System.Text;
using PersonalityID.Helpers;

namespace PersonalityIdentification.Services
{
    public class AuthService : IAuthService
    {
        private readonly MyDataContext database;

        public AuthService(MyDataContext database)
        {
            this.database = database;
        }
        public async Task<AuthResponseModel> AuthUser(AuthRequestModel authRequestModel)
        {
            var user = await GetUserByPassAndMail(database.Pupil, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Teacher, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Administrator, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Parent, authRequestModel);
            if (user == null)
                user = await GetUserByPassAndMail(database.Employee, authRequestModel);

            if (user == null)
                throw new Exception("User not found");
            var token = generateJWTToken(user);
            return new AuthResponseModel()
            {
                Id = user.Id,
                jwtToken = token
            };
        }


        public async Task<User> GetUserByPassAndMail(IQueryable<User> placeToSerach, AuthRequestModel authRequestModel)
        {
            return await placeToSerach.FirstOrDefaultAsync(p => p.Login == authRequestModel.Login && p.Password == HashHelper.ComputeSha256Hash(authRequestModel.Password));
        }

       

        string generateJWTToken(User person)
        {

            var now = DateTime.UtcNow;

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                 issuer: AuthOptions.ISSUER,
                 audience: AuthOptions.AUDIENCE,
                 notBefore: now,
                 claims: claimsIdentity.Claims,
                 expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                 signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

    }
}