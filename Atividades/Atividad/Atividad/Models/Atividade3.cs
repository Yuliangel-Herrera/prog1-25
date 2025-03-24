using System;
using System.ComponentModel.DataAnnotations;

namespace NumeroPorExtenso.Models
{
    public class NumeroPorExtensoModel
    {
        [Required(ErrorMessage = "O número é obrigatório.")]
        [Range(0, 9999, ErrorMessage = "O número deve estar entre 0 e 9999.")]
        public int Numero { get; set; }
    }
}
