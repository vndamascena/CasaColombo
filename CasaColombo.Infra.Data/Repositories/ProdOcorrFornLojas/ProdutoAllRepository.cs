using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class ProdutoAllRepository : BaseRepository<ProdutoAll, int>, IProdutoAllRepository
    {

        protected readonly DataContext _dataContext;
        public List<ProdutoAll> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
            { return dataContext
                    .Set<ProdutoAll>()
                    .OrderBy(p => p.NomeProduto)
                    .ToList();}
        }

        public ProdutoAll GetByCodigo(string codigo)
        {
            string codigoSemZeros = codigo.TrimStart('0');

            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoAll>()
                    .AsEnumerable()  
                    .FirstOrDefault(p => p.Codigo.TrimStart('0') == codigoSemZeros);
            }
        }


    }
}
