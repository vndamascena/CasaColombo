namespace CasaColombo.Services.Model.Produtos
{
    public class FornecProdFaltPostModel
    {
      
        public string? Valor { get; set; }
        public int? Quantidade { get; set; }
        public int? FornecedorGeralId { get; set; }
        public int ProdutoFaltaId { get; set; }

    }
}
