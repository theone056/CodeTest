using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class Student
    {
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public float GPA { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ClassName { get; set; }
    }
}
