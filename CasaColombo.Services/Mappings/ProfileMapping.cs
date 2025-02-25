﻿using AutoMapper;
using CasaColombo.Domain.Entities.Depositoss;
using CasaColombo.Domain.Entities.Fornecedores;
using CasaColombo.Domain.Entities.Lojas;
using CasaColombo.Domain.Entities.Ocorrencias;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Services.Model.Categoria;
using CasaColombo.Services.Model.Depositos;
using CasaColombo.Services.Model.Fornecedores;
using CasaColombo.Services.Model.Lojas;
using CasaColombo.Services.Model.Ocorrencias;
using CasaColombo.Services.Model.Produtos;




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

        }


    }
}
