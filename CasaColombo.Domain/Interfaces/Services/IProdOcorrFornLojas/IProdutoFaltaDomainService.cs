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
        FornecProdFalt Autorizar(FornecProdFalt fornecProdFalt, string matricula);
        ProdutoFalta AtualizarLoja(ProdutoFalta produtoFalta);
        ProdutoFalta Delete(int id);
        ProdutoFalta AtualizarStatusProduto(ProdutoFalta produtoFalta);
        ProdutoFalta ProdutoObterPorId(int id);
        BaixaAutProdFalt ConfirmarBaixa(int id, string momeUsuario);
        BaixaAutProdFalt ConsultarPorId(int id);
        FornecProdFalt CadastrarFornec(FornecProdFalt fornecProdFalt);
        List<BaixaAutProdFalt> ConsultarBaixaAll();
        List<ProdutoFalta> Consultar();
        List<FornecProdFalt> ConsultarFornecAll(int produtoFaltaId);
       
        FornecProdFalt ExcluirFornec(int fornecProdFaltId);


    }
}
