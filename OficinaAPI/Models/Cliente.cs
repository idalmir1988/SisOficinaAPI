using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(14, ErrorMessage = "{0} excedeu o número de caracteres.")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Documento { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Telefone { get; set; }

        [StringLength(8, ErrorMessage = "{0} excedeu o número de caracteres.")]
        public string Cep { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        public string Uf { get; set; }

        [StringLength(80)]
        public string Bairro { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [StringLength(100)]
        public string Complemento { get; set; }
        public virtual List<OrdemServico> OrdensServicos { get; set; }
    }
}
