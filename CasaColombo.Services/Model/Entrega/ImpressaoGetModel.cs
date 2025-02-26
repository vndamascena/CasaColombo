namespace CasaColombo.Services.Model.Impressao
{
    public class ImpressaoGetModel
    {
        public int IdImpressao { get; set; }
        public int EntregaId { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public string? UsuarioId { get; set; }
        public DateTime DataTime { get; set; }
    }
}
