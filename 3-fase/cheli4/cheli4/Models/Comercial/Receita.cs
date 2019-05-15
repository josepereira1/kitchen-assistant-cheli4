using cheli4.Models.RecursosHumanos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    [Table("Receita")]
    public class Receita
    {
        [Key]
        public int id { set;get; }

        [Required]
        [StringLength(50)]
        public string nome { set; get; }

        [Required]
        [StringLength(50)]
        public string tipo { set; get; }

        [Required]
        public int duracao { set; get; }

        [Required]
        public string gastronomia { set; get; }

        [Required]
        public int disponivel { set; get; }

        public virtual ICollection<ClienteReceita> clientes { set; get; }
        public virtual ICollection<Agenda> agenda { set; get; }
    }
}
