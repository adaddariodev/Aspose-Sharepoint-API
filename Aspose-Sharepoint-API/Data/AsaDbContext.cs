using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class AsaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AsaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //entities
        public DbSet<FileDatabaseModel> FileDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }       
    }
}
