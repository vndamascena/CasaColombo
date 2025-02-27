namespace CasaColombo.Services.Model.Titulo
{
    public class TituloReceberFuncionarioPutModel
    {
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public string NomeCliente { get; set; }
        public string? Valor { get; set; }
       
        public string? ImagemUrl { get; set; }
        public string? Observacao { get; set; }
        public string? DataPrevistaPagamento { get; set; }
    }
}
