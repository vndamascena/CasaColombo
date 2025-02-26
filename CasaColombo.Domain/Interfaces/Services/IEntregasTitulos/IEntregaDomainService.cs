using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Domain.Interfaces.Services.IEntregasTitulos
{
    public interface IEntregaDomainService
    {
        Entrega Cadastrar(Entrega entrega, string matricula);
        Entrega Atualizar(Entrega entrega, string matricula);
        Entrega AtualizarMotorista(Entrega entrega);
        Entrega CadastrarMotorista(Entrega entrega);
       
        Entrega Delete(int id);
        List<Entrega> Consultar();
        List<BaixaEntrega> ConsultarBaixa();
        List<PendenciaEntrega> ConsultarPendencia();
        List<Impressao> ConsultarImpressao();
        List<Pagamento> ConsultarPagamento();
        BaixaEntrega BaixaEntrega(int id, string matricula, string dataEntregaBaixa, string diaSemanaBaixa);
        Pagamento CadastrarPagamento(Pagamento pagamento, int id, string matricula);
        void PendenciaEntrega(int id, string matricula, string observacaoPendencia, string dataEntregaProximaEntrega, string diaProximaPendencia);
        void Impressao(int id, string matricula);
       

        Entrega ObterPorId(int id);

    }
}
