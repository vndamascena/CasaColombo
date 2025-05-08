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
        public int? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public int ProdutoFaltaId { get; set; }
        public string? Loja { get; set; }
        public string? Loja2 { get; set; }
        public string? Loja3 { get; set; }
        public string? Loja4 { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public string? Observacao { get; set; }
        public string? Fornecedor { get; set; }
        public bool? JC1Recebido { get; set; }
        public bool? JC2Recebido { get; set; }
        public bool? VARecebido { get; set; }
        public bool? CLRecebido { get; set; }
        public string? Valor { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public DateTime DataHoraBaixa { get; set; }
        public string? Usuario { get; set; }
        public string? UsuarioAutorizador { get; set; }
        public string? UsuarioBaixa { get; set; }
        public int? Quantidade { get; set; }
        #region relacionamento
        public ProdutoFalta? ProdutoFalta { get; set; }
       
        #endregion
    }
}
