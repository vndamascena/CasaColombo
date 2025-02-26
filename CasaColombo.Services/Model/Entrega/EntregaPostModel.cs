using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Entrega
{
    public class EntregaPostModel
    {

        [Required(ErrorMessage = "Informe o numero da nota.")]

        public int? NumeroNota { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente.")]
        [MinLength(1, ErrorMessage = "Informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no maximo {1} carateres.")]
        public string? NomeCliente { get; set; }
        public string? Valor { get; set; }
        public string? Periodo { get; set; }
        public string? Vendedor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Observacao { get; set; }
        public string? DataEntrega { get; set; }
        public string? DataVenda { get; set; }

        [Required(ErrorMessage = "Selecione um dia da semana.")]
        public string? DiaSemana { get; set; }
        public string? Loja { get; set; }
      



    }
}
