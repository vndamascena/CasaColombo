using CasaColombo.Domain.Entities.Home;
using CasaColombo.Domain.Interfaces.Repositories.IHome;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.Home
{
    public class EscalaRepository: BaseRepository<Escala, int>, IEscalaRepository
    {
        protected DataContextSecundaria _dataContext;
        public List<Escala> Get(int id)
        {
            using (var dataContext = new  DataContextSecundaria())
                return dataContext
                    .Set<Escala>()
                    .OrderBy(x => x.Nome)
                    .ToList();



        }
    }
}
