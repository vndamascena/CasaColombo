using CasaColombo.Domain.Entities.Lojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class ProdutoFalta
    {

        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? Loja { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public bool Ativo { get; set; }
        public int ProdutoAllId { get; set; }
        public int LojaId { get; set; }
        public string? Usuario { get; set; }
        public string? UsuarioAutorizador { get; set; }
        public string? DataSolicitacao { get; set; }
        public string? Fornecedor1 { get; set; }
        public string? Valor1 { get; set; }
        public string? Fornecedor2 { get; set; }
        public string? Valor2 { get; set; }

        #region relacionamento
        public ProdutoAll? ProdutoAllNavigation { get; set; }
        public Loja? LojaNavigation { get; set; }
        public List<BaixaAutProdFalt>? BaixaAutProdFalt { get; set; }

        #endregion


    }
}
