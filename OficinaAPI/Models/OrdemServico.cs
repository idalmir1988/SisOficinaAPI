using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Models
{
    public class OrdemServico
    {
        [Key]
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataFinalizacao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
