using System.ComponentModel.DataAnnotations;

namespace Animal.Models
{
    public class Animal
    { 
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Animal")]
        public string nome { get; set;}
        [Display(Name = "Informe a espécie do animal")]
        public string especie { get; set; }
        [Display(Name = "Informe sua raça")]
        public string raca { get; set;}
        [Display(Name = "Idade")]
        public int idade { get; set; }
        [Display(Name = "Nome do Proprietário")]
        public string propietario { get; set; }
    }

    public class Veterinario
    {
        public int Id { get; set; }
        [Required]
        [Display(namespace = "Nome do Veterinário")]
        public string nome { get; set; }
        [Display(Name = "Telefone")]
        public int telefone { get; set; }
    }
    public class Procedimento
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Procedimento")]
        public string procedimento { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    } 
}


