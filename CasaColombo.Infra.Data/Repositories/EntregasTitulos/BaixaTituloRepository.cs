
using CasaColombo.Domain.Entities.Titulos;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.EntregasTitulos
{
    public  class BaixaTituloRepository : BaseRepository<BaixaTitulo, int>, IBaixaTituloRepository
    {
        public List<BaixaTitulo> GetBaixaTituloId(int tituloId)
        {
            throw new NotImplementedException();
        }

        public List<BaixaTitulo> GetByUsarioId(int matricula)
        {
            throw new NotImplementedException();
        }
    }

}
