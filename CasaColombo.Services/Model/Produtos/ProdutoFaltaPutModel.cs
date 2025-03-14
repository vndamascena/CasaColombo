namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaPutModel
    {

        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? loja { get; set; }
        public string? observacao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
