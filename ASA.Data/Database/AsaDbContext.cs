using ASA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASA.Data.Database
{
    public class AsaDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AsaDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=.;database=AsaDb;trusted_connection=true;");
        }

        public DbSet<FileDetails> FileDetails { get; set; }
    }
}
