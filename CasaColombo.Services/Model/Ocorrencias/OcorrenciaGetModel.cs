using CasaColombo.Services.Model.Fornecedores;
using CasaColombo.Services.Model.Lojas;

namespace CasaColombo.Services.Model.Ocorrencias
{
    public class OcorrenciaGetModel
    {
        public int Id { get; set; }
        public int CodProduto { get; set; }
        public string Produto { get; set; }

        public string NumeroNota { get; set; }
        public DateTime DataTime { get; set; }
        public string Observacao { get; set; }
        public string UsuarioId { get; set; }
        public LojaGetModel Loja { get; set; }
        public TipoOcorrenciaGetModel? TipoOcorrencia { get; set; }
        public FornecedorGeralGetModel? FornecedorGeral { get; set; }

    }
}
