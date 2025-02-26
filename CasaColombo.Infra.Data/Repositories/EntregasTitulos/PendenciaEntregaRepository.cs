
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Infra.Data.Contexts;
using CasaColombo.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaTitulo.Infra.Data.Repositories
{
    public class PendenciaEntregaRepository : BaseRepository<PendenciaEntrega, int>, IPendenciaEntregaRepository
    {
        protected readonly DataContext _dataContext;
        public List<PendenciaEntrega> GetBaixaPendenciaId(int entregaId)
        {
            throw new NotImplementedException();
        }

        public List<PendenciaEntrega> GetByUsuarioId(string matricula)
        {
            throw new NotImplementedException();
        }


        public List<PendenciaEntrega> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
                return dataContext
                    .Set<PendenciaEntrega>()

                    .OrderBy(p => p.DataTime)

                    .ToList();
        }
        public override List<PendenciaEntrega> GetAll()
        {
            using (var dataContext = new DataContext())
                return dataContext
                    .Set<PendenciaEntrega>()

                    .OrderBy(p => p.DataTime)

                    .ToList();
        }

        public PendenciaEntrega GetByEntregaId(int entregaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<PendenciaEntrega>()
                    .FirstOrDefault(p => p.EntregaId == entregaId && p.Ativo);
            }
        }
    }
}
