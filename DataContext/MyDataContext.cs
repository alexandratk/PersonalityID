using Microsoft.EntityFrameworkCore;

namespace PersonalityIdentification.DataContext
{
    public class MyDataContext : DbContext
    {
        
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<PupilParent> PupilParent { get; set; }
        public DbSet<MovingPupil> MovingPupil { get; set; }
        public DbSet<MovingTeacher> MovingTeacher { get; set; }
        public DbSet<MovingEmployee> MovingEmployee { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitution { get; set; }


        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
            Database.Migrate();
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Administrators).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Teachers).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Employees).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Groups).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Devices).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<Device>().HasMany(t => t.MovingPupils).WithOne(p => p.Device);
            modelBuilder.Entity<Pupil>().HasMany(t => t.MovingPupils).WithOne(p => p.Pupil);
            modelBuilder.Entity<Device>().HasMany(t => t.MovingTeachers).WithOne(p => p.Device);
            modelBuilder.Entity<Teacher>().HasMany(t => t.MovingTeachers).WithOne(p => p.Teacher);
            modelBuilder.Entity<Device>().HasMany(t => t.MovingEmployees).WithOne(p => p.Device);
            modelBuilder.Entity<Employee>().HasMany(t => t.MovingEmployees).WithOne(p => p.Employee);
            modelBuilder.Entity<Pupil>().HasMany(t => t.PupilParents).WithOne(p => p.Pupil);
            modelBuilder.Entity<Parent>().HasMany(t => t.PupilParents).WithOne(p => p.Parent);
            modelBuilder.Entity<Group>().HasMany(t => t.Pupils).WithMany(p => p.Groups);

            modelBuilder.Entity<Teacher>().Property(r => r.Role).HasDefaultValue("Teacher");
            modelBuilder.Entity<Pupil>().Property(r => r.Role).HasDefaultValue("Pupil");
            modelBuilder.Entity<Parent>().Property(r => r.Role).HasDefaultValue("Parent");
            modelBuilder.Entity<Employee>().Property(r => r.Role).HasDefaultValue("Employee");
            modelBuilder.Entity<Administrator>().Property(r => r.Role).HasDefaultValue("Administrator");
        }
    }
}