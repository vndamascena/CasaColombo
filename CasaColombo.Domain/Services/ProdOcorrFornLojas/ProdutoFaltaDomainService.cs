using CasaColombo.Domain.Entities.Lojas;
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
        private readonly IFornecedorGeralRepository _fornecedorGeralRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly IFornecProdFaltRepository _fornecProdFaltRepository;


        public ProdutoFaltaDomainService(IProdutoFaltaRepository produtoFaltaRepository, IProdutoAllRepository produtoAllRepository, ILojaRepository lojaRepository
            , IBaixaAutProdFaltRepository baixaAutProdFaltRepository, IFornecedorGeralRepository fornecedorGeralRepository, IFornecProdFaltRepository fornecProdFalt)
        {
            _produtoFaltaRepository = produtoFaltaRepository;
            _produtoAllRepository = produtoAllRepository;
            _lojaRepository = lojaRepository;
            _BaixaAutProdFaltRepository = baixaAutProdFaltRepository;
            _fornecedorGeralRepository = fornecedorGeralRepository;
            _fornecProdFaltRepository = fornecProdFalt;

        }

        public ProdutoFalta Atualizar(ProdutoFalta produtoFalta)
        {
            var registro = ProdutoObterPorId(produtoFalta.Id.Value);
            if (registro == null)
                throw new ArgumentException("Produto não encontrado para edição");
            registro.Id = registro.Id;
            registro.NomeProduto = registro.NomeProduto;
            registro.CodigoFornecedor = registro.CodigoFornecedor;
            registro.Codigo = registro.Codigo;
            registro.JC1Recebido = registro.JC1Recebido;
            registro.JC2Recebido = registro.JC2Recebido;
            registro.VARecebido = registro.VARecebido;
            registro.CLRecebido = registro.CLRecebido;
            registro.DataSolicitacao = DateTime.Now;

            registro.Observacao = registro.Observacao;
            registro.Loja = registro.Loja;
            registro.Usuario = registro.Usuario;

            _produtoFaltaRepository.Update(registro);
            return registro;
        }

        public BaixaAutProdFalt ConfirmarBaixa(int id, string nomeUsuario)
        {
            var produtoFalta = ProdutoObterPorId(id)
                ?? throw new ApplicationException("Produto não encontrado.");

            var fornecedorAutorizado = ConsultarFornecAll(id)
                .FirstOrDefault(f => !string.IsNullOrWhiteSpace(f.UsuarioAutorizador));

            var baixa = new BaixaAutProdFalt
            {
                ProdutoFaltaId = produtoFalta.Id.Value,
                DataHoraBaixa = DateTime.Now,
                Usuario = produtoFalta.Usuario,
                Codigo = produtoFalta.Codigo,
                CodigoFornecedor = produtoFalta.CodigoFornecedor,
                DataHoraCadastro = produtoFalta.DataHoraCadastro,
                Loja = produtoFalta.Loja,
                Loja2 = produtoFalta.Loja2,
                Loja3 = produtoFalta.Loja3,
                Loja4 = produtoFalta.Loja4,
                NomeProduto = produtoFalta.NomeProduto,
                Observacao = produtoFalta.Observacao,
                JC1Recebido = produtoFalta.JC1Recebido,
                JC2Recebido = produtoFalta.JC2Recebido,
                VARecebido = produtoFalta.VARecebido,
                CLRecebido = produtoFalta.CLRecebido,
                UsuarioAutorizador = fornecedorAutorizado?.UsuarioAutorizador,
                DataSolicitacao = produtoFalta.DataSolicitacao,
                Fornecedor = fornecedorAutorizado?.Nome,
                Valor = fornecedorAutorizado?.Valor,
                Quantidade = fornecedorAutorizado?.Quantidade,
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

            ProdutoAll? produtoAll = null;

            // Buscar pelo código no ProdutoAll, se existir
            if (produtoFalta.Codigo.HasValue)
            {
                produtoAll = _produtoAllRepository.GetByCodigo(produtoFalta.Codigo.Value);
            }

            if (produtoAll != null)
            {
                produtoFalta.NomeProduto = produtoAll.NomeProduto;
                produtoFalta.Codigo = produtoAll.Codigo;
                produtoFalta.CodigoFornecedor = produtoAll.CodigoFornecedor;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(produtoFalta.NomeProduto))
                    throw new ArgumentException("Nome do produto deve ser informado se o código não existir.");

                produtoFalta.CodigoFornecedor = null;
                produtoFalta.Codigo = null;
            }

            // >>> AQUI: Verificar se já existe produto com mesmo Nome ou Código
            var todosProdutos = _produtoFaltaRepository.GetAll(); // ou .ListAll() dependendo do seu repositório

            foreach (var produtoExistente in todosProdutos)
            {
                // Ignora produtos inativos
                if (!produtoExistente.Ativo)
                    continue;

                bool mesmoCodigo = produtoFalta.Codigo.HasValue &&
                                   produtoExistente.Codigo == produtoFalta.Codigo;

                bool mesmoNome = !string.IsNullOrWhiteSpace(produtoFalta.NomeProduto) &&
                                 !string.IsNullOrWhiteSpace(produtoExistente.NomeProduto) &&
                                 produtoExistente.NomeProduto.Trim().ToUpper() == produtoFalta.NomeProduto.Trim().ToUpper();

                if (mesmoCodigo || mesmoNome)
                {
                    throw new ArgumentException("Já existe um produto ativo cadastrado com o mesmo nome ou código.");
                }
            }

            // Continua cadastro
            produtoFalta.Loja = loja.Nome;
            produtoFalta.DataHoraCadastro = DateTime.Now;
            produtoFalta.Ativo = true;
            produtoFalta.Usuario = nomeUsuario;
            produtoFalta.JC1Recebido = false;
            produtoFalta.JC2Recebido = false;
            produtoFalta.VARecebido = false;
            produtoFalta.CLRecebido = false;

            _produtoFaltaRepository.Add(produtoFalta);

            return produtoFalta;
        }










        public List<ProdutoFalta> Consultar()
        {
            var produtoFalta = _produtoFaltaRepository?.GetAll(true);
            if (produtoFalta == null)
                throw new ArgumentNullException("Nenhum produto encontrado para consulta");
            return produtoFalta.Where(p => p.Ativo).ToList();
        }

        public ProdutoFalta Delete(int id)
        {
            var produtoFalta = ProdutoObterPorId(id);
            if (produtoFalta != null)
            {
                produtoFalta.Ativo = false;
                _produtoFaltaRepository.Update(produtoFalta);
            }
            return produtoFalta;
        }

        public ProdutoFalta ProdutoObterPorId(int id)
        {
            var produto = _produtoFaltaRepository.GetById(id);

            if (produto == null)
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



        public FornecProdFalt ExcluirFornec(int fornecProdFaltId)
        {



            var fornecProdFalt = _fornecProdFaltRepository.GetById(fornecProdFaltId);

            if (fornecProdFalt == null)
            {
                throw new ApplicationException("Fornecedor não encontrado.");
            }
            _fornecProdFaltRepository.Delete(fornecProdFalt);
            return fornecProdFalt;

        }



        public List<FornecProdFalt> ConsultarFornecAll(int produtoFaltaId)
        {

            var fornec = _produtoFaltaRepository.GetAllForn(produtoFaltaId);
            if (fornec == null)
            {
                throw new Exception("GetAllForn retornou null");
            }
            return fornec.ToList();
        }

        public FornecProdFalt CadastrarFornec(FornecProdFalt fornecProdFalt)
        {
            var produtoFalta = _produtoFaltaRepository.ObterPorId(fornecProdFalt.ProdutoFaltaId.Value);
            if (produtoFalta == null)
                throw new ArgumentException("ProdutoFalta não encontrado.");


            var fornecedor = _fornecedorGeralRepository.GetById(fornecProdFalt.FornecedorGeralId.Value);
            if (fornecedor == null)
                throw new ArgumentException("Fornecedor não encontrado.");

            // Preenchendo os dados do ProdutoFalta
            fornecProdFalt.NomeProduto = produtoFalta.NomeProduto;
            fornecProdFalt.Nome = fornecedor.Nome;
            fornecProdFalt.Valor = fornecProdFalt.Valor;
            fornecProdFalt.Quantidade = fornecProdFalt.Quantidade;
            fornecProdFalt.DataEntrada = DateTime.Now;
            if (fornecProdFalt.Codigo.HasValue)
            {
                fornecProdFalt.Codigo = produtoFalta.Codigo;
            }
            else
            {
                fornecProdFalt.Codigo = null;
            }
            fornecProdFalt.FornecedorGeralId = fornecedor.Id.Value;
            fornecProdFalt.ProdutoFaltaId = produtoFalta.Id.Value;
            // Salva ProdutoFalta e os fornecedores no banco de dados
            _fornecProdFaltRepository.Add(fornecProdFalt);
            return fornecProdFalt;
        }
        public ProdutoFalta AtualizarLoja(ProdutoFalta produtoFalta)
        {
            var loja = _lojaRepository.GetById(produtoFalta.LojaId);
            if (loja == null)
                throw new ArgumentException("Loja não encontrada.");

            var registro = ProdutoObterPorId(produtoFalta.Id.Value);
            if (registro == null)
                throw new ArgumentException("Produto não encontrado para edição");




            // Verifica se a loja já está associada em algum dos campos
            var nomeLoja = loja.Nome;

            if (registro.Loja == null)
                registro.Loja = nomeLoja;
            else if (registro.Loja2 == null)
                registro.Loja2 = nomeLoja;
            else if (registro.Loja3 == null)
                registro.Loja3 = nomeLoja;
            else if (registro.Loja4 == null)
                registro.Loja4 = nomeLoja;
            else
                throw new InvalidOperationException("Este produto já está associado a 4 lojas.");

            _produtoFaltaRepository.Update(registro);
            return registro;
        }

        public FornecProdFalt Autorizar(FornecProdFalt fornecProdFalt, string nomeUsuario)
        {
            var fornecedor = _fornecProdFaltRepository.GetById(fornecProdFalt.Id);
            if (fornecedor == null)
                throw new ArgumentException("Fornecedor não encontrado.");
            fornecedor.Id = fornecedor.Id;
            fornecedor.UsuarioAutorizador = nomeUsuario;
            fornecedor.DataHoraAutorizacao = DateTime.Now;
            _fornecProdFaltRepository.Update(fornecedor);
            return fornecedor;
        }

        public ProdutoFalta AtualizarStatusProduto(ProdutoFalta produtoFalta)
        {
            var registro = ProdutoObterPorId(produtoFalta.Id.Value);
            if (registro == null)
                throw new ArgumentException("Produto não encontrado para edição");

            switch (produtoFalta.LojaId)
            {
                case 1:
                    if (produtoFalta.JC1Recebido == true)
                    {
                        registro.JC1Recebido = true;
                        registro.SeparadoJC1 = false;
                    }
                    else if (produtoFalta.SeparadoJC1.HasValue)
                    {
                        registro.SeparadoJC1 = produtoFalta.SeparadoJC1.Value;
                    }
                    break;

                case 2:
                    if (produtoFalta.JC2Recebido == true)
                    {
                        registro.JC2Recebido = true;
                        registro.SeparadoJC2 = false;
                    }
                    else if (produtoFalta.SeparadoJC2.HasValue)
                    {
                        registro.SeparadoJC2 = produtoFalta.SeparadoJC2.Value;
                    }
                    break;

                case 3:
                    if (produtoFalta.VARecebido == true)
                    {
                        registro.VARecebido = true;
                        registro.SeparadoVA = false;
                    }
                    else if (produtoFalta.SeparadoVA.HasValue)
                    {
                        registro.SeparadoVA = produtoFalta.SeparadoVA.Value;
                    }
                    break;

                case 4:
                    if (produtoFalta.CLRecebido == true)
                    {
                        registro.CLRecebido = true;
                        registro.SeparadoCL = false;
                    }
                    else if (produtoFalta.SeparadoCL.HasValue)
                    {
                        registro.SeparadoCL = produtoFalta.SeparadoCL.Value;
                    }
                    break;

                default:
                    throw new ArgumentException("Loja inválida");
            }

            _produtoFaltaRepository.Update(registro);
            return registro;
        }



    }
}

