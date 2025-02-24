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
    public class VendaRepository : BaseRepository<Venda, int>, IVendaRepository
    {
        public List<Venda> GetVendasByLoteId(int loteId)
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Set<Venda>()
                           .Include(v => v.Lote) // Inclui o lote relacionado à venda
                           .Where(v => v.LoteId == loteId)
                           .ToList(); ;

            }
        }

        public List<Venda> GetVendasByUsuarioId(string matricula)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Venda>().Where(v => v.UsuarioId == matricula).ToList();
            }
        }
    }

}
