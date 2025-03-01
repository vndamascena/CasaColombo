﻿using CasaColombo.Domain.Entities.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Produtos
{
    public class ProdutoGeral
    {
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? MarcaProduto { get; set; }
        public int? QuantidadeProd { get; set; }
        public string? Un { get; set; }
        public string? CodigoSistema { get; set; }
        public string? ImagemUrlGeral { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public int? FornecedorGeralId { get; set; }
        public int? CategoriaId { get; set; }

        #region Relacionamentos
        public FornecedorGeral? Fornecedor { get; set; }
        public Categoria? Categoria { get; set; }


        // Relacionamento Muitos-para-Muitos com a tabela intermediária ProdutoDeposito
        public List<ProdutoDeposito> ProdutoDeposito { get; set; }
        #endregion
    }
}
