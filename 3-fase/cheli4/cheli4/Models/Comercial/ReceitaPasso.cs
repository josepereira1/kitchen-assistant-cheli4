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
    [Table("ReceitaPasso")]
    public class ReceitaPasso
    {
        [Key]
        public int FK_id_receita { set; get; }

        [Key]
        public int FK_id_passo { set; get; }

        [Required]
        public int ordem { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Receita receita { set; get; }

        [NotMapped]
        [JsonIgnore]
        public Passo passo { set; get; }
    }
}
