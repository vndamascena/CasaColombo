﻿using CasaColombo.Domain.Entities.Lojas;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas
{
    public class LojaRepository: BaseRepository<Loja, int>, ILojaRepository
    {
        public override List<Loja> GetAll() 
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Loja>().OrderBy(f => f.Nome).ToList();
            }
        }
        public Loja? GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Loja>()
                .Where(f => f.Id == id)
                .FirstOrDefault();

            }
        }
    }
}
