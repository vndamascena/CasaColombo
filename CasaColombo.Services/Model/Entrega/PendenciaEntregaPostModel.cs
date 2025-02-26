using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.PendenciaEntrega
{
    public class PendenciaEntregaPostModel
    {

        public string? ObservacaoPendencia { get; set; }

        public string? DataEntregaProximaEntrega { get; set; }
       
        public string? DiaSemanaPendencia { get; set; }
    }
}
