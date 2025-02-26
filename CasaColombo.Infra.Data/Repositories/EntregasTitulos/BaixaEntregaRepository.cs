
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.EntregasTitulos
{
    public class BaixaEntregaRepository : BaseRepository<BaixaEntrega, int>, IBaixaEntregaRepository
    {
        public List<BaixaEntrega> GetBaixaEntregaId(int entregaId)
        {
            throw new NotImplementedException();
        }

        public List<BaixaEntrega> GetByUsuarioId(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}
