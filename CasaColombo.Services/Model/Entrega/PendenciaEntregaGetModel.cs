namespace CasaColombo.Services.Model.PendenciaEntrega
{
    public class PendenciaEntregaGetModel
    {
        public int IdPendencia { get; set; }
        public int EntregaId { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public string? Valor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Observacao { get; set; }
        public string? ObservacaoPendencia { get; set; }
        public string? DiaSemana { get; set; }
        public string? Vendedor { get; set; }
        public string? Periodo { get; set; }
        public string? MotoristaAtual { get; set; }
        public string? Motorista { get; set; }
        public string? DataEntrega { get; set; }
        public string? DataVenda { get; set; }
        public string? UsuarioId { get; set; }
        public DateTime DataTime { get; set; }
        public string? Loja { get; set; }
       

        public string? DataEntregaProximaEntrega { get; set; }

        public string? DiaSemanaPendencia { get; set; }

    }
}
