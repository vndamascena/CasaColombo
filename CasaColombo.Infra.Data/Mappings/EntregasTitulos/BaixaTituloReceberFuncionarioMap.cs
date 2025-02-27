using CasaColombo.Domain.Entities.Titulos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.EntregasTitulos
{
    public class BaixaTituloReceberFuncionarioMap : IEntityTypeConfiguration<BaixaTituloFuncionario>
    {
        public void Configure(EntityTypeBuilder<BaixaTituloFuncionario> builder)
        {
            builder.ToTable("BAIXAETITULORECEBERFUNCIONARIO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.UsuarioId).HasColumnName("USUARIOID");
            builder.Property(e => e.TituloId).HasColumnName("ENTREGAID");
            builder.Property(e => e.NumeroNota).HasColumnName("NUMERONOTA");
            builder.Property(e => e.NomeCliente).HasColumnName("NOMECLIENTE");
            builder.Property(e => e.Valor).HasColumnName("VALORNOTA");
            builder.Property(e => e.ImagemUrl).HasColumnName("URLIMAGEM");
            builder.Property(e => e.Observacao).HasColumnName("OBSERVACAO");
            
            builder.Property(v => v.DataTime).HasColumnName("DATA");
            builder.Property(e => e.DataVenda).HasColumnName("DATAVENDA");
            builder.Property(v => v.Loja).HasColumnName("LOJA");
            builder.Property(e => e.Vendedor).HasColumnName("VENDEDOR");
            builder.Property(e => e.DataPrevistaPagamento).HasColumnName("DATAPREVPG");


            builder.HasOne(e => e.TituloReceberFuncionario)
                .WithMany()
                .HasForeignKey(e => e.TituloId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
