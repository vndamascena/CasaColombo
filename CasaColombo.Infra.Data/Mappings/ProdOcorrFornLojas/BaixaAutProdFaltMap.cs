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
            builder.Property(p => p.Loja2).HasColumnName("LOJA2");
            builder.Property(p => p.Loja3).HasColumnName("LOJA3");
            builder.Property(p => p.Loja4).HasColumnName("LOJA4");
            builder.Property(p => p.Observacao).HasColumnName("OBSERVACAO").IsRequired();
            builder.Property(p => p.Fornecedor).HasColumnName("FORNECEDOR");
            builder.Property(p => p.Valor).HasColumnName("VALOR");
            builder.Property(p => p.DataHoraBaixa).HasColumnName("DATAHORABAIXA").IsRequired();
            builder.Property(p => p.Usuario).HasColumnName("USUARIO");
            builder.Property(p => p.UsuarioAutorizador).HasColumnName("USUARIOAUTORIZADOR");
            builder.Property(p => p.UsuarioBaixa).HasColumnName("USUARIOBAIXA");
            builder.Property(p => p.JC1Recebido).HasColumnName("JC1RECEBIDO").IsRequired();
            builder.Property(p => p.JC2Recebido).HasColumnName("JC2RECEBIDO").IsRequired();
            builder.Property(p => p.VARecebido).HasColumnName("VARECEBIDO").IsRequired();
            builder.Property(p => p.CLRecebido).HasColumnName("CLRECEBIDO").IsRequired();
            builder.Property(f => f.Quantidade).HasColumnName("QUANTIDADE");
            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();
            builder.Property(p => p.DataSolicitacao).HasColumnName("DATASOLICITACAO");
            builder.HasOne(p => p.ProdutoFalta)
                .WithMany(c => c.BaixaAutProdFalt)
                .HasForeignKey(p => p.ProdutoFaltaId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
 