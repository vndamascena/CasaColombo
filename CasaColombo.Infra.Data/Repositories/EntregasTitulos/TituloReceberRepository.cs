
using CasaColombo.Domain.Entities.Titulos;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Infra.Data.Contexts;
using CasaColombo.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.EntregasTitulos
{
    public class TituloReceberRepository : BaseRepository<TituloReceber, int>, ITituloReceberRepository
    {

        protected readonly DataContextSecundaria _dataContext;
        public List<TituloReceber> GetAll(bool ativo)
        {
            using (var dataContext = new DataContextSecundaria())
                return dataContext
                    .Set<TituloReceber>()

                    .OrderBy(p => p.NomeCliente)

                    .ToList();
        }

        public override List<TituloReceber> GetAll()
        {
            using (var dataContext = new DataContextSecundaria())
                return dataContext
                    .Set<TituloReceber>()

                    .OrderBy(p => p.NomeCliente)

                    .ToList();
        }
    }
}
