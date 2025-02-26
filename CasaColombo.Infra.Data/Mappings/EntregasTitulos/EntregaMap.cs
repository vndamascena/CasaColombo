
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
    public class EntregaMap : IEntityTypeConfiguration<Entrega>
    {
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {
            builder.ToTable("ENTREGA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.NumeroNota).HasColumnName("NUMERONOTA").IsRequired();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();

            builder.Property(t => t.NomeCliente).HasColumnName("NOMECLIENTE").HasMaxLength(50).IsRequired();

            builder.Property(t => t.Valor).HasColumnName("VALOR");

            builder.Property(t => t.UsuarioId).HasColumnName("USUARIOID");

            builder.Property(t => t.ImagemUrl).HasColumnName("IMAGEMURL");

            builder.Property(o => o.Observacao).HasColumnName("OBSERVACAO");

            builder.Property(e => e.DiaSemana).HasColumnName("DIASEMANA").IsRequired();

            builder.Property(e => e.DataEntrega).HasColumnName("DataEntrega");
            builder.Property(e => e.DataVenda).HasColumnName("DATAVENDA");
            builder.Property(e => e.Periodo).HasColumnName("PERIODO").IsRequired();

            builder.Property(e => e.Vendedor).HasColumnName("VENDEDOR");

            builder.Property(e => e.Motorista).HasColumnName("MOTORISTA");
            builder.Property(e => e.MotoristaAtual).HasColumnName("MOTORISTAATUAL");
            builder.Property(v => v.Loja).HasColumnName("LOJA");
            builder.Property(o => o.DataCadastro).HasColumnName("DATA");
            builder.Property(t => t.UsuarioIdAtualizador).HasColumnName("USUARIOIDATUALIZADOR");
            builder.Property(o => o.DataAtualizacao).HasColumnName("DATAATUALIZACAO");

        }
    }
}
