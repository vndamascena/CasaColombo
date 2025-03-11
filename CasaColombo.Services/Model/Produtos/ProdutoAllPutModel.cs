﻿using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoAllPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? NomeProduto { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoFornecedor { get; set; }
    }
}
