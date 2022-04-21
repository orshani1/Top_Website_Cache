using Microsoft.EntityFrameworkCore;
using Statistics.DB.Models;

namespace Statistics.DB
{
    public class ApplicationContext : DbContext
    {
        
        public static readonly string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=WebStats;Trusted_Connection=True;";
        public virtual DbSet<Website> Websites { get; set; }
        public virtual DbSet<WebSystem> Systems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}