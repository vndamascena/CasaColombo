using CasaColombo.Domain.Entities.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IHome
{
    public interface IHomeDomainService
    {
        Escala Cadastrar(Escala escala);
        List<Escala>  Consultar();
        Escala ObterPorId(int id);
    }
}
