using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class BaixaAutProdFaltRepository : BaseRepository<BaixaAutProdFalt, int>, IBaixaAutProdFaltRepository
    {
        public List<BaixaAutProdFalt> GetBaixaAutProdFaltByProdutoFaltaId(int produtoFaltaId)
        {

            using (var dataContext = new DataContext())
            {
                return dataContext.Set<BaixaAutProdFalt>()
                    .Include(b => b.ProdutoFalta)
                    .Where(b => b.ProdutoFaltaId == produtoFaltaId)
                    .ToList();
            }

        }

        public List<BaixaAutProdFalt> GetBaixaAutProdFaltByUsuarioId(string nomeUsuario)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<BaixaAutProdFalt>().Where(b => b.UsuarioBaixa == nomeUsuario).ToList();
            }
        }
    }
}
