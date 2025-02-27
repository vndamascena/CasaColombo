
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
    public class BaixaTituloFuncionarioRepository : BaseRepository<BaixaTituloFuncionario, int>, IBaixaTituloFuncionarioRepository
    {
        public List<BaixaTituloFuncionario> GetBaixaTituloFuncionarioId(int tituloFuncionarioId)
        {
            throw new NotImplementedException();
        }

        public List<BaixaTituloFuncionario> GetByUsuarioId(int matricula)
        {
            throw new NotImplementedException();
        }
    }
}
