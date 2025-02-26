using CasaColombo.Domain.Entities.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos
{
    public interface IEntregaRepository: IBaseRepository<Entrega, int>
    {
        List<Entrega> GetAll(bool ativo);
    }
}
