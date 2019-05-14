using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models
{
    [Table("Resposta")]
    public class Resposta
    {
        [Key]
        [StringLength(45)]
        public string FK_username_cliente { get; set; }

        [Key]
        public int FK_id_receita { set; get; }

        [Key]
        [Column(TypeName = "datetime")]
        public DateTime data { get; set; }

        [Required]
        public int FK_id_pergunta { get; set; }

        [Required]
        public string resposta { get; set; }
    }
}
