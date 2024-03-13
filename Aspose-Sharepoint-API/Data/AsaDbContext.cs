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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<FileDetails> FileDetails { get; set; }
    }
}
