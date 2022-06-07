using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.DBContext
{
    public class CodeTestDbContext:DbContext
    {
        public CodeTestDbContext(DbContextOptions<CodeTestDbContext> options) : base(options)
        {

        }
    }
}
