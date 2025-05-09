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
    internal class ProdutoPisoMap : IEntityTypeConfiguration<ProdutoPiso>
    {
        public void Configure(EntityTypeBuilder<ProdutoPiso> builder)
        {
            builder.ToTable("PRODUTOPISO");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");

            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();

            builder.Property(p => p.Marca).HasColumnName("MARCA").HasMaxLength(50);

            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE");

            builder.Property(p => p.Pei).HasColumnName("PEI").HasMaxLength(15);

            builder.Property(p => p.PrecoCaixa).HasColumnName("PRECOCAIXA");

            builder.Property(p => p.PrecoMetroQ).HasColumnName("PRECOMETRO");

            builder.Property(p => p.MetroQCaixa).HasColumnName("MERTROQCAIXA");

            builder.Property(p => p.PecasCaixa).HasColumnName("PECASCAIXA");

            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").HasMaxLength(70).IsRequired();

            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();

            builder.Property(p => p.CategoriaId).HasColumnName("CATEGORIAID").IsRequired();

            builder.Property(p => p.FornecedorId).HasColumnName("FORNECEDORID").IsRequired();

            builder.Property(p => p.DepositoId).HasColumnName("DEPOSITOID").IsRequired();

            builder.Property(p => p.ImagemUrl).HasColumnName("IMAGEMURL");



            #region Relacionamentos

            builder.HasOne(p => p.Categoria) //Produto TEM 1 Categoria
                .WithMany(c => c.ProdutosPiso) //Categoria TEM N Produtos
                .HasForeignKey(p => p.CategoriaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Fornecedor) //Produto TEM 1 Fornecedor
               .WithMany(f => f.ProdutosPiso) //Fornecedor TEM N Produtos
               .HasForeignKey(p => p.FornecedorId) //Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Depositos) //Produto TEM 1 Deposito
               .WithMany(f => f.ProdutoPiso) //Deposito TEM N Produtos
               .HasForeignKey(p => p.DepositoId) //Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict);


            #endregion

        }
    }
}
