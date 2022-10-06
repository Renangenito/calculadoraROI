using System.ComponentModel.DataAnnotations;

namespace CalculadoraROI.Models
{
    public class Calculadora
    {
        [Key]
       
        public int? Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Empresa é obrigatório.")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "O campo Segmento é obrigatório.")]
        public string Segmento { get; set; }

        [Display(Name = "Area de Atuação")]
        [Required(ErrorMessage = "O campo Area de Atuacao é obrigatório.")]
        public string AreaAtuacao { get; set; }
        [Required(ErrorMessage = "O campo Onboarding é obrigatório.")]
        public string Onboarding { get; set; }
      
        [Display(Name = "Consulta ao Mês")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public int ConsultaMes { get; set; }

        [Display(Name = "Ticket Médio")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public decimal TicketMedio { get; set; }

        [Display(Name = "Resultado do Roi")]
        public string? ResultadoRoi { get; set; }

        [Required(ErrorMessage = "O campo Data do Cáelculo é obrigatório.")]
        [Display(Name = "Data do Cálculo")]
        public DateTime DataHoraCalculo { get; set; }

    }
}
