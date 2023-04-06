using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("UF")]
        [MaxLength(2)]
        public string UF { get; set; }
    }
}
