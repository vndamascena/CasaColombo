using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IProdutoGeralRepository : IBaseRepository<ProdutoGeral, int>
    {
        List<ProdutoGeral> GetAll();

       
        List<ProdutoDeposito> GetProdutosDepositosProdutoId(int produtoGeralId);

    }
}
