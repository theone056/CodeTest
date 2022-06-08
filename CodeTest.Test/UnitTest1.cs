using CodeTest.Models;
using CodeTest.Repository;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CodeTest.Test
{
    public class Tests
    {

        [Test]
        public void AddStudentClassNotAvailable()
        {
            IRepo repo = new Repo();
            Student student = new Student()
            {
                FirstName = "Derick",
                LastName = "Colon",
                Age = 25,
                GPA = 3.5,
                ClassName = "Science"
            };

            var result = Assert.ThrowsAsync<Exception>(()=> repo.AddStudent(student));
            Assert.That(result.Message, Is.EqualTo("Class not available"));
        }
        [Test]
        public async Task GetClass()
        {
            IRepo repo = new Repo();
            var list = await repo.GetClasses();

            Assert.AreEqual(1, list.Count);
        }
        [Test]
        public async Task GetStudent()
        {
            IRepo repo = new Repo();
            var list = await repo.GetStudents("Biology");
            Assert.AreEqual(1, list.Count);
        }
        [Test]
        public async Task AddStudent()
        {
            IRepo repo = new Repo();
            Student student = new Student()
            {
                FirstName = "Derick",
                LastName = "Colon",
                Age = 25,
                GPA = 3.5,
                ClassName = "Biology"
            };

            var result = Assert.ThrowsAsync<Exception>(()=>repo.AddStudent(student));
            Assert.That(result.Message, Is.EqualTo("Duplicate Student"));
        }
        //[Test]
        public void AddDuplicate()
        {
            IRepo repo = new Repo();
            Classes classes = new Classes()
            {
                ClassName = "Biology",
                Location = "Room 1",
                TeacherName = "Derick"
            };

            var result = Assert.ThrowsAsync<Exception>(() => repo.AddClass(classes));
            Assert.That(result.Message, Is.EqualTo("Duplicate Class"));
        }


      //  [Test]
        public async Task AddClass()
        {
            IRepo repo = new Repo();
            Classes classes = new Classes()
            {
                ClassName = "Biology",
                Location = "Room 1",
                TeacherName = "Derick"
            };

            var result = await repo.AddClass(classes);
            Assert.AreEqual(1,result);
        }

  
    }

}