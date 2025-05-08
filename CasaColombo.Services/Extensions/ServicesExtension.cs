using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Domain.Services.ProdOcorrFornLojas;
using CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas;
using CasaColombo.Infra.Data.Repositories;
using CasaColombo.Domain.Interfaces.Repositories.IHome;
using CasaColombo.Domain.Interfaces.Services.IHome;
using CasaColombo.Domain.Services.Home;
using CasaColombo.Infra.Data.Repositories.Home;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Domain.Interfaces.Services.IEntregasTitulos;
using CasaColombo.Domain.Services.EntregaTitulos;
using CasaColombo.Infra.Data.Repositories.EntregasTitulos;
using EntregaTitulo.Infra.Data.Repositories;

namespace CasaColombo.Services.Extensions
{
    public class ServicesExtension
    {
        public static void AddServicesConfig(IServiceCollection services)
        {

            services.AddTransient<ICategoriaDomainService, CategoriaDomainService>();
            services.AddTransient<IProdutoPisoDomainService, ProdutoPisoDomainService>();
            services.AddTransient<IFornecedorGeralDomainService, FornecedorGeralDomainService>();

            services.AddTransient<IDepositosDomainService, DepositosDomainService>();
            services.AddTransient<IOcorrenciaDomainService, OcorrenciaDomainService>();
            services.AddTransient<ITipoOcorrenciaDomainService, TipoOcorrenciaDomainService>();
            services.AddTransient<ILojaDomainService, LojaDomainService>();
            services.AddTransient<IProdutoGeralDomainService, ProdutoGeralDomainService>();


            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoPisoRepository, ProdutoPisoRepository>();
            services.AddTransient<IVendaProdutoGeralRepository, VendaProdutoGeralRepository>();
            services.AddTransient<IDepositosRepository, DepositosRepository>();
            services.AddTransient<ILoteRepository, LoteRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();
            services.AddTransient<ITipoOcorrenciaRepository, TipoOcorrenciaRepository>();
            services.AddTransient<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddTransient<IBaixaOcorrenciaRepository, BaixaOcorrenciaRepository>();
            services.AddTransient<IFornecedorGeralRepository, FornecedorGeralRepository>();
            services.AddTransient<ILojaRepository, LojaRepository>();
            services.AddTransient<IProdutoGeralRepository, ProdutoGeralRepository>();

            services.AddTransient<IProdutoDepositoRepository, ProdutoDepositoRepository>();

            services.AddTransient<IEscalaRepository, EscalaRepository>();
            services.AddTransient<IHomeDomainService, HomeDomainService>();
            services.AddTransient<IEntregaDomainService, EntregaDomainService>();
            services.AddTransient<IEntregaRepository, EntregaRepository>();
            services.AddTransient<IPendenciaEntregaRepository, PendenciaEntregaRepository>();
            services.AddTransient<ITituloReceberDomainService, TituloReceberDomainService>();
            services.AddTransient<IBaixaTituloRepository, BaixaTituloRepository>();
            services.AddTransient<ITituloReceberRepository, TituloReceberRepository>();
            services.AddTransient<IBaixaEntregaRepository, BaixaEntregaRepository>();
            services.AddTransient<IImpressaoRepository, ImpressaoRepository>();
            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            services.AddTransient<ITituloReceberFuncionarioDomainService, TituloReceberFuncionarioDomainService>();
            services.AddTransient<IBaixaTituloFuncionarioRepository, BaixaTituloFuncionarioRepository>();
            services.AddTransient<ITituloReceberFuncionarioRespository, TituloReceberFuncionarioRepository>();
            services.AddTransient<IProdutoAllDomainService, ProdutoAllDomainService>();
            services.AddTransient<IProdutoAllRepository, ProdutoAllRepository>();
            services.AddTransient<IProdutoFaltaRepository, ProdutoFaltaRepository>();
            services.AddTransient<IProdutoFaltaDomainService, ProdutoFaltaDomainService>();
            services.AddTransient<IBaixaAutProdFaltRepository, BaixaAutProdFaltRepository>();
            services.AddTransient<IFornecedorGeralRepository, FornecedorGeralRepository>();
            services.AddTransient<IFornecProdFaltRepository, FornecProdFaltRepository>();


        }
    }
}
