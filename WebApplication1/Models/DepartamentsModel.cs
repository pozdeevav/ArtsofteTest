using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DepartamentsModel
    {
        [Key]
        public int DepartamentId { get; set; }

        public string DepartamentName { get; set; }

        public string Floor { get; set; }
    }
}
