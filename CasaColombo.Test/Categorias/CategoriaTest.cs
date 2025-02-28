using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CasaColombo.Test.Categorias
{
    public class CategoriaTest
    {
        [Fact]
        public void Test_Categorias_Get_Returns_Ok()
        {
            //fazendo uma chamada para o serviço de consulta de
            //categorias da API
            var client = new WebApplicationFactory<Program>()
            .CreateClient();

            var response = client.GetAsync("/api/Categoria").Result;
            //verificando se o retorno da chamada é OK! (Http 200)
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
