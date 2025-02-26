
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
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("PAGAMENTO");

            builder.HasKey(e => e.IdPagamento);


            builder.Property(e => e.IdPagamento).HasColumnName("IDPAGAMENTO");
            builder.Property(e => e.EntregaId).HasColumnName("ENTREGAID");
            builder.Property(t => t.NumeroNota).HasColumnName("NUMERONOTA").IsRequired();
            builder.Property(t => t.NomeCliente).HasColumnName("NOMECLIENTE").HasMaxLength(50).IsRequired();
            builder.Property(e => e.UsuarioId).HasColumnName("USUARIOID");
            builder.Property(e => e.StatusDePagamento).HasColumnName("STATUSDEPAGAMENTO");

            builder.Property(v => v.DataTime).HasColumnName("DATA");


            builder.HasOne(e => e.Entrega)
                .WithMany()
                .HasForeignKey(e => e.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
