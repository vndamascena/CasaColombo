using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IFornecProdFaltRepository : IBaseRepository<FornecProdFalt, int>
    {
        List<FornecProdFalt> GetAll(bool ativo);
        FornecProdFalt ObterPorId(int id);
        void Remover(int id);
    }
}
