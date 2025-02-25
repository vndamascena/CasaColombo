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
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        public CategoriaRepository() // Adicionado um construtor vazio
        {
        }

        public override List<Categoria> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Categoria>()
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }
    }
}
