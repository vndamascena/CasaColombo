using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public interface IProdutoAllDomainService
    {
        ProdutoAll Cadastrar(ProdutoAll produtoAll);
        ProdutoAll Atualizar(ProdutoAll produtoAll);
        ProdutoAll Delete(int id);
        ProdutoAll GetByCodigo(int codigo);

        ProdutoAll ObterPorId(int id);
        List<ProdutoAll> Consultar();

        void UploadCadastrar(int codigo, string nomeProduto);
    }
}
