using AutoMapper;
using CasaColombo.Domain.Entities.Depositoss;
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Entities.Fornecedores;
using CasaColombo.Domain.Entities.Home;
using CasaColombo.Domain.Entities.Lojas;
using CasaColombo.Domain.Entities.Ocorrencias;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Entities.Titulos;
using CasaColombo.Services.Model.Categoria;
using CasaColombo.Services.Model.Depositos;
using CasaColombo.Services.Model.Entrega;
using CasaColombo.Services.Model.Fornecedores;
using CasaColombo.Services.Model.HomeModel.EscalaModel;
using CasaColombo.Services.Model.Impressao;
using CasaColombo.Services.Model.Lojas;
using CasaColombo.Services.Model.Ocorrencias;
using CasaColombo.Services.Model.Pagamento;
using CasaColombo.Services.Model.PendenciaEntrega;
using CasaColombo.Services.Model.Produtos;
using CasaColombo.Services.Model.Titulo;




namespace CasaColombo.Services.Mappings
{
    /// <summary>
    /// Classe para configuração dos mapeamentos
    /// feitos no projeto através do AutoMapper
    /// </summary>
    public class ProfileMapping : Profile
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public ProfileMapping()
        {


            // ProdutoPiso
            CreateMap<ProdutoPisoPostModel, ProdutoPiso>()
                .AfterMap((model, entity) =>
                {
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraAlteracao = DateTime.Now;
                    entity.Ativo = true;
                });

            CreateMap<ProdutoPiso, ProdutoPisoGetModel>()
                .ForMember(dest => dest.Lote, opt => opt.MapFrom(src => src.Lote));

            CreateMap<ProdutoPisoPutModel, ProdutoPiso>()
                .ForMember(dest => dest.Lote, opt => opt.MapFrom(src => src.Lote));

            // ProdutoGeral
            CreateMap<ProdutoGeralPostModel, ProdutoGeral>()
                .AfterMap((model, entity) =>
                {
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraAlteracao = DateTime.Now;
                });

            CreateMap<ProdutoGeral, ProdutoGeralGetModel>();

            CreateMap<ProdutoGeralPutModel, ProdutoGeral>()
                 .ForMember(dest => dest.ProdutoDeposito, opt => opt.MapFrom(src => src.ProdutoDeposito));
            CreateMap<ProdutoGeral, ProdutoGeralPutModel>()
                .ForMember(dest => dest.ProdutoDeposito, opt => opt.MapFrom(src => src.ProdutoDeposito));

            // categoria
            CreateMap<CategoriaPostModel, Categoria>()
                .AfterMap((model, entity) =>
                {
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraAlteracao = DateTime.Now;
                });

            CreateMap<Categoria, CategoriaGetModel>();


            // ocorrencia
            CreateMap<OcorrenciaPostModel, Ocorrencia>()
                .AfterMap((model, entity) =>
                {
                    entity.DataTime = DateTime.Now;
                    entity.Ativo = true;
                });

            CreateMap<Ocorrencia, OcorrenciaGetModel>()
                .ForMember(dest => dest.TipoOcorrencia, opt => opt.MapFrom(src => src.TipoOcorrencia))
                .ForMember(dest => dest.FornecedorGeral, opt => opt.MapFrom(src => src.FornecedorGeral))
                .ForMember(dest => dest.Loja, opt => opt.MapFrom(src => src.Loja));

            CreateMap<BaixaOcorrencia, BaixaOcorrenciaGetModel>();

            // tipo ocorrencia
            CreateMap<TipoOcorrenciaPostModel, TipoOcorrencia>();
            CreateMap<TipoOcorrencia, TipoOcorrenciaPostModel>();
            CreateMap<TipoOcorrenciaPutModel, TipoOcorrencia>();
            CreateMap<TipoOcorrencia, TipoOcorrenciaPutModel>();
            CreateMap<TipoOcorrencia, TipoOcorrenciaGetModel>();




            // FornecedorGeral
            CreateMap<FornecedorGeralPostModel, FornecedorGeral>()
                .AfterMap((model, entity) =>
                {
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraAlteracao = DateTime.Now;
                });

            CreateMap<FornecedorGeral, FornecedorGeralGetModel>();
            CreateMap<FornecedorGeral, FornecedorGeralPostModel>();
            CreateMap<FornecedorGeralPostModel, FornecedorGeral>();



            // Depositos
            CreateMap<Depositos, DepositosGetModel>();

            CreateMap<DepositosPostModel, Depositos>()
                .AfterMap((model, entity) =>
                {
                    entity.DataHoraCadastro = DateTime.Now;
                    entity.DataHoraAlteracao = DateTime.Now;
                });

            // ProdutoDeposito
            CreateMap<ProdutoDeposito, ProdutoDepositoGetModel>();
            CreateMap<ProdutoDeposito, ProdutoDepositoModel>();

            CreateMap<ProdutoDepositoGetModel, ProdutoDeposito>();
            CreateMap<ProdutoDepositoPutModel, ProdutoDeposito>()
                .ForMember(dest => dest.DepositoId, opt => opt.MapFrom(src => src.DepositoId))

                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade));
            CreateMap<ProdutoDeposito, ProdutoDepositoPutModel>()
                 .ForMember(dest => dest.DepositoId, opt => opt.MapFrom(src => src.Id))

                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade));
            CreateMap<ProdutoDepositoModel, ProdutoDeposito>();


            // loja 

            CreateMap<Loja, LojaGetModel>();
            CreateMap<Loja, LojaPostModel>();
            CreateMap<LojaGetModel, Loja>();
            CreateMap<LojaPostModel, Loja>();



            // lote

            CreateMap<Lote, LoteGetModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumeroLote, opt => opt.MapFrom(src => src.NumeroLote))
                .ForMember(dest => dest.QuantidadeLote, opt => opt.MapFrom(src => src.QuantidadeLote));

            CreateMap<LoteModel, Lote>();
            CreateMap<Lote, LoteModel>();
            CreateMap<LoteGetModel, LoteModel>();
            CreateMap<LoteGetModel, Lote>();


            CreateMap<Venda, VendaPisoGetModel>();
            CreateMap<VendaProdutoGeral, VendaProdutoGeralGetModel>();




            CreateMap<EscalaPostModel, Escala>()
               .AfterMap((model, entity) =>
               {
                   entity.DataCadastro = DateTime.Now;


               });

            CreateMap<Escala, EscalaGetModel>();
            CreateMap<EscalaGetModel, Escala>();

            CreateMap<EntregaPostModel, Entrega>()
                .AfterMap((model, entity) =>
                {
                    entity.DataCadastro = DateTime.Now;
                    entity.Ativo = true;

                });
            CreateMap<TituloReceberPostModel, TituloReceber>()
                .AfterMap((model, entity) =>
                {
                    entity.DataCadastro = DateTime.Now;
                    entity.Ativo = true;
                });
            CreateMap<TituloReceberFuncionarioPostModel, TituloReceberFuncionario>()
               .AfterMap((model, entity) =>
               {
                   entity.DataCadastro = DateTime.Now;
                   entity.Ativo = true;
               });
            CreateMap<BaixaEntregaPostModel, BaixaEntrega>()
                .AfterMap((model, entity) =>
                {
                    entity.DataTime = DateTime.Now;
                });
            CreateMap<BaixaTituloPostModel, BaixaTitulo>()
                .AfterMap((model, entity) =>
                {
                    entity.DataTime = DateTime.Now;
                });
            CreateMap<BaixaTituloFuncionarioPostModel, BaixaTituloFuncionario>()
               .AfterMap((model, entity) =>
               {
                   entity.DataTime = DateTime.Now;
               });
            CreateMap<PendenciaEntregaPostModel, PendenciaEntrega>()

                .AfterMap((model, entity) =>
                {
                    entity.DataTime = DateTime.Now;
                });
            CreateMap<ImpressaoPostModel, Impressao>()
                .AfterMap((model, entity) =>
                {
                    entity.DataTime = DateTime.Now;
                });
            CreateMap<PagamentoPostModel, Pagamento>()
               .AfterMap((model, entity) =>
               {
                   entity.DataTime = DateTime.Now;
               });
            CreateMap<EscalaPostModel, Escala>()
               .AfterMap((model, entity) =>
               {
                   entity.DataCadastro = DateTime.Now;


               });

            CreateMap<Entrega, EntregaGetModel>();
            CreateMap<EntregaGetModel, Entrega>();
            CreateMap<EntregaPutModel, Entrega>();
            CreateMap<Entrega, EntregaPutModel>();
            CreateMap<TituloReceberPutModel, TituloReceber>();
            CreateMap<TituloReceber, TituloReceberPutModel>();
            CreateMap<BaixaEntrega, BaixaEntregaGetModel>();
            CreateMap<BaixaTitulo, BaixaTituloGetModel>();
            CreateMap<PendenciaEntrega, PendenciaEntregaGetModel>();
            CreateMap<Impressao, ImpressaoGetModel>();
            CreateMap<ImpressaoGetModel, Impressao>();
            CreateMap<PagamentoGetModel, Pagamento>();
            CreateMap<Pagamento, PagamentoGetModel>();
            CreateMap<TituloReceber, TituloReceberGetModel>();
            CreateMap<TituloReceberGetModel, TituloReceber>();

            CreateMap<TituloReceberFuncionarioPutModel, TituloReceberFuncionario>();
            CreateMap<TituloReceberFuncionario, TituloReceberFuncionarioPutModel>();
            CreateMap<BaixaTituloFuncionario, BaixaTituloFuncionarioGetModel>();
            CreateMap<TituloReceberFuncionario, TituloReceberFuncionarioGetModel>();
            CreateMap<TituloReceberFuncionarioGetModel, TituloReceberFuncionario>();

            CreateMap<ProdutoAll, ProdutoAllGetModel>();
            CreateMap<ProdutoAllGetModel, ProdutoAll>();
            CreateMap<ProdutoAllPutModel, ProdutoAll>();
            CreateMap<ProdutoAll, ProdutoAllPutModel>();
            CreateMap<ProdutoAllPostModel, ProdutoAll>();
            CreateMap<ProdutoAll, ProdutoAllPostModel>();
            CreateMap<ProdutoFalta, ProdutoFaltaGetModel>();
            CreateMap<ProdutoFaltaGetModel, ProdutoFalta>();
            CreateMap<ProdutoFaltaPutModel, ProdutoFalta>();
            CreateMap<ProdutoFalta, ProdutoFaltaPutModel>();
            CreateMap<ProdutoFaltaPostModel, ProdutoFalta>();
            CreateMap<ProdutoFalta, ProdutoFaltaPostModel>();


        }


    }
}
