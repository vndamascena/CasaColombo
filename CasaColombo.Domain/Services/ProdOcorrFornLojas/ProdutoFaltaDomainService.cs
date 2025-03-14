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
    public class ProdutoFaltaDomainService : IProdutoFaltaDomainService
    {
        private readonly IProdutoFaltaRepository _produtoFaltaRepository;
        private readonly IProdutoAllRepository _produtoAllRepository;
        private readonly ILojaRepository _lojaRepository;

        public ProdutoFaltaDomainService(IProdutoFaltaRepository produtoFaltaRepository, IProdutoAllRepository produtoAllRepository, ILojaRepository lojaRepository)
        {
            _produtoFaltaRepository = produtoFaltaRepository;
            _produtoAllRepository = produtoAllRepository;
            _lojaRepository = lojaRepository;
        }

        public ProdutoFalta Atualizar(ProdutoFalta produtoFalta)
        {
           var  registro = ObterPorId(produtoFalta.Id.Value);
            if (registro != null)
                throw new ArgumentException("Produto não encontrado para edição");
            registro.Id = produtoFalta.Id;
            registro.NomeProduto = produtoFalta.NomeProduto;
            registro.CodigoFornecedor = produtoFalta.CodigoFornecedor;
            registro.Codigo = produtoFalta.Codigo;
            registro.DataHoraAlteracao = DateTime.Now;
            _produtoFaltaRepository.Update(registro);
            return registro;
        }

        public ProdutoFalta Cadastrar(ProdutoFalta produtoFalta, string nomeUsuario)
        {
            var loja = _lojaRepository.GetById(produtoFalta.LojaId);
            if (loja == null)
                throw new ArgumentException("Loja não encontrada.");

            var produtoAll = _produtoAllRepository.GetById(produtoFalta.ProdutoAllId);
            if (produtoAll == null)
                throw new ArgumentException("ProdutoAll não encontrado.");

            produtoFalta.NomeProduto = produtoAll.NomeProduto;
            produtoFalta.Codigo = produtoAll.Codigo;
            produtoFalta.CodigoFornecedor = produtoAll.CodigoFornecedor;
            produtoFalta.loja = loja.Nome;
            produtoFalta.DataHoraCadastro = DateTime.Now;
            produtoFalta.Ativo = true;

            // 🔹 Salvando o nome do usuário corretamente
            produtoFalta.Usuario = nomeUsuario;

            _produtoFaltaRepository.Add(produtoFalta);
            return produtoFalta;
        }






        public List<ProdutoFalta> Consultar()
        {
            var produtoFalta = _produtoFaltaRepository?.GetAll(true);
            if (produtoFalta == null)
                throw new ArgumentNullException("Nenhum produto encontrado para consulta");
            return _produtoFaltaRepository.GetAll(true);
        }

        public ProdutoFalta Delete(int id)
        {
            var produtoFalta = ObterPorId(id);
            if (produtoFalta != null)
            {
                produtoFalta.Ativo = false;
                _produtoFaltaRepository.Update(produtoFalta);
            }
            return produtoFalta;
        }

        public ProdutoFalta ObterPorId(int id)
        {
            return _produtoFaltaRepository.GetById(id);
        }
    }
}
