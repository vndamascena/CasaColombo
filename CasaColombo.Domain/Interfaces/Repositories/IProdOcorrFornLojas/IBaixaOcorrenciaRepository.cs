using CasaColombo.Domain.Entities.Ocorrencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IBaixaOcorrenciaRepository : IBaseRepository<BaixaOcorrencia, int>
    {
        List<BaixaOcorrencia> GetBaixaOcorrenciaId(int ocorrenciaId);
        List<BaixaOcorrencia> GetByUsuarioId(string matricula);

    }
}
