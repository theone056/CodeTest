using NUnit.Framework;

namespace CodeTest.Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {

            Classes classes = new Classes()
            {
                ClassName = "Biology",
                Location = "Room 1",
                TeacherName = "Derick"
            };

            Assert.AreEqual(classes, classes);
        }
    }


    public class Classes
    {
        public string ClassName { get; set; }
        public string Location { get; set; }
        public string TeacherName { get; set; }
    }

    public class Students
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public float GPA { get; set; }
        public string ClassName { get; set; }
    }
}