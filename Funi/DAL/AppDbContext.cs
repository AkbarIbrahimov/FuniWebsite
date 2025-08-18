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
        


    }
}
