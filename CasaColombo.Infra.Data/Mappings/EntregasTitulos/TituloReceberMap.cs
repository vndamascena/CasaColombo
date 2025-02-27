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
    public class TituloReceberMap : IEntityTypeConfiguration<TituloReceber>
    {
        public void Configure(EntityTypeBuilder<TituloReceber> builder)
        {
            builder.ToTable("TITULORECEBER");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.NumeroNota).HasColumnName("NUMERONOTA").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(t => t.NomeCliente).HasColumnName("NOMECLIENTE").HasMaxLength(50).IsRequired();
            builder.Property(t => t.Valor).HasColumnName("VALOR");
            builder.Property(t => t.UsuarioId).HasColumnName("USUARIOID");
            builder.Property(t => t.ImagemUrl).HasColumnName("IMAGEMURL");
            builder.Property(o => o.Observacao).HasColumnName("OBSERVACAO");
            builder.Property(o => o.Telefone).HasColumnName("TELEFONE");
            builder.Property(v => v.Loja).HasColumnName("LOJA");
            builder.Property(e => e.Vendedor).HasColumnName("VENDEDOR");
            builder.Property(e => e.DataVenda).HasColumnName("DATAVENDA");
            builder.Property(o => o.DataCadastro).HasColumnName("DATACADASTRO");
            builder.Property(o => o.DataAlteracao).HasColumnName("DATAALTERACAO");
            builder.Property(t => t.UsuarioIdAtualizador).HasColumnName("USUARIOIDATUALIZADOR");
            builder.Property(e => e.DataPrevistaPagamento).HasColumnName("DATAPREVPG");
        }
    }
}
