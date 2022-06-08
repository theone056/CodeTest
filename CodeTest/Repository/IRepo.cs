using CodeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Repository
{
    public interface IRepo
    {
        Task<int> AddClass(Classes classes);
        Task<int> AddStudent(Student student);

        Task<List<Classes>> GetClasses();

        Task<List<Student>> GetStudents(string className);
    }
}
