using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class BaixaAutProdFalt
    {
        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public int ProdutoFaltaId { get; set; }
        public string? Loja { get; set; }
        public string? Observacao { get; set; }
        public string? DataSolicitacao { get; set; }
        public string? Fornecedor1 { get; set; }
        public string? Valor1 { get; set; }
        public string? Fornecedor2 { get; set; }
        public string? Valor2 { get; set; }
        public DateTime DataHoraBaixa { get; set; }
        public string? Usuario { get; set; }
        public string? UsuarioAutorizador { get; set; }
        public string? UsuarioBaixa { get; set; }
        #region relacionamento
        public ProdutoFalta? ProdutoFalta { get; set; }
       
        #endregion
    }
}
