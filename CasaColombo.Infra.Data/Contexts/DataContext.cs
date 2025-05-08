using CasaColombo.Infra.Data.Mappings;
using CasaColombo.Infra.Data.Mappings.EntregasTitulos;
using CasaColombo.Infra.Data.Mappings.Home;
using CasaColombo.Infra.Data.Mappings.ProdOcorrFornLojas;
using EntregaTitulo.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Substitua a string de conexão padrão pelo MySQL
            optionsBuilder.UseSqlServer(@"Data Source=SQL8010.site4now.net;Initial Catalog=db_aa8a78_casacol;User Id=db_aa8a78_casacol_admin;Password=colombo24");
                                          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoPisoMap());
            modelBuilder.ApplyConfiguration(new DepositosMap());
            modelBuilder.ApplyConfiguration(new DepositosMap());
            modelBuilder.ApplyConfiguration(new LoteMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new VendaProdutoGeralMap());
            modelBuilder.ApplyConfiguration(new ProdutoDepositoMap());
            modelBuilder.ApplyConfiguration(new FornecedorGeralMap());
            modelBuilder.ApplyConfiguration(new TipoOcorrenciaMap());
            modelBuilder.ApplyConfiguration(new OcorrenciaMap());
            modelBuilder.ApplyConfiguration(new BaixaOcorrenciamMap());
            modelBuilder.ApplyConfiguration(new ProdutoGeralMap());
            modelBuilder.ApplyConfiguration(new ProdutoAllMap());
            modelBuilder.ApplyConfiguration(new ProdutoFaltaMap());
            modelBuilder.ApplyConfiguration(new BaixaAutProdFaltMap());
            modelBuilder.ApplyConfiguration(new FornecProdFaltMap());

        }


    }


    public class DataContextSecundaria : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Substitua a string de conexão padrão pelo MySQL
            optionsBuilder.UseSqlServer(@"Data Source=SQL8020.site4now.net;Initial Catalog=db_aa8a78_entrega;User Id=db_aa8a78_entrega_admin;Password=colombo24");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntregaMap());
            modelBuilder.ApplyConfiguration(new PendenciaEntregaMap());
            modelBuilder.ApplyConfiguration(new BaixaEntregaMap());
            modelBuilder.ApplyConfiguration(new ImpressaoMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
            modelBuilder.ApplyConfiguration(new BaixaTituloReceberMap());
            modelBuilder.ApplyConfiguration(new TituloReceberMap());
            modelBuilder.ApplyConfiguration(new TituloReceberFuncionarioMap());
            modelBuilder.ApplyConfiguration(new EscalaMap());

        }
    }
}
