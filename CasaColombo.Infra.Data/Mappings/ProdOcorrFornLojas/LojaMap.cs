using CasaColombo.Domain.Entities.Lojas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.ProdOcorrFornLojas
{
    public class LojaMap: IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("LOJA");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("ID");

            builder.Property(f => f.Nome).HasColumnName("NOME").HasMaxLength(15).IsRequired();
           

        }
    }
}
