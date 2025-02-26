using CasaColombo.Domain.Entities.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos
{
    public interface IBaixaEntregaRepository: IBaseRepository<BaixaEntrega, int>
    {
        List<BaixaEntrega> GetBaixaEntregaId(int entregaId);
        List<BaixaEntrega> GetByUsuarioId(string matricula);
    }
}
