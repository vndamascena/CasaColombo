using CasaColombo.Domain.Entities.Ocorrencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IOcorrenciaRepository : IBaseRepository<Ocorrencia, int>
    {
        List<Ocorrencia> GetAll(bool ativo);
    }
}
