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
    public class ProdutoAllMap : IEntityTypeConfiguration<ProdutoAll>
    {
        public void Configure(EntityTypeBuilder<ProdutoAll> builder)
        {
            builder.ToTable("PRODUTOALL");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.NomeProduto).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("CODIGOSISTEMA");
            builder.Property(p => p.CodigoFornecedor).HasColumnName("CODIGOFORNECEDOR");

            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.HasIndex(p => p.Codigo).IsUnique();

        }
    }
}
