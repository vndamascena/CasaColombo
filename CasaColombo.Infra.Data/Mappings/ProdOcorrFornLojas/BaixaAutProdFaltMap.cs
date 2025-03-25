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
   internal class BaixaAutProdFaltMap : IEntityTypeConfiguration<BaixaAutProdFalt>
    {
        public void Configure(EntityTypeBuilder<BaixaAutProdFalt> builder)
        {

            builder.ToTable("BAIXAAUTPRODFALT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.NomeProduto).HasColumnName("NOMEPRODUTO").HasMaxLength(255).IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("CODIGO");
            builder.Property(p => p.CodigoFornecedor).HasColumnName("CODIGOFORNECEDOR");
            builder.Property(p => p.Loja).HasColumnName("LOJA");
            builder.Property(p => p.Observacao).HasColumnName("OBSERVACAO").IsRequired();
            builder.Property(p => p.DataSolicitacao).HasColumnName("DATASOLICITACAO");
            builder.Property(p => p.Fornecedor1).HasColumnName("FORNECEDOR1");
            builder.Property(p => p.Valor1).HasColumnName("VALOR1");
            builder.Property(p => p.Fornecedor2).HasColumnName("FORNECEDOR2");
            builder.Property(p => p.Valor2).HasColumnName("VALOR2");
            builder.Property(p => p.DataHoraBaixa).HasColumnName("DATAHORABAIXA").IsRequired();
            builder.Property(p => p.Usuario).HasColumnName("USUARIO");
            builder.Property(p => p.UsuarioAutorizador).HasColumnName("USUARIOAUTORIZADOR");
            builder.Property(p => p.UsuarioBaixa).HasColumnName("USUARIOBAIXA");
            builder.HasOne(p => p.ProdutoFalta)
                .WithMany(c => c.BaixaAutProdFalt)
                .HasForeignKey(p => p.ProdutoFaltaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
 