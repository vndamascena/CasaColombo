﻿using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories
{
    public class ProdutoPisoRepository : BaseRepository<ProdutoPiso, int>, IProdutoPisoRepository
    {
        protected readonly DataContext _dataContext;



        public override List<ProdutoPiso> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoPiso>()
                    .Include(p => p.Categoria) //JOIN
                    .Include(p => p.Fornecedor) //JOIN

                    .Include(p => p.Depositos)
                    .OrderBy(p => p.Nome)

                    .ToList();
            }
        }
        public List<ProdutoPiso> GetAll(bool ativo)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                   .Set<ProdutoPiso>()
                   .Include(p => p.Categoria) //JOIN
                   .Include(p => p.Fornecedor) //JOIN
                   .Include(p => p.Depositos)
                   .Include(p => p.Lote) // Inclui os lotes para evitar consultas adicionais
                   .OrderBy(p => p.Nome)
                   .ToList();

            }
        }



        public override ProdutoPiso GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<ProdutoPiso>()
                    .Include(p => p.Categoria) //JOIN
                    .Include(p => p.Fornecedor) //JOIN
                    .Include(p => p.Depositos)
                    .Include(p => p.Lote)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public List<Lote> GetLotesByProdutoId(int produtoPisoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Lote>()
                    .Where(l => l.ProdutoPisoId == produtoPisoId)
                    .ToList();
            }
        }
    }
}
