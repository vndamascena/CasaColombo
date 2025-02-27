namespace CasaColombo.Services.Model.Titulo
{
    public class TituloReceberFuncionarioPostModel
    {
        public string NomeCliente { get; set; }
        public int NumeroNota { get; set; }
        public string DataVenda { get; set; }
        public string? Valor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Observacao { get; set; }
        public string? Vendedor { get; set; }
        public string? Loja { get; set; }
        public string? DataPrevistaPagamento { get; set; }
    }
}
