
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
    public class BaixaEntregaMap : IEntityTypeConfiguration<BaixaEntrega>
    {
        public void Configure(EntityTypeBuilder<BaixaEntrega> builder)
        {
            builder.ToTable("BAIXAENTREGA");

            builder.HasKey(e => e.IdBaixaEntrega);

            builder.Property(e => e.IdBaixaEntrega).HasColumnName("IDBAIXAENTREGA");
            builder.Property(e => e.UsuarioId).HasColumnName("USUARIOID");
            builder.Property(e => e.EntregaId).HasColumnName("ENTREGAID");
            builder.Property(e => e.NumeroNota).HasColumnName("NUMERONOTA");
            builder.Property(e => e.NomeCliente).HasColumnName("NOMECLIENTE");
            builder.Property(e => e.Valor).HasColumnName("VALORNOTA");
            builder.Property(e => e.ImagemUrl).HasColumnName("URLIMAGEM");
            builder.Property(e => e.Observacao).HasColumnName("OBSERVACAO");
            builder.Property(e => e.DiaSemanaBaixa).HasColumnName("DIASEMANA");
            builder.Property(v => v.DataTime).HasColumnName("DATA");
            builder.Property(e => e.DataEntregaBaixa).HasColumnName("DataEntrega");
            builder.Property(e => e.DataVenda).HasColumnName("DATAVENDA");
            builder.Property(e => e.Motorista).HasColumnName("MOTORISTA");
            builder.Property(e => e.MotoristaAtual).HasColumnName("MOTORISTAATUAL");
            builder.Property(e => e.Periodo).HasColumnName("PERIODO").IsRequired();
            builder.Property(v => v.Loja).HasColumnName("LOJA");
            builder.Property(e => e.Vendedor).HasColumnName("VENDEDOR");
           

            builder.HasOne(e => e.Entrega)
                .WithMany()
                .HasForeignKey(e => e.EntregaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
