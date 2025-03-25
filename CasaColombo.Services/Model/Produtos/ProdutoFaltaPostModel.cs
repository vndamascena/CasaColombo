using CasaColombo.Services.Model.Lojas;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaPostModel
    {
        public string? Observacao { get; set; }
        public int ProdutoAllId { get; set; }
        public int LojaId { get; set; }

    }
}
