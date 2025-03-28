﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Entregas
{
    public class BaixaEntrega
    {
        public int IdBaixaEntrega { get; set; }
        public int EntregaId { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public bool Ativo { get; set; }
        public string? Valor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? DiaSemanaBaixa { get; set; }
        public string? Loja { get; set; }
        public string? Observacao { get; set; }
        public string? Vendedor { get; set; }
        public string? Periodo { get; set; }
        public string? DataEntregaBaixa { get; set; }
        public string? DataVenda { get; set; }
        public string? MotoristaAtual { get; set; }
        public string? Motorista { get; set; }
        public DateTime DataTime { get; set; }
        public string UsuarioId { get; set; }
        public Entrega? Entrega { get; set; }
        
    }
}
