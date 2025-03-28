﻿using CasaColombo.Domain.Entities.Produtos;
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
            builder.Property(p => p.Observacao).HasColumnName("OBSERVACAO").IsRequired();
            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(p => p.LojaId).HasColumnName("LOJAID").IsRequired();
            builder.Property(p => p.ProdutoAllId).HasColumnName("PRODUTOALLID").IsRequired();
            builder.Property(p => p.Usuario).HasColumnName("USUARIO");
            builder.Property(p => p.DataSolicitacao).HasColumnName("DATASOLICITACAO");
            builder.Property(p => p.Fornecedor1).HasColumnName("FORNECEDOR1");
            builder.Property(p => p.Valor1).HasColumnName("VALOR1");
            builder.Property(p => p.Fornecedor2).HasColumnName("FORNECEDOR2");
            builder.Property(p => p.Valor2).HasColumnName("VALOR2");
            builder.Property(p => p.UsuarioAutorizador).HasColumnName("USUARIOAUTORIZADOR");


            builder.HasOne(p => p.LojaNavigation) 
               .WithMany(c => c.ProdutoFalta) 
               .HasForeignKey(p => p.LojaId) 
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProdutoAllNavigation) 
               .WithMany(f => f.ProdutoFalta) 
               .HasForeignKey(p => p.ProdutoAllId) 
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
