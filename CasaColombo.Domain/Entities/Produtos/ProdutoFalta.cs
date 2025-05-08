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
        public int? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? Loja { get; set; }
        public string? Loja2 { get; set; }
        public string? Loja3 { get; set; }
        public string? Loja4 { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public bool? JC1Recebido { get; set; }
        public bool? JC2Recebido { get; set; }
        public bool? VARecebido { get; set; }
        public bool? CLRecebido { get; set; }
        public bool? SeparadoJC1 { get; set; }
        public bool? SeparadoJC2 { get; set; }
        public bool? SeparadoVA { get; set; }
        public bool? SeparadoCL { get; set; }
        public bool Ativo { get; set; }
        
        public int LojaId { get; set; }
      
        public string? Usuario { get; set; }
      
        public DateTime? DataSolicitacao { get; set; }
      

        #region relacionamento
        public ProdutoAll? ProdutoAllNavigation { get; set; }
        public Loja? LojaNavigation { get; set; }
        public List<BaixaAutProdFalt>? BaixaAutProdFalt { get; set; }
        public List<FornecProdFalt>? FornecProdFalt { get; set; }


        #endregion


    }
}
