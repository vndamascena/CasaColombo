using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaGetModel
    {
        public int? Id { get; set; }
        public string? NomeProduto { get; set; }
        public int? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
        public string? Loja { get; set; }
        public string? Loja2 { get; set; }
        public string? Loja3 { get; set; }
        public string? Loja4 { get; set; }
        public bool? JC1Recebido { get; set; }
        public bool? JC2Recebido { get; set; }
        public bool? VARecebido { get; set; }
        public bool? CLRecebido { get; set; }
        public bool? SeparadoJC1 { get; set; }
        public bool? SeparadoJC2 { get; set; }
        public bool? SeparadoVA { get; set; }
        public bool? SeparadoCL { get; set; }
        public string? Observacao { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
       
        public string? Usuario { get; set; }
        public string? UsuarioAutorizador { get; set; }

        

    }
}
