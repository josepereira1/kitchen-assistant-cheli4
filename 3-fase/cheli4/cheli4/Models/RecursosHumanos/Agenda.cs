using cheli4.Models.Comercial;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.RecursosHumanos
{
    public class Agenda
    {
        [Key]
        [StringLength(45)]
        public string FK_username_cliente { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Cliente cliente { set; get; }

        [Key]
        public int FK_id_receita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita receita { set; get; }

        [Required]
        public int n_realizada { set; get; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime data { get; set; }

    }
}
