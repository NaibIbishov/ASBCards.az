using DataAccess.Entity;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
	public class AppDbContext:DbContext
	{

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderCard> OrderCards { get; set; }
       
       

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID=1,
                    Name="Admin",
                    Create=DateTime.Now,
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    ID =2,
                    Name="User",
                    Create=DateTime.Now,
                });

            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID=1,
                    ImageURL="user.png",
                    UserName="naib.ibishov",
                    Email="naib.ibishov@asb.az",
                    Salt=salt,
                    Password= "20012008Nq!",
                    PasswordHash =Crypto.GenerateSHA256Hash("20012008Nq!", salt),
                    RoleId=1,
                    Create=DateTime.Now,
                });;
        }

    }
}
