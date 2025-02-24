using CasaColombo.Domain.Entities.Ocorrencias;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class TipoOcorrenciaRepository: BaseRepository<TipoOcorrencia, int>, ITipoOcorrenciaRepository
    {
        public override List<TipoOcorrencia> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TipoOcorrencia>().OrderBy(f => f.Nome).ToList();
            }
        }
        public TipoOcorrencia? GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TipoOcorrencia>()
                .Where(f => f.Id == id)
                .FirstOrDefault();

            }
        }
    }
}
