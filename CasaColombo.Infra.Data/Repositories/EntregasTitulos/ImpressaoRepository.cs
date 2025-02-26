
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.EntregasTitulos
{
    public class ImpressaoRepository : BaseRepository<Impressao, int>, IImpressaoRepository
    {
        protected readonly DataContext _dataContext;
        public List<Impressao> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
                return dataContext
                    .Set<Impressao>()

                    .OrderBy(p => p.DataTime)

                    .ToList();
        }

        public List<Impressao> GetByUsuarioId(string matricula)
        {
            throw new NotImplementedException();
        }
    }

       
    
}

