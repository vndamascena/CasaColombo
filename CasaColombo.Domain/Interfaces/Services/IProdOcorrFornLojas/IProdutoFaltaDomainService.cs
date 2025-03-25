using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas
{
    public interface IProdutoFaltaDomainService
    {
        ProdutoFalta Cadastrar(ProdutoFalta produtoFalta, string matricula);
        ProdutoFalta Atualizar(ProdutoFalta produtoFalta);
        ProdutoFalta Delete(int id);
        ProdutoFalta ObterPorId(int id);
        BaixaAutProdFalt ConfirmarBaixa(int id, string momeUsuario);
        BaixaAutProdFalt ConsultarPorId(int id);
        List<BaixaAutProdFalt> ConsultarBaixaAll();
        List<ProdutoFalta> Consultar();
    }
}
