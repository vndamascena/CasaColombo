﻿using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Depositoss
{
    public class Depositos
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        #region Relacionamento
        // Relacionamento Muitos-para-Muitos com a tabela intermediária ProdutoDeposito
        public List<ProdutoDeposito> ProdutoDepositos { get; set; }

        public List<ProdutoPiso>? ProdutoPiso { get; set; }
        #endregion
    }
}
