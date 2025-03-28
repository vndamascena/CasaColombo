﻿using System.ComponentModel.DataAnnotations;

namespace CasaColombo.Services.Model.Fornecedores
{
    public class FornecedorGeralPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do fornecedor.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [MinLength(4, ErrorMessage = "Informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no maximo {1} carateres.")]
        public string? Nome { get; set; }
        public string? Vendedor { get; set; }
        public string? ForneProdu { get; set; }
        public string? Tipo { get; set; }
        public string? TelVen { get; set; }
        public string? TelFor { get; set; }
    }
}
