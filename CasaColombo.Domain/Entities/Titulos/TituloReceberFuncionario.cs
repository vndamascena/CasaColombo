using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Titulos
{
    public class TituloReceberFuncionario
    {
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public string NomeCliente { get; set; }
        public string Valor { get; set; }
        public string? Observacao { get; set; }
        public string? Vendedor { get; set; }
        public string? Loja { get; set; }
        public string? UsuarioId { get; set; }
        public string? ImagemUrl { get; set; }
        public string DataVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string? UsuarioIdAtualizador { get; set; }
        public string? DataPrevistaPagamento { get; set; }

        public bool Ativo { get; set; }
        public List<BaixaTituloFuncionario> baixaTitulosFuncionario { get; set; }

        public TituloReceberFuncionario()
        {
            baixaTitulosFuncionario = new List<BaixaTituloFuncionario>();
        }
    }
}
