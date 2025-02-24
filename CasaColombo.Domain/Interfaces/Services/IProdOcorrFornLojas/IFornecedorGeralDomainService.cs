using CasaColombo.Domain.Entities.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public  interface IFornecedorGeralDomainService
    {

        FornecedorGeral Cadastrar(FornecedorGeral fornecedorGeral);
        FornecedorGeral Atualizar(FornecedorGeral fornecedorGeral);
        FornecedorGeral Delete(int id);
        List<FornecedorGeral> Consultar();
        FornecedorGeral ObterPorId(int id);
    }
}
