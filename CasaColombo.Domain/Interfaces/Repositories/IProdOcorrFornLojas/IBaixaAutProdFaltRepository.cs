using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IBaixaAutProdFaltRepository : IBaseRepository<BaixaAutProdFalt, int>
    {
        List<BaixaAutProdFalt> GetBaixaAutProdFaltByProdutoFaltaId(int produtoFaltaId);
        List<BaixaAutProdFalt> GetBaixaAutProdFaltByUsuarioId(string nomeUsuario);
    }
}
