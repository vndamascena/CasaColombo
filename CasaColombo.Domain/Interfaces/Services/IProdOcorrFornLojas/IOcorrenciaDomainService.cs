using CasaColombo.Domain.Entities.Ocorrencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public interface IOcorrenciaDomainService
    {
        Ocorrencia Cadastrar(Ocorrencia ocorrencia, string matricula);

        // Ocorrencia Atualizar(Ocorrencia ocorrencia);


        List<Ocorrencia> Consultar();

        List<BaixaOcorrencia> ConsultarBaixa();


        void BaixaOcorrencia(int id, string matricula);

        Ocorrencia ObterPorId(int id);
        
      
    }
}
