using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetClinicManagement.Models
{
    public class Atendimento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Animal")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        [Required]
        [Display(Name = "Veterinário")]
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }

        [Required]
        [Display(Name = "Data do Atendimento")]
        [DataType(DataType.Date)]
        public DateTime DataAtendimento { get; set; }

        [Display(Name = "Procedimentos realizados")]
        public List<AtendimentoProcedimento> AtendimentoProcedimentos { get; set; }
    }

    public class AtendimentoProcedimento
    {
        public int Id { get; set; }

        [Required]
        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }

        [Required]
        public int ProcedimentoId { get; set; }
        public Procedimento Procedimento { get; set; }
    }
}
