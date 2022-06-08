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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CODETEST;Trusted_Connection=True;");
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
