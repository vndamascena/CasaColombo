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
        private readonly IBaixaAutProdFaltRepository _BaixaAutProdFaltRepository;
        private readonly ILojaRepository _lojaRepository;

        public ProdutoFaltaDomainService(IProdutoFaltaRepository produtoFaltaRepository, IProdutoAllRepository produtoAllRepository, ILojaRepository lojaRepository
            , IBaixaAutProdFaltRepository baixaAutProdFaltRepository)
        {
            _produtoFaltaRepository = produtoFaltaRepository;
            _produtoAllRepository = produtoAllRepository;
            _lojaRepository = lojaRepository;
            _BaixaAutProdFaltRepository = baixaAutProdFaltRepository;
        }

        public ProdutoFalta Atualizar(ProdutoFalta produtoFalta)
        {
           var  registro = ObterPorId(produtoFalta.Id.Value);
            if (registro != null)
                throw new ArgumentException("Produto não encontrado para edição");
            registro.Id = registro.Id;
            registro.NomeProduto = registro.NomeProduto;
            registro.CodigoFornecedor = produtoFalta.CodigoFornecedor;
            registro.Codigo = registro.Codigo;
            registro.DataHoraAlteracao = DateTime.Now;
            registro.DataSolicitacao = produtoFalta.DataSolicitacao;
            registro.Fornecedor1 = produtoFalta.Fornecedor1;
            registro.Valor1 = produtoFalta.Valor1;
            registro.Fornecedor2 = produtoFalta.Fornecedor2;
            registro.Valor2 = produtoFalta.Valor2;
            registro.Observacao = produtoFalta.Observacao;
            registro.Loja = registro.Loja;
            registro.Usuario = registro.Usuario;
            registro.UsuarioAutorizador = produtoFalta.UsuarioAutorizador;
            _produtoFaltaRepository.Update(registro);
            return registro;
        }

        public BaixaAutProdFalt ConfirmarBaixa(int id, string nomeUsuario)
        {
            var produtoFalta = ObterPorId(id);
            if (produtoFalta == null)
            {
                throw new ApplicationException("Lote não encontrado.");
            }
          var baixa = new BaixaAutProdFalt
          {
              ProdutoFaltaId = produtoFalta.Id.Value,
              DataHoraBaixa = DateTime.Now,
              Usuario = produtoFalta.Usuario,
              Valor1 = produtoFalta.Valor1,
              Valor2 = produtoFalta.Valor2,
              Fornecedor1 = produtoFalta.Fornecedor1,
              Fornecedor2 = produtoFalta.Fornecedor2,
              UsuarioAutorizador = produtoFalta.UsuarioAutorizador,
              Codigo = produtoFalta.Codigo,
              CodigoFornecedor = produtoFalta.CodigoFornecedor,
              DataSolicitacao = produtoFalta.DataSolicitacao,
              Loja = produtoFalta.Loja,
              NomeProduto = produtoFalta.NomeProduto,
              Observacao = produtoFalta.Observacao,
              UsuarioBaixa = nomeUsuario



          };

            _BaixaAutProdFaltRepository.Add(baixa);
            produtoFalta.Ativo = false;
            _produtoFaltaRepository.Update(produtoFalta);

            return baixa;
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
            produtoFalta.Loja = loja.Nome;
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
            return produtoFalta.Where(p =>p.Ativo).ToList();
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
            var produto = _produtoFaltaRepository.GetById(id);

            if (produto == null || !produto.Ativo)
            {
                throw new ApplicationException("Produto não encontrado ou inativo.");
            }

            return produto;
        }

        public BaixaAutProdFalt ConsultarPorId(int id)
        {

            var baixa = _BaixaAutProdFaltRepository.GetById(id);
            if (baixa == null)
                throw new ArgumentException("Baixa não encontrada");
            return baixa;
        }

        public List<BaixaAutProdFalt> ConsultarBaixaAll()
        {

            var baixa = _BaixaAutProdFaltRepository.GetAll();
            if (baixa == null)
                throw new ArgumentException("Baixa não encontrada");
            return baixa;
        }
    }
}
