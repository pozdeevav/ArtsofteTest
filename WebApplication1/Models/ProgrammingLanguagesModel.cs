using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProgrammingLanguagesModel
    {
        [Key]
        public int ProgrammingLanguageId { get; set; }

        public string ProgrammingLanguage { get; set; }
    }
}
