using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Test.Fornecedor
{
    public class FornecedoresTest
    {
        [Fact]
        public void Test_Fornecedores_Get_Returns_Ok()
        {
            //fazendo uma chamada para o serviço de consulta de
            //fornecedores da API
            var client = new WebApplicationFactory<Program>()

            .CreateClient();

            var response = client.GetAsync("/api/FornecedorGeral").Result;
            //verificando se o retorno da chamada é OK! (Http 200)
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
