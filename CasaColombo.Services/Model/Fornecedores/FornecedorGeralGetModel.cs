﻿namespace CasaColombo.Services.Model.Fornecedores
{
    public class FornecedorGeralGetModel
    {
        public int? Id { get; set; }

        public string? Nome { get; set; }

        public string? Vendedor { get; set; }
        public string? ForneProdu { get; set; }
        public string? Tipo { get; set; }
        public string? TelVen { get; set; }
        public string? TelFor { get; set; }

        public DateTime DataHoraCadastro { get; set; }
    }
}
