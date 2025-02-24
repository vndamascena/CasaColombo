using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IProdutoPisoRepository : IBaseRepository<ProdutoPiso,int>
    {
        List<ProdutoPiso> GetAll(bool ativo);
        List<Lote> GetLotesByProdutoId( int produtoPisoId);

    }
}
