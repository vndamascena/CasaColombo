using CasaColombo.Domain.Entities.Ocorrencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Infra.Data.Mappings.ProdOcorrFornLojas
{
    internal class TipoOcorrenciaMap : IEntityTypeConfiguration<TipoOcorrencia>
    {
        public void Configure(EntityTypeBuilder<TipoOcorrencia> builder)
        {
            builder.ToTable("TIPOOCORRENCIA ");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(50);


        }

       
    }
}
