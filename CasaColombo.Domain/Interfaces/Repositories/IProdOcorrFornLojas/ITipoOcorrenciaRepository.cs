using CasaColombo.Domain.Entities.Ocorrencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface ITipoOcorrenciaRepository: IBaseRepository<TipoOcorrencia, int>
    {
        List<TipoOcorrencia> GetAll();
        TipoOcorrencia? GetById(int id);
    }
}
