using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.RecursosHumanos
{
    [Table("Codigo")]
    public class Codigo
    {
        [Key]
        public string codigo { set; get; }

        [Required]
        public string FK_username_cliente { set; get; }

        [NotMapped]
        [JsonIgnore]
        public virtual Cliente cliente { set; get; }
     }
}

