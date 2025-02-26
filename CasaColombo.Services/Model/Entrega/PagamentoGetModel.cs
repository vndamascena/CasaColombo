namespace CasaColombo.Services.Model.Pagamento
{
    public class PagamentoGetModel
    {
        public int IdPagamento { get; set; }
        public int EntregaId { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public string? UsuarioId { get; set; }
        public string? StatusDePagamento { get; set; }
        public DateTime DataTime { get; set; }
    }
}
