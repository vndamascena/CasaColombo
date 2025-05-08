using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class ProdutoAll
    {
        public int? Id { get; set; }
        public string NomeProduto { get; set; }
        public int? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public bool Ativo { get; set; }

        #region relacionamento
        public List<ProdutoFalta>? ProdutoFalta { get; set; }
        #endregion
    }
}
