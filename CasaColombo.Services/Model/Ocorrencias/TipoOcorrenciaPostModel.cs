using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Ocorrencias
{
    public class TipoOcorrenciaPostModel
    {
        [Required(ErrorMessage = "Informe o nome da ocorrencia.")]
        [MinLength(1, ErrorMessage = "Informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no maximo {1} carateres.")]
        public string? Nome { get; set; }
    }
}
