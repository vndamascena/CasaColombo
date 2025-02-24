using CasaColombo.Domain.Entities.Depositoss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public interface IDepositosDomainService
    {
        List<Depositos> Consultar();
        Depositos Cadastrar(Depositos depositos);
        Depositos ObterPorId(int id);
    }
}
