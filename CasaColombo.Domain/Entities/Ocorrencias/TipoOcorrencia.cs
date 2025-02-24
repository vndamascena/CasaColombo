using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Entities.Ocorrencias
{
    public class TipoOcorrencia
    {

        public int? Id { get; set; }


        public string? Nome { get; set; }
        public List<Ocorrencia>? Ocorrencia { get; set; }
    }
}
