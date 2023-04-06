using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("EstadoId")]
        public int EstadoId { get; set; }
        
    }
}
