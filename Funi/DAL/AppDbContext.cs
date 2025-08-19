using Funi.Models;
using Microsoft.EntityFrameworkCore;

namespace Funi.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        //Db set 

        public DbSet<HomeHero> Heroes { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<ChooseUs> ChooseUs { get; set; }
        public DbSet<ChooseService> ChooseServices { get; set; }
        public DbSet<Design> Designs { get; set; }


    }
}
