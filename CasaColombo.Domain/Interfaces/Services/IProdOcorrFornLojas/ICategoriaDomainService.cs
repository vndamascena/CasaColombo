using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public interface ICategoriaDomainService
    {
        Categoria Cadastrar(Categoria categoria);
        Categoria Atualizar(Categoria categoria);
        Categoria Delete(int id);
        List<Categoria> Consultar();

        Categoria ObterPorId(int id);

    }
}
