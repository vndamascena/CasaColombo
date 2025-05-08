using CasaColombo.Services.Model.Lojas;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaPostModel
    {
        public string? Observacao { get; set; }
        public int Codigo { get; set; }
        public string? NomeProduto { get; set; }
        public int LojaId { get; set; }
       

    }
}
