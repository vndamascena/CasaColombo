﻿using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class ProdutoFaltaRepository : BaseRepository<ProdutoFalta, int>, IProdutoFaltaRepository
    {
        public List<ProdutoFalta> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoFalta>()
                    .OrderBy(p => p.NomeProduto)
                    .ToList();
            }
        }

        public List<FornecProdFalt> GetAllForn(int id)
        {

            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<FornecProdFalt>()
                    .Where(p => p.ProdutoFaltaId == id)
                    .ToList();
            }
        }

        public ProdutoFalta ObterPorId(int id)
        {

            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoFalta>()
                    .FirstOrDefault(p => p.Id == id);
            }
        }
    }
}
