using CasaColombo.Domain.Entities.Titulos;
using CasaColombo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos
{
    public interface ITituloReceberRepository: IBaseRepository<TituloReceber, int>
    {
        List<TituloReceber> GetAll(bool ativo);
    }
}
