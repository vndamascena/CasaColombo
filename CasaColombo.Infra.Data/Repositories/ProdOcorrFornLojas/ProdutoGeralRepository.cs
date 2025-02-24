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
    public class ProdutoGeralRepository : BaseRepository<ProdutoGeral, int>, IProdutoGeralRepository
    {
        protected readonly DataContext _dataContext;


        public List<ProdutoGeral> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                   .Set<ProdutoGeral>()
                   .Include(p => p.Categoria) //JOIN
                   .Include(p => p.Fornecedor) //JOIN
                   .Include(p => p.ProdutoDeposito)
                   .OrderBy(p => p.NomeProduto)
                   .ToList();

            }
        }

        public override ProdutoGeral GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoGeral>()
                    .Include(p => p.Categoria) //JOIN
                    .Include(p => p.Fornecedor) //JOIN
                    .Include(p => p.ProdutoDeposito)

                    .FirstOrDefault(p => p.Id == id);
            }
        }


        public List<ProdutoDeposito> GetProdutosDepositosProdutoId(int produtoGeralId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoDeposito>()
                    .Where(l => l.ProdutoGeralId == produtoGeralId)

                    .ToList();
            }
        }


        
      
    }
}
