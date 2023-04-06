using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.Models
{
    [Table("PrevisaoClima")]
    public class PrevisaoClima
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("CidadeId")]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [Required]
        [Column("DataPrevisao")]
        public DateTime DataPrevisao { get; set; }

        [Required]
        [Column("Clima")]
        [MaxLength(15)]
        public string Clima { get; set; }

        [Column("TemperaturaMinima")]
        public decimal TemperaturaMinima { get; set; }

        [Column("TemperaturaMaxima")]
        public decimal TemperaturaMaxima { get; set; }
    }
}
