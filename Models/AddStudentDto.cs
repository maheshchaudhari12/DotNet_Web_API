using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Web_API.Models
{
    public class AddStudentDto
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
    }
}