
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
    public class PagamentoRepository : BaseRepository<Pagamento, int>, IPagamentoRepository
    {
        protected readonly DataContextSecundaria _dataContext;
        public List<Pagamento> GetAll(bool ativo)
        {
            using (var dataContext = new DataContextSecundaria())
                return dataContext
                    .Set<Pagamento>()

                    .OrderBy(p => p.DataTime)

                    .ToList();
        }

        public List<Pagamento> GetByUsuarioId(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}

