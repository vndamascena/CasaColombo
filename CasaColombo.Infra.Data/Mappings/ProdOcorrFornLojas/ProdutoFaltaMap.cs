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
    public class ProdutoFaltaMap : IEntityTypeConfiguration<ProdutoFalta>
    {
        public void Configure(EntityTypeBuilder<ProdutoFalta> builder)
        {
            builder.ToTable("PRODUTOFALTA");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.NomeProduto).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("CODIGOSISTEMA");
            builder.Property(p => p.CodigoFornecedor).HasColumnName("CODIGOFORNECEDOR");

            builder.Property(p => p.loja).HasColumnName("LOJA");
            builder.Property(p => p.observacao).HasColumnName("OBSERVACAO").IsRequired();
            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(p => p.LojaId).HasColumnName("LOJAID").IsRequired();
            builder.Property(p => p.ProdutoAllId).HasColumnName("PRODUTOALLID").IsRequired();
            builder.Property(p => p.Usuario).HasColumnName("USUARIO");

            builder.HasOne(p => p.LojaNavigation) 
               .WithMany(c => c.ProdutoFalta) 
               .HasForeignKey(p => p.LojaId) 
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProdutoAllNavigation) 
               .WithMany(f => f.ProdutoFalta) 
               .HasForeignKey(p => p.ProdutoAllId) 
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
