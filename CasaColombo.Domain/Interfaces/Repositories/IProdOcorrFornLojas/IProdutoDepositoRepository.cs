﻿using CasaColombo.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas
{
    public interface IProdutoDepositoRepository : IBaseRepository<ProdutoDeposito, int>
    {
        // Aqui você pode adicionar métodos específicos para ProdutoDeposito, se necessário
        List<ProdutoDeposito> GetByProdutoGeralId(int produtoGeralId);
        ProdutoDeposito ObterPorId(int id);
        ProdutoDeposito ObterPorIdProduto(int idDeposito, int idPrododuto);
        ProdutoDeposito ObterPorCodigoSistema(string codigoSistema);
        ProdutoDeposito ObterPorCodigoSistemaEDeposito(string codigoSistema, string deposito);
        ProdutoDeposito ObterId(int id);


    }
}
