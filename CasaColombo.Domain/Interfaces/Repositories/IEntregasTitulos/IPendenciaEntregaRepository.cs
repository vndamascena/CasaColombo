using CasaColombo.Domain.Entities.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos
{
    public interface IPendenciaEntregaRepository: IBaseRepository<PendenciaEntrega, int>
    {
        List<PendenciaEntrega> GetBaixaPendenciaId(int entregaId);
        List<PendenciaEntrega> GetByUsuarioId(string matricula);
        List<PendenciaEntrega> GetAll(bool ativo);
        PendenciaEntrega GetByEntregaId(int entregaId);
    }
}
