using CasaColombo.Services.Model.Categoria;
using CasaColombo.Services.Model.Depositos;
using CasaColombo.Services.Model.Fornecedores;
using CasaColombo.Services.Model.Produtos;
using System.ComponentModel.DataAnnotations;

namespace CasaColomboApp.Services.Model.Produtos
{
    public class ProdutoPisoGetModel
    {
        public int? Id { get; set; }
       
        public string? Nome { get; set; }
        public string? Marca { get; set; }
        public int? Quantidade { get; set; }
        public string? Pei { get; set; }
        public string? Descricao { get; set; }

        public int? PecasCaixa { get; set; }

        public string? MetroQCaixa { get; set; }

        public string? PrecoCaixa { get; set; }

        
        public string? PrecoMetroQ { get; set; }

        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

        public FornecedorGeralGetModel? Fornecedor { get; set; }
        public CategoriaGetModel? Categoria { get; set; }

        public DepositosGetModel? Deposito { get; set; }

        public string? ImagemUrl { get; set; }
        public List<LoteGetModel> Lote { get; set; }

    }
}
