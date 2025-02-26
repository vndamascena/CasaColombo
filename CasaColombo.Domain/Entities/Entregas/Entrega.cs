using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Entregas
{
    public class Entrega
    {

        public int Id { get; set; }
        public int? NumeroNota { get; set; }
        public string? NomeCliente { get; set; }
        public bool Ativo { get; set; }
        public string? Valor { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Observacao { get; set; }
        public string? Loja { get; set; }
        public string UsuarioId { get; set; }
        public string? DiaSemana { get; set; }
        public string? Vendedor { get; set; }
        public string? Periodo { get; set; }
        public string?  Motorista { get; set; }
        public string? DataEntrega { get; set; }
        public string? DataVenda { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? MotoristaAtual { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string? UsuarioIdAtualizador { get; set; }


        public List<BaixaEntrega> BaixaEntregas { get; set; }
        public List<PendenciaEntrega> PendenciaEntregas { get; set; }
        public List<Impressao> Impressao { get; set; }
        public List<Pagamento> Pagamento { get; set; }

        public Entrega()
        {
            BaixaEntregas = new List<BaixaEntrega>();
            PendenciaEntregas = new List<PendenciaEntrega> { };
            Impressao = new List<Impressao>();
            Pagamento = new List<Pagamento>();
        }

    }
}
