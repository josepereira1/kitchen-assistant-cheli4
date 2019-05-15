using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    [Table("Ingrediente")]
    public class Ingrediente
    {
        [Key]
        public int id { set; get; }

        [Required]
        public string nome { set; get; }

        [Required]
        public string tipo { set; get; }

        [Required]
        public int calorias { set; get; }
    }
}
