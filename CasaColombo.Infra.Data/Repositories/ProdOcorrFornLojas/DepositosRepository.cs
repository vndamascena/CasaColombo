using CasaColombo.Domain.Entities.Depositoss;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class DepositosRepository : BaseRepository<Depositos, int>, IDepositosRepository
    {
        public override List<Depositos> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Depositos>().OrderBy(f => f.Nome).ToList();
            }


        }

        public Depositos? GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Depositos>()
                .Where(f => f.Id == id)
                .FirstOrDefault();

            }
        }
    }
}
