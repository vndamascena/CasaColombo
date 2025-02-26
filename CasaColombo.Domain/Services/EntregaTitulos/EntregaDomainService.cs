
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Domain.Interfaces.Services.IEntregasTitulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Services.EntregaTitulos
{




    public class EntregaDomainService : IEntregaDomainService
    {
        private readonly IEntregaRepository? _entregaRepository;
        private readonly IBaixaEntregaRepository? _baixaEntregaRepository;
        private readonly IPendenciaEntregaRepository? _pendenciaEntregaRepository;
        private readonly IImpressaoRepository? _impressaoRepository;
        private readonly IPagamentoRepository? _pagamentoRepository;
        public EntregaDomainService(IEntregaRepository? entregaRepository, IBaixaEntregaRepository? baixaEntregaRepository,
            IPendenciaEntregaRepository pendenciaEntregaRepository, 
            IImpressaoRepository? impressaoRepository, IPagamentoRepository?pagamentoRepository)
        {
            {
                _entregaRepository = entregaRepository;
                _baixaEntregaRepository = baixaEntregaRepository;
                _pendenciaEntregaRepository = pendenciaEntregaRepository;
                _impressaoRepository = impressaoRepository;
                _pagamentoRepository = pagamentoRepository;

            }


        }

        public Entrega AtualizarMotorista(Entrega entrega)
        {
            var registro = ObterPorId(entrega.Id);
            if (registro == null)
                throw new ApplicationException("Entrega não encontrado para edição.");

            var entregaAtualizado = new Entrega
            {
                Id = entrega.Id,

                MotoristaAtual = entrega.MotoristaAtual,
                Motorista = registro.Motorista,
                NomeCliente = registro.NomeCliente,
                NumeroNota = registro.NumeroNota,
                Valor = registro.Valor,
                DiaSemana = registro.DiaSemana,
                DataEntrega = registro.DataEntrega,
                DataVenda = registro.DataVenda,
                Periodo = registro.Periodo,
                Observacao = registro.Observacao,
                Ativo = registro.Ativo,
                ImagemUrl = registro.ImagemUrl,
                DataCadastro = registro.DataCadastro,
                UsuarioId = registro.UsuarioId,
                Vendedor = registro.Vendedor,
                Loja = registro.Loja,
                Pagamento = registro.Pagamento,





            };
            if (registro.DataCadastro == null)
            {
                entregaAtualizado.DataCadastro = DateTime.Now;
            }

            _entregaRepository?.Update(entregaAtualizado);
            return _entregaRepository?.GetById(entrega.Id);
        }

        public Entrega CadastrarMotorista(Entrega entrega)
        {
            var registro = ObterPorId(entrega.Id);
            if (registro == null)
                throw new ApplicationException("Entrega não encontrado para edição.");

            var entregaAtualizado = new Entrega
            {
                Id = entrega.Id,

                Motorista = entrega.Motorista,
                NomeCliente = registro.NomeCliente,
                NumeroNota = registro.NumeroNota,
                Valor = registro.Valor,
                DiaSemana = registro.DiaSemana,
                DataEntrega = registro.DataEntrega,
                DataVenda = registro.DataVenda,
                Periodo = registro.Periodo,
                Observacao = registro.Observacao,
                Ativo = registro.Ativo,
                ImagemUrl = registro.ImagemUrl,
                DataCadastro = registro.DataCadastro,
                UsuarioId = registro.UsuarioId,
                Vendedor = registro.Vendedor,
                Loja = registro.Loja,
                Pagamento = registro.Pagamento,





            };
            if (registro.DataCadastro == null)
            {
                entregaAtualizado.DataCadastro = DateTime.Now;
            }

            _entregaRepository?.Update(entregaAtualizado);
            return _entregaRepository?.GetById(entrega.Id);
        }

       

        public Entrega Atualizar(Entrega entrega, string matricula)
        {
            var registro = ObterPorId(entrega.Id);


           
            PendenciaEntrega pendencia = null;

            if (registro == null)
            {
                // Verifica se é um ID de pendência
                pendencia = _pendenciaEntregaRepository.GetById(entrega.Id);
                if (pendencia == null)
                {
                    throw new ApplicationException("Entrega ou pendência não encontrada.");
                }

                // Obtém a entrega associada à pendência
                entrega = _entregaRepository.GetById(pendencia.EntregaId);
                if (entrega == null)
                {
                    throw new ApplicationException("Entrega associada à pendência não encontrada.");
                }
            }

            if (registro == null)
                throw new ApplicationException("Entrega não encontrado para edição.");

            var entregaAtualizado = new Entrega
            {
                Id = registro.Id,

                NomeCliente = entrega.NomeCliente,
                NumeroNota = entrega.NumeroNota,
                Valor = registro.Valor,
                DiaSemana = entrega.DiaSemana,
                DataEntrega = entrega.DataEntrega,
                DataVenda = registro.DataVenda,
                Periodo = entrega.Periodo,
                Observacao = entrega.Observacao,
                Ativo = registro.Ativo,
                ImagemUrl = registro.ImagemUrl,
                DataCadastro = registro.DataCadastro,
                UsuarioId = registro.UsuarioId,
                Loja = registro.Loja,
                Vendedor = registro.Vendedor,
                Pagamento = registro.Pagamento,
                DataAtualizacao = DateTime.Now,
                UsuarioIdAtualizador = matricula


            };
            if (registro.DataCadastro == null)
            {
                entregaAtualizado.DataCadastro = DateTime.Now;
            }


            if (pendencia != null)
            {
                pendencia.Ativo = false;
                _pendenciaEntregaRepository.Update(pendencia);
            }
            else
            {
                // Também verifica se há uma pendência associada à entrega para desativá-la
                pendencia = _pendenciaEntregaRepository.GetByEntregaId(entrega.Id);
                if (pendencia != null)
                {
                    pendencia.Ativo = false;
                    _pendenciaEntregaRepository.Update(pendencia);
                }
            }

            _entregaRepository?.Update(entregaAtualizado);
            return _entregaRepository?.GetById(entrega.Id);
        }

        public BaixaEntrega BaixaEntrega(int id, string matricula, string dataEntregaBaixa, string diaSemanaBaixa)
        {
            var entrega = _entregaRepository.GetById(id);
            PendenciaEntrega pendencia = null;

            if (entrega == null)
            {
                // Verifica se é um ID de pendência
                pendencia = _pendenciaEntregaRepository.GetById(id);
                if (pendencia == null)
                {
                    throw new ApplicationException("Entrega ou pendência não encontrada.");
                }

                // Obtém a entrega associada à pendência
                entrega = _entregaRepository.GetById(pendencia.EntregaId);
                if (entrega == null)
                {
                    throw new ApplicationException("Entrega associada à pendência não encontrada.");
                }
            }

            if (!entrega.Ativo)
            {
                throw new ApplicationException("Não é possível dar baixa em uma entrega inativa.");
            }

            var baixaEntrega = new BaixaEntrega
            {
                EntregaId = entrega.Id,
                NumeroNota = entrega.NumeroNota,
                NomeCliente = entrega.NomeCliente,
                Valor = entrega.Valor,
                ImagemUrl = entrega.ImagemUrl,
                Vendedor = entrega.Vendedor,
                Motorista = entrega.Motorista,
                DataVenda = entrega.DataVenda,
                DataEntregaBaixa = dataEntregaBaixa,
                UsuarioId = matricula,
                Observacao = entrega.Observacao,
                DiaSemanaBaixa = diaSemanaBaixa,
                Periodo = entrega.Periodo,
                DataTime = DateTime.Now,
                Loja = entrega.Loja,

            };

            Console.WriteLine($"DataEntrega: {baixaEntrega.DataEntregaBaixa}");
            Console.WriteLine($"DiaSemana: {baixaEntrega.DiaSemanaBaixa}");
            _baixaEntregaRepository.Add(baixaEntrega);

            entrega.Ativo = false;
            _entregaRepository.Update(entrega);

            if (pendencia != null)
            {
                pendencia.Ativo = false;
                _pendenciaEntregaRepository.Update(pendencia);
            }
            else
            {
                // Também verifica se há uma pendência associada à entrega para desativá-la
                pendencia = _pendenciaEntregaRepository.GetByEntregaId(entrega.Id);
                if (pendencia != null)
                {
                    pendencia.Ativo = false;
                    _pendenciaEntregaRepository.Update(pendencia);
                }
            }

            return baixaEntrega;  // Retorne o objeto BaixaEntrega criado
        }

        public Pagamento CadastrarPagamento(Pagamento pagamento, int id, string matricula)
        {
            // Obter a entrega associada ao pagamento
            var entrega = _entregaRepository.GetById(id);

            // Verificar se a entrega está ativa
            if (!entrega.Ativo)
            {
                throw new ApplicationException("Não é possível registrar um pagamento para uma entrega inativa.");
            }

            pagamento.NumeroNota = entrega.NumeroNota; 
            pagamento.NomeCliente = entrega.NomeCliente; 
            pagamento.EntregaId = entrega.Id;
            pagamento.DataTime = DateTime.Now;
            pagamento.UsuarioId = matricula;



            _pagamentoRepository.Add(pagamento);

           
            pagamento = _pagamentoRepository?.GetById(pagamento.IdPagamento);

          
            _pagamentoRepository.Update(pagamento);

            return pagamento;
        }





        public Entrega Cadastrar(Entrega entrega, string matricula)
        {
            entrega.UsuarioId = matricula;
            entrega.Ativo = true;
            _entregaRepository?.Add(entrega);
            entrega = _entregaRepository?.GetById(entrega.Id);

            return entrega;
        }


        public List<Entrega> Consultar()
        {
            var entrega = _entregaRepository?.GetAll(true);

            if (entrega == null)
                return new List<Entrega>();

            return entrega.Where(p => p.Ativo).ToList();
        }

        public List<BaixaEntrega> ConsultarBaixa()
        {
            var baixaEntrega = _baixaEntregaRepository?.GetAll();

            if (baixaEntrega == null)
                return new List<BaixaEntrega>();

            return baixaEntrega.ToList();
        }

        public List<Impressao> ConsultarImpressao()
        {
            var impressao = _impressaoRepository?.GetAll();
            if (impressao == null)
                return new List<Impressao>();
            return impressao.ToList();
        }
        public List<Pagamento> ConsultarPagamento()
        {
            var pagamento = _pagamentoRepository?.GetAll();
            if (pagamento == null)
                return new List<Pagamento>();
            return pagamento.ToList();
        }

        public List<PendenciaEntrega> ConsultarPendencia()
        {
            var pendenciaEntrega = _pendenciaEntregaRepository?.GetAll(true);

            if (pendenciaEntrega == null)
                return new List<PendenciaEntrega>();

            return pendenciaEntrega.Where(p => p.Ativo).ToList();
        }

        public Entrega Delete(int id)
        {
            var entrega = ObterPorId(id);
            if (entrega == null)
                throw new ApplicationException("Entrega nao encontrada para exclução");



            _entregaRepository.Delete(entrega);
            return entrega;
        }

        public void Impressao(int id, string matricula)
        {
            var impressao = _entregaRepository.GetById(id);
            if (impressao == null)
            {
                throw new ApplicationException("impressao não encontrada.");
            }

            if (!impressao.Ativo)
            {
                throw new ApplicationException("Não é possível adicionar pendência em uma entrega inativa.");
            }

            var impress = new Impressao
            {

                EntregaId = impressao.Id,

                NumeroNota = impressao.NumeroNota,
                NomeCliente = impressao.NomeCliente,
                UsuarioId = matricula,

                DataTime = DateTime.Now,
            };
            _impressaoRepository.Add(impress);
        }

      

        public Entrega ObterPorId(int id)
        {
            var entrega = _entregaRepository?.GetById(id);

            return entrega;
        }

        public void PendenciaEntrega(int id, string matricula, string observacaoPendencia, string dataEntregaProximaEntrega, string diaSemanaPendencia )
        {
            var entrega = _entregaRepository.GetById(id);
            if (entrega == null)
            {
                throw new ApplicationException("Entrega não encontrada.");
            }

            if (!entrega.Ativo)
            {
                throw new ApplicationException("Não é possível adicionar pendência em uma entrega inativa.");
            }

            var pendenciaExistente = _pendenciaEntregaRepository.GetByEntregaId(entrega.Id);
            if (pendenciaExistente != null && pendenciaExistente.Ativo)
            {
                throw new ApplicationException("Já existe uma pendência ativa para esta entrega.");
            }

            var pendenciaEntrega = new PendenciaEntrega
            {
                EntregaId = entrega.Id,
                NumeroNota = entrega.NumeroNota,
                NomeCliente = entrega.NomeCliente,
                Valor = entrega.Valor,
                Ativo = true,  // Pendência está ativa
                ImagemUrl = entrega.ImagemUrl,
                UsuarioId = matricula,
                Periodo = entrega.Periodo,
                DataEntrega = entrega.DataEntrega,
                DataVenda = entrega.DataVenda,
                Vendedor = entrega.Vendedor,
                Observacao = entrega.Observacao,
                ObservacaoPendencia = observacaoPendencia,
                DiaSemana = entrega.DiaSemana,
                DataTime = DateTime.Now,
                Motorista = entrega.Motorista,
                MotoristaAtual = entrega.MotoristaAtual,
                DataEntregaProximaEntrega = dataEntregaProximaEntrega,
                DiaSemanaPendencia = diaSemanaPendencia,
                Loja = entrega.Loja,
               
            };

            _pendenciaEntregaRepository.Add(pendenciaEntrega);
        }





    }
}
