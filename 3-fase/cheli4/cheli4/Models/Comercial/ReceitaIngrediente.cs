
using cheli4.Models.Comercial;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    [Table("ReceitaIngrediente")]
    public class ReceitaIngrediente
    {
        [Key]
        public int FK_id_receita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita receita { set; get; }

        [Key]
        public int FK_id_ingrediente { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Ingrediente ingrediente { set; get; }

        [Required]
        public int quantidade { set; get; }
    }
}
