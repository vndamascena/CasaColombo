using CasaColombo.Services.Model.Categoria;

using CasaColombo.Services.Model.Fornecedores;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoGeralGetModel
    {
        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? MarcaProduto { get; set; }
        public int? QuantidadeProd { get; set; }
        public string? Un { get; set; }
        public string? CodigoSistema { get; set; }
        public string? ImagemUrlGeral { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

        public FornecedorGeralGetModel? Fornecedor { get; set; }
        public CategoriaGetModel? Categoria { get; set; }

        // Adiciona uma lista de depósitos com suas quantidades
        public List<ProdutoDepositoGetModel>? ProdutoDeposito { get; set; }
    }

    public class ProdutoDepositoGetModel
    {
        public int Id { get; set; }
        public int DepositoId { get; set; }
        public string? UsuarioIdCadastro { get; set; }
        public string? UsuarioIdAlteracao { get; set; }
        public string? NomeDeposito { get; set; } 
        public int Quantidade { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoSistema { get; set; }
        public int? QtdEntrada { get; set; }
        public string? Marca { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}
