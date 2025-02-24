using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class LoteRepository : BaseRepository<Lote, int>, ILoteRepository
    {
        public List<Lote> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                   .Set<Lote>()
                   
                   .OrderBy(p => p.Id)
                   .ToList();

            }
        }

        public Lote ObterPorId(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Lote>().Find(id);
            }
        }

        // Implementação do método para remover um lote pelo ID
        public void Remover(int id)
        {
            using (var dataContext = new DataContext())
            {
                var entity = dataContext.Set<Lote>().Find(id);
                if (entity != null)
                {
                    dataContext.Set<Lote>().Remove(entity);
                    dataContext.SaveChanges();
                }
            }
        }
    }
}
