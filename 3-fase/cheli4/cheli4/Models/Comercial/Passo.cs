using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    [Table("Passo")]
    public class Passo
    {
        [Key]
        public int id { set; get; }

        [Required]
        public string descricao { set; get; }

        [Required]
        public int duracao { set; get; }

        [Required]
        public ICollection<Expressao> expressoes { set; get; }

        public virtual ICollection<ReceitaPasso> receitasPassos { set; get; }
    }
}
