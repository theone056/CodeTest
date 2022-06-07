using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class Classes
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string ClassName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Location { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string TeacherName { get; set; }
    }
}
