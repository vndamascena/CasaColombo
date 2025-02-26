
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaColombo.Domain.Entities.Entregas;

namespace EntregaTitulo.Infra.Data.Mappings
{
    public class PendenciaEntregaMap : IEntityTypeConfiguration<PendenciaEntrega>
    {
        public void Configure(EntityTypeBuilder<PendenciaEntrega> builder)
        {
            builder.ToTable("PENDENCIAENTREGA");

            builder.HasKey(e => e.IdPendencia);

            builder.Property(e => e.IdPendencia).HasColumnName("IDPENDENCIA");
            builder.Property(e => e.UsuarioId).HasColumnName("USUARIOID");
            builder.Property(e => e.EntregaId).HasColumnName("ENTREGAID");
            builder.Property(e => e.NumeroNota).HasColumnName("NUMERONOTA");
            builder.Property(e => e.NomeCliente).HasColumnName("NOMECLIENTE");
            builder.Property(e => e.Valor).HasColumnName("VALORNOTA");
            builder.Property(e => e.ImagemUrl).HasColumnName("URLIMAGEM");
            builder.Property(e => e.Observacao).HasColumnName("OBSERVACAO");
            builder.Property(v => v.DataTime).HasColumnName("DATA");
            builder.Property(e => e.DiaSemana).HasColumnName("DIASEMANA");
            builder.Property(e => e.DataEntrega).HasColumnName("DataEntrega");
            builder.Property(e => e.DataVenda).HasColumnName("DATAVENDA");
            builder.Property(e => e.Motorista).HasColumnName("MOTORISTA");
            builder.Property(e => e.MotoristaAtual).HasColumnName("MOTORISTAATUAL");
            builder.Property(e => e.Periodo).HasColumnName("PERIODO").IsRequired();
            builder.Property(e => e.Vendedor).HasColumnName("VENDEDOR");
            builder.Property(v => v.ObservacaoPendencia).HasColumnName("OBSERVACAOPENDENCIA");
            builder.Property(v => v.DataEntregaProximaEntrega).HasColumnName("DIASEMANAPENDENCIA");
            builder.Property(v => v.DiaSemanaPendencia).HasColumnName("PROXIMAENTREGA");
            builder.Property(v => v.Loja).HasColumnName("LOJA");
            

            builder.HasOne(e => e.Entrega)
                .WithMany()
                .HasForeignKey(e => e.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
