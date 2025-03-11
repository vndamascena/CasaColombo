using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IProdutoAllRepository : IBaseRepository<ProdutoAll, int>   
    {
        List<ProdutoAll> GetAll(bool ativo);
        ProdutoAll GetByCodigo(string codigo);
    }
}
