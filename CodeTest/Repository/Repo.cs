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
        private CodeTestDbContext _codeTest;
        public Repo(CodeTestDbContext codeTest)
        {
            _codeTest = codeTest;
        }
        public async Task<int> AddClass(Classes classes)
        {
            if (classes == null) throw new Exception("null");
            using (var ctx = _codeTest)
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
           
            using(var ctx = _codeTest)
            {
                if (ctx.Classes.Find(student.ClassName) == null) throw new Exception("Class not available");
                var duplicate = ctx.Students.Where(c => c.LastName == student.LastName && c.ClassName == student.ClassName);
                if (duplicate.Count() > 0) throw new Exception("Duplicate Student");
                await ctx.Students.AddAsync(student);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<int> EditClass(Classes classes)
        {
            if (classes == null) throw new Exception("null");
            using(var ctx = _codeTest)
            {
                var entity = ctx.Classes.Find(classes.ClassName);
                if (entity == null) throw new Exception("Class not available");
                ctx.Entry(entity).CurrentValues.SetValues(classes);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<int> EditStudent(Student student)
        {
            if (student == null) throw new Exception("null");
            using (var ctx = _codeTest)
            {
                var entity = ctx.Students.Find(student.StudentId);
                if (entity == null) throw new Exception("Student not available");
                ctx.Entry(entity).CurrentValues.SetValues(student);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Classes>> GetClasses()
        {
            using(var ctx = _codeTest)
            {
                var ClassList = await ctx.Classes.ToListAsync();
                if (ClassList.Count == 0) return new List<Classes>();
                return ClassList;
            }
        }

        public async Task<List<Student>> GetStudents(string className)
        {
            if (String.IsNullOrEmpty(className)) throw new Exception();
            using(var ctx = _codeTest)
            {
                var StudentList = await ctx.Students.Where(c => c.ClassName == className).ToListAsync();
                if (StudentList.Count == 0) return new List<Student>();
                return StudentList;
            }
        }

        public async Task<int> RemoveClass(Classes classes)
        {
            if (classes == null) throw new Exception("null");
            using (var ctx = _codeTest)
            {
                var entity = ctx.Classes.Find(classes.ClassName);
                if (entity == null) throw new Exception("Class not available");
                ctx.Classes.Attach(entity);
                ctx.Classes.Remove(entity);
                return await ctx.SaveChangesAsync();
            }
        }

        public async Task<int> RemoveStudent(Student student)
        {
            if (student == null) throw new Exception("null");
            using (var ctx = _codeTest)
            {
                var entity = ctx.Students.Find(student.StudentId);
                if (entity == null) throw new Exception("Class not available");
                ctx.Students.Attach(entity);
                ctx.Students.Remove(entity);
                return await ctx.SaveChangesAsync();
            }
        }
    }
}
