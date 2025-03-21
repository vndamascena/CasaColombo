﻿using CasaColombo.Domain.Entities.Depositoss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.ProdOcorrFornLojas
{
    public class DepositosMap : IEntityTypeConfiguration<Depositos>
    {
        public void Configure(EntityTypeBuilder<Depositos> builder)
        {

            builder.ToTable("DEPOSITOS");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("ID");

            builder.Property(f => f.Nome).HasColumnName("NOME").HasMaxLength(15).IsRequired();

            builder.Property(p => p.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();

            builder.Property(p => p.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();


            


            
        }
    }
}
