using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class FornecProdFaltRepository : BaseRepository<FornecProdFalt, int>, IFornecProdFaltRepository
    {
        public List<FornecProdFalt> GetAll(bool ativo)
        {

            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<FornecProdFalt>()
                    .OrderBy(p => p.NomeProduto)
                    .ToList();
            }
        }

        public FornecProdFalt ObterPorId(int id)
        {

            using (var dataContext = new DataContext())
            {
                return dataContext.Set<FornecProdFalt>().Find(id);
            }
        }

        public void Remover(int id)
        {

            using (var dataContext = new DataContext())
            {
                var fornec = dataContext.Set<FornecProdFalt>().Find(id);
                dataContext.Remove(fornec);
                dataContext.SaveChanges();
            }
        }
    }
}
