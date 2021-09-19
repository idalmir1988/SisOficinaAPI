using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Models
{
    public class ItemOrdemServico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int OrdemServicoId { get; set; }
        public OrdemServico OrdemServico { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]        
        public Servico Servico { get; set; }
        public int ServicoId { get; set; }
    }
}
