using CasaColombo.Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.ProdOcorrFornLojas
{
    public class FornecProdFaltMap : IEntityTypeConfiguration<FornecProdFalt>
    {
        public void Configure(EntityTypeBuilder<FornecProdFalt> builder)
        {


            builder.ToTable("FORNECPRODFALT");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("ID");
            builder.Property(f => f.NomeProduto).HasColumnName("NOMEPRODUTO").HasMaxLength(100);
            builder.Property(f => f.Nome).HasColumnName("NOME").HasMaxLength(100);
            builder.Property(f => f.Valor).HasColumnName("VALOR").HasMaxLength(100);
            builder.Property(f => f.Quantidade).HasColumnName("QUANTIDADE");
            builder.Property(f => f.DataEntrada).HasColumnName("DATAENTRADA");
            builder.Property(p => p.FornecedorGeralId).HasColumnName("FORNECEDORID").IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("CODIGONUMERO");
            builder.Property(f => f.ProdutoFaltaId).HasColumnName("ProdutoFaltaId");
            builder.Property(p => p.UsuarioAutorizador).HasColumnName("USUARIOAUTORIZADOR");
            builder.Property(p => p.DataHoraAutorizacao).HasColumnName("DATAHORAALTERACAO").IsRequired();


            builder.HasOne(f => f.ProdutoFalta)
             .WithMany(p => p.FornecProdFalt)
             .HasForeignKey(f => f.ProdutoFaltaId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Fornecedor) //Produto TEM 1 Fornecedor
               .WithMany(f => f.FornecProdFalt) //Fornecedor TEM N Produtos
               .HasForeignKey(p => p.FornecedorGeralId) //Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
