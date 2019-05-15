using cheli4.Models.Comercial;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cheli4.Models.RecursosHumanos
{
    [Table("ClienteReceita")]
    public class ClienteReceita
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
        public int ultima_nota { set; get; }
    }
}
