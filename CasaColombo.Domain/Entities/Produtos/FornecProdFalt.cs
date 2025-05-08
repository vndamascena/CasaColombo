using CasaColombo.Domain.Entities.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class FornecProdFalt
    {
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Nome { get; set; }
        public string? Valor { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataEntrada { get; set; }
        public int? Codigo { get; set; }
        public int? FornecedorGeralId { get; set; }
        public string? UsuarioAutorizador { get; set; }
        public DateTime DataHoraAutorizacao { get; set; }
        public int? ProdutoFaltaId { get; set; }
        #region Relacionamentos
        public ProdutoFalta? ProdutoFalta { get; set; }
        public FornecedorGeral? Fornecedor { get; set; }
        #endregion
    }
}
