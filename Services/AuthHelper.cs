using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalityID.Dtos;
using PersonalityID.Helpers;
using PersonalityID.Interfaces;
using PersonalityIdentification.DataContext;

namespace PersonalityID.Services
{
    public class AuthHelper<Entity, EntityDto> :
        IAuthHelper<Entity, EntityDto> where Entity : User
                                        where EntityDto : UserRegisterDto
    {
        private readonly MyDataContext database;
        private readonly IMapper mapper;

        public AuthHelper(MyDataContext database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public async Task<Entity> AddUserToDB(EntityDto userDto)
        {
            Entity newUser = mapper.Map<Entity>(userDto);
            newUser.Password = HashHelper.ComputeSha256Hash(newUser.Password);

            await database.AddAsync(newUser);
            await database.SaveChangesAsync();

            return newUser;
        }
    }
}