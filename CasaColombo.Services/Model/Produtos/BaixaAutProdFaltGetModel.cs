namespace CasaColombo.Services.Model.Produtos
{
    public class BaixaAutProdFaltGetModel
    {
        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? Loja { get; set; }
        public string? Observacao { get; set; }
        public string? DataSolicitacao { get; set; }
        public string? Fornecedor1 { get; set; }
        public string? Valor1 { get; set; }
        public string? Fornecedor2 { get; set; }
        public string? Valor2 { get; set; }
        public DateTime DataHoraBaixa { get; set; }
        public string? Usuario { get; set; }
        public string? UsuarioBaixa { get; set; }
    }
}
