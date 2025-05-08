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
    public class ProdutoFaltaMap : IEntityTypeConfiguration<ProdutoFalta>
    {
        public void Configure(EntityTypeBuilder<ProdutoFalta> builder)
        {
            builder.ToTable("PRODUTOFALTA");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.NomeProduto).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("CODIGOSISTEMA");
            builder.Property(p => p.CodigoFornecedor).HasColumnName("CODIGOFORNECEDOR");
            builder.Property(p => p.Loja).HasColumnName("LOJA");
            builder.Property(p => p.Loja2).HasColumnName("LOJA2");
            builder.Property(p => p.Loja3).HasColumnName("LOJA3");
            builder.Property(p => p.Loja4).HasColumnName("LOJA4");
            builder.Property(p => p.Observacao).HasColumnName("OBSERVACAO").IsRequired();
            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(p => p.JC1Recebido).HasColumnName("JC1RECEBIDO").IsRequired();
            builder.Property(p => p.JC2Recebido).HasColumnName("JC2RECEBIDO").IsRequired();
            builder.Property(p => p.VARecebido).HasColumnName("VARECEBIDO").IsRequired();
            builder.Property(p => p.CLRecebido).HasColumnName("CLRECEBIDO").IsRequired();
            builder.Property(p => p.LojaId).HasColumnName("LOJAID").IsRequired();
            builder.Property(p => p.Usuario).HasColumnName("USUARIO");
            builder.Property(p => p.DataSolicitacao).HasColumnName("DATASOLICITACAO");
            builder.Property(p => p.SeparadoJC1).HasColumnName("SEPARADOJC1");
            builder.Property(p => p.SeparadoJC2).HasColumnName("SEPARADOJC2");
            builder.Property(p => p.SeparadoVA).HasColumnName("SEPARADOVA");
            builder.Property(p => p.SeparadoCL).HasColumnName("SEPARADOCL");




            builder.HasOne(p => p.LojaNavigation) 
               .WithMany(c => c.ProdutoFalta) 
               .HasForeignKey(p => p.LojaId) 
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProdutoAllNavigation)
               .WithMany(f => f.ProdutoFalta)
               .HasPrincipalKey(f => f.Codigo) // <- diz que o lado principal é o CODIGOSISTEMA
               .HasForeignKey(p => p.Codigo)   // <- o lado dependente é o CODIGO do ProdutoFalta
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
