using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "O campo {0} obrigatório.")]
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; } = true;
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public virtual List<ItemOrdemServico> ItemOrdensServicos { get; set; }
    }
}
