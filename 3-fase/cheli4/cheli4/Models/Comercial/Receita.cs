using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cheli4.Models
{
    [Table("Receita")]
    public class Receita 
    {
        [Key]
        public int id { set; get; }

        public virtual ICollection<ClienteReceita> clientes { set; get; }
        public virtual ICollection<Agenda> agenda { set; get; }
    }
}
