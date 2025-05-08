using CasaColombo.Services.Model.Fornecedores;

namespace CasaColombo.Services.Model.Produtos
{
    public class FornecProdFaltGetModel
    {
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? Nome { get; set; }
        public string? Valor { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataHoraAutorizacao { get; set; }
        public string? UsuarioAutorizador { get; set; }


    }
}
