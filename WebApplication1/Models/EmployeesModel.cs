using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{   
    public class EmployeesModel
    {
        [Key]
        public int? EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Age { get; set; }

        public string Departament { get; set; }

        public string ProgrammingLanguageId { get; set; }
    }
}
