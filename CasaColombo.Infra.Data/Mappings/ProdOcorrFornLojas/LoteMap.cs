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
    public class LoteMap : IEntityTypeConfiguration<Lote>
    {

        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("LOTE");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("ID");

            builder.Property(p => p.Codigo).HasColumnName("CODIGO").HasMaxLength(5);
            builder.Property(v => v.UsuarioId).HasColumnName("USUARIOID").IsRequired();

            builder.Property(l => l.NumeroLote).HasColumnName("NUMERO LOTE").HasMaxLength(10);

            builder.Property(l => l.QuantidadeLote).HasColumnName("QUANTIDADE");
            builder.Property(l => l.Ativo).HasColumnName("ATIVO").IsRequired();

            builder.Property(l => l.Ala).HasColumnName("ALA");
            builder.Property(v => v.Marca).HasColumnName("MARCA");
            builder.Property(l => l.NomeProduto).HasColumnName("NOMEPRODUTO");

            builder.Property(l => l.QtdEntrada).HasColumnName("QTDENTRADA");
            builder.Property(l => l.DataUltimaAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Property(l => l.ProdutoPisoId).HasColumnName("PRODUTOID").IsRequired();
            builder.Property(l => l.DataEntrada).HasColumnName("DATAENTRADA").IsRequired();

            builder.HasOne(p => p.ProdutoPiso) //LOTE TEM 1 PRODUTO
                   .WithMany(f => f.Lote) //PRODUTO TEM N LOTES
                   .HasForeignKey(p => p.ProdutoPisoId) //Chave estrangeira
                   .OnDelete(DeleteBehavior.Cascade); // Excluir em cascata


        }
    }
}
