using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }        
        [Required(ErrorMessage = "O campo {0} é obrigatório..")]
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public virtual List<OrdemServico> OrdemServicos { get; set; }
    }
}
