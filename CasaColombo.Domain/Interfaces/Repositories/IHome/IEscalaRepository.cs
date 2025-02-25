
using CasaColombo.Domain.Entities.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IHome
{
    public interface IEscalaRepository : IBaseRepository<Escala,int>
    {
        List<Escala>Get(int id);
    }
}
