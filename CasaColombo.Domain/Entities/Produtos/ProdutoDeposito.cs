﻿using CasaColombo.Domain.Entities.Depositoss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class ProdutoDeposito
    {
        public int Id { get; set; } // Chave primária única
        public int ProdutoGeralId { get; set; } // Chave estrangeira
        public int DepositoId { get; set; } // Chave estrangeira
        public int Quantidade { get; set; }
        public string NomeDeposito { get; set; }
        public string? CodigoSistema { get; set; }
        public string? NomeProduto { get; set; }
        public int QtdEntrada { get; set; }
        public string? UsuarioIdCadastro { get; set; }
        public string? UsuarioIdAlteracao { get; set; }
        public string? Marca { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public DateTime? DataEntrada { get; set; }

        #region Relacionamento
        public ProdutoGeral ProdutoGeral { get; set; }
        public Depositos Deposito { get; set; }

        public List<VendaProdutoGeral> VendaProdutoGeral { get; set; }

        #endregion
    }
}
