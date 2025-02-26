
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
    public class EntregaRepository : BaseRepository<Entrega, int>, IEntregaRepository
    {

        protected readonly DataContext _dataContext;
        public  List<Entrega> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
                return dataContext
                    .Set<Entrega>()
                    
                    .OrderBy(p => p.NomeCliente)

                    .ToList();
        }
        public override List<Entrega> GetAll()
        {
            using (var dataContext = new DataContext())
                return dataContext
                    .Set<Entrega>()

                    .OrderBy(p => p.NomeCliente)

                    .ToList();
        }
    }
}
