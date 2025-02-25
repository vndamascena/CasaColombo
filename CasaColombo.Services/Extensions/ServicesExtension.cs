using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Domain.Services.ProdOcorrFornLojas;
using CasaColombo.Infra.Data.Repositories.ProdOcorrFornLojas;
using CasaColombo.Infra.Data.Repositories;

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

        }
    }
}
