using CasaColombo.Domain.Entities.Ocorrencias;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Services.ProdOcorrFornLojas
{
    public class ProdutoAllDomainService : IProdutoAllDomainService
    {
        private readonly IProdutoAllRepository? _produtoAllRepository;

        public ProdutoAllDomainService(IProdutoAllRepository? produtoAllRepository)
        {
            _produtoAllRepository = produtoAllRepository;
        }
        public ProdutoAll Atualizar(ProdutoAll produtoAll)
        {
            var registro = ObterPorId(produtoAll.Id.Value);

            if (registro != null)
            
                throw new ArgumentException("Produto não encontrado para edição");

                registro.Id = produtoAll.Id;
                registro.NomeProduto = produtoAll.NomeProduto;
                registro.CodigoFornecedor = produtoAll.CodigoFornecedor;
                registro.Codigo = produtoAll.Codigo;
                registro.DataHoraAlteracao = DateTime.Now;


            _produtoAllRepository?.Update(registro);

            return registro;
        }

        public ProdutoAll Cadastrar(ProdutoAll produtoAll)
        {
            produtoAll.Ativo = true;
            _produtoAllRepository?.Add(produtoAll);
            produtoAll = _produtoAllRepository?.GetById(produtoAll.Id.Value);
            return produtoAll;


           
        }

        public List<ProdutoAll> Consultar()
        {
            return _produtoAllRepository?.GetAll(true);

        }

        public ProdutoAll Delete(int id)
        {
            var produtoAll = ObterPorId(id);
            if (produtoAll == null)
                throw new ArgumentNullException("Produto não encontrado para exclusão");

            _produtoAllRepository?.Delete(produtoAll);
            return produtoAll;
        }

        public ProdutoAll GetByCodigo(string codigo)
        {
            string codigoSemZeros = codigo.TrimStart('0');
            return _produtoAllRepository?.GetByCodigo(codigoSemZeros);
        }

        public ProdutoAll ObterPorId(int id)
        {
            return _produtoAllRepository?.GetById(id);
        }

        public void UploadCadastrar(string codigo, string nomeProduto)
        {
           
            // Verifica se o produto já existe pelo código
            var produtoExistente = _produtoAllRepository?.GetByCodigo(codigo);

            if (produtoExistente != null)
            {
                throw new ApplicationException("Produto já cadastrado com esse código.");
            }

            // Criar um novo produto
            var novoProduto = new ProdutoAll
            {
                Codigo = codigo,
                NomeProduto = nomeProduto,
                Ativo = true,
                DataHoraAlteracao = DateTime.Now,
                DataHoraCadastro = DateTime.Now
            };

            // Cadastrar o produto no banco
            _produtoAllRepository?.Add(novoProduto);
        }

    }
}
