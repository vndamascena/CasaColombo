using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoAllPostModel
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "Informe no máximo {1} caracteres.")]
        
        public string? NomeProduto { get; set; }
        public int? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
    }
}