using CodeTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.DBContext
{
    public class CodeTestDbContext:DbContext
    {
        IConfiguration configuration;
        public CodeTestDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionStringCodeTest"));
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
