﻿using CasaColombo.Domain.Entities.Home;
using CasaColombo.Domain.Interfaces.Repositories.IHome;
using CasaColombo.Domain.Interfaces.Services.IHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Services.Home
{
    public class HomeDomainService : IHomeDomainService
    {
        private readonly IHomeDomainService _homedomainSerove;
        private readonly IEscalaRepository _escalaRepository;
        public HomeDomainService(IEscalaRepository escalaRepository)
        {
           
            _escalaRepository = escalaRepository;
        }

      

        public Escala Cadastrar(Escala escala)
        {

            _escalaRepository?.Add(escala);
            escala = _escalaRepository?.GetById(escala.Id);

            return escala;
        }

        public List<Escala> Consultar()
        {
            var escala = _escalaRepository?.GetAll();
            if (escala == null)
                return new List<Escala>();
            return escala.ToList();
        }

        public Escala ObterPorId(int id)
        {
            var escala = _escalaRepository.GetById(id);
            return escala;

        }
    }
}
