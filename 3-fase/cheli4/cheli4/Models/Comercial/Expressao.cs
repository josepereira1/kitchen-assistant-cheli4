using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    [Table("Expressao")]
    public class Expressao
    {
        [Key]
        public string expressao { set; get; }

        [Required]
        public int FK_id_passo { set; get; }

        [Required]
        public string descricao { set; get; }

        [NotMapped]
        [JsonIgnore]
        public virtual Passo passo { set; get; }
    }
}
