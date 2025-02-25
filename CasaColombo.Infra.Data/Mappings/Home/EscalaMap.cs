using CasaColombo.Domain.Entities.Home;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.Home
{
    public class EscalaMap : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            builder.ToTable("ESCALA");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.Nome).HasColumnName("NOME");

            builder.Property(t => t.ImagemUrl).HasColumnName("IMAGEMURL");

            builder.Property(o => o.DataCadastro).HasColumnName("DATACADASTRO");
        }
    }
}
