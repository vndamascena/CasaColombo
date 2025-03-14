using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class ProdutoFaltaRepository : BaseRepository<ProdutoFalta, int>, IProdutoFaltaRepository
    {
        public List<ProdutoFalta> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoFalta>()
                    .OrderBy(p => p.NomeProduto)
                    .ToList();
            }
        }
    }
}
