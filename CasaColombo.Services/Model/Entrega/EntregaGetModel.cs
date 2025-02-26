using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Entrega
{
    public class EntregaGetModel
    {
        public int? Id { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public string? Valor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Periodo { get; set; }
        public string? DiaSemana { get; set; }
        public string? DataEntrega { get; set; }
        public string? DataVenda { get; set; }
        public string? UsuarioId { get; set; }
        public string? Observacao { get; set; }
        public string? Loja { get; set; }
        public string? Vendedor { get; set; }
        public string? Motorista { get; set; }
        public string? MotoristaAtual { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string? UsuarioIdAtualizador { get; set; }

    }
}
