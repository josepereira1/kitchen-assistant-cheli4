using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models
{
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        public int id_pergunta { get; set; }

        [Required]
        public string pergunta { get; set; }
    }
}
