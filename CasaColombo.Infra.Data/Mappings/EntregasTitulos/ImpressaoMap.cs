
using CasaColombo.Domain.Entities.Entregas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.EntregasTitulos
{
    public class ImpressaoMap : IEntityTypeConfiguration<Impressao>
    {
        public void Configure(EntityTypeBuilder<Impressao> builder)
        {
            builder.ToTable("IMPRESSAO");

            builder.HasKey(e => e.IdImpressao);
         

            builder.Property(e => e.IdImpressao).HasColumnName("IDIMPRESSAO");
            builder.Property(e => e.EntregaId).HasColumnName("ENTREGAID");
            builder.Property(t => t.NumeroNota).HasColumnName("NUMERONOTA").IsRequired();
            builder.Property(t => t.NomeCliente).HasColumnName("NOMECLIENTE").HasMaxLength(50).IsRequired();
            builder.Property(e => e.UsuarioId).HasColumnName("USUARIOID");
           
            builder.Property(v => v.DataTime).HasColumnName("DATA");
           

            builder.HasOne(e => e.Entrega)
                .WithMany()
                .HasForeignKey(e => e.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
