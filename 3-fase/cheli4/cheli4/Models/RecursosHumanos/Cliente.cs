using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cheli4.Models.RecursosHumanos
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [StringLength(45)]
        [Required]
        public string username { set; get; }

        [DataType(DataType.Password)]
        [StringLength(45)]
        [Required]
        public string password { set; get; }

        [StringLength(45)]
        [Required]
        public string nome { set; get; }

        [EmailAddress]
        [StringLength(45)]
        [Required]
        public string email { set; get; }

        [Required]
        public bool apagado { set; get; }

        public double? peso { set; get; }

        [DataType(DataType.Date)]
        [Column(TypeName="datetime")]
        public DateTime? data_nascimento { set; get; }

        public int? idade { set; get; }

        public double? altura { set; get; }

        public virtual ICollection<ClienteReceita> ClienteReceitas { set; get; }
        public virtual ICollection<Agenda> agenda { set; get; }
    }
}
