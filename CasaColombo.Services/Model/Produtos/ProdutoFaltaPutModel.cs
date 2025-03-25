namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaPutModel
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
        public string? UsuarioAutorizador { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
