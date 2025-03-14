using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaGetModel
    {
        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? loja { get; set; }
        public string? observacao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public string? Usuario { get; set; }
    }
}
