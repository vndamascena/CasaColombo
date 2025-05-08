namespace CasaColombo.Services.Model.Produtos
{
    public class ProdutoFaltaPutModel
    {

        public int? Id { get; set; }
       
        public DateTime? DataSolicitacao { get; set; }

        public int? LojaId { get; set; }
        public bool? JC1Recebido { get; set; }
        public bool? JC2Recebido { get; set; }
        public bool? VARecebido { get; set; }
        public bool? CLRecebido { get; set; }
        public bool? SeparadoJC1 { get; set; }
        public bool? SeparadoJC2 { get; set; }
        public bool? SeparadoVA { get; set; }
        public bool? SeparadoCL { get; set; }
        


    }
}
