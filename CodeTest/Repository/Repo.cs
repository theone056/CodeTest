using CodeTest.DBContext;
using CodeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Repository
{
    public class Repo : IRepo
    {
        public async Task<int> AddClass(Classes classes)
        {
            if (classes == null) throw new Exception("null");
            using (var ctx = new CodeTestDbContext())
            {
                var classcount = ctx.Classes.Where(c => c.ClassName == classes.ClassName);
                if (classcount.Count() > 0) throw new Exception("Duplicate Class");
                await ctx.Classes.AddAsync(classes);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<int> AddStudent(Student student)
        {
            if (student == null) throw new Exception("null");
           
            using(var ctx = new CodeTestDbContext())
            {
                if (ctx.Classes.Find(student.ClassName) == null) throw new Exception("Class not available");
                var duplicate = ctx.Students.Where(c => c.LastName == student.LastName && c.ClassName == student.ClassName);
                if (duplicate.Count() > 0) throw new Exception("Duplicate Student");
                await ctx.Students.AddAsync(student);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Classes>> GetClasses()
        {
            using(var ctx = new CodeTestDbContext())
            {
                var ClassList = await ctx.Classes.ToListAsync();
                if (ClassList.Count == 0) throw new Exception("No Data Found");
                return ClassList;
            }
        }

        public async Task<List<Student>> GetStudents(string className)
        {
            if (String.IsNullOrEmpty(className)) throw new Exception();
            using(var ctx = new CodeTestDbContext())
            {
                var StudentList = await ctx.Students.Where(c => c.ClassName == className).ToListAsync();
                if (StudentList.Count == 0) throw new Exception("No Student Found");
                return StudentList;
            }
        }
    }
}
