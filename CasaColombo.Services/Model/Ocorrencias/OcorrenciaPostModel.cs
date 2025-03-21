﻿using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Ocorrencias
{
    public class OcorrenciaPostModel
    {
        public int CodProduto { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(1, ErrorMessage = "Informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no maximo {1} carateres.")]
        public string Produto { get; set; }

        public string NumeroNota { get; set; }

        public string Observacao { get; set; }

        public int? LojaId { get; set; }
        public int? FornecedorGeralId { get; set; }
        [Required(ErrorMessage = "Por favor, informeo ID da ocorrencia para o produto.")]
        public int? TipoOcorrenciaId { get; set; }
    }
}
