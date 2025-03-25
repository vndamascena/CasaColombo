using AutoMapper;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Services.Model.Produtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace CasaColombo.Services.Controllers.ProdOcorrFornLojas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFaltaController : ControllerBase
    {
        private readonly IProdutoFaltaDomainService _produtoFaltaDomainService;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ProdutoFaltaController(IProdutoFaltaDomainService produtoFaltaDomainService, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _produtoFaltaDomainService = produtoFaltaDomainService;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://colombo01-001-site2.gtempurl.com/usuarios/autenticar");

        }



        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoFaltaGetModel>), 200)]
        public IActionResult GetAll()
        {
            var produtos = _produtoFaltaDomainService.Consultar();
            var result = _mapper.Map<List<ProdutoFaltaGetModel>>(produtos);
            return Ok(result);
        }


        private async Task<(bool, string)> AutenticarUsuario(string matricula, string senha)
        {
            try
            {
                var usuarioModel = new { Matricula = matricula, Senha = senha };
                var json = JsonSerializer.Serialize(usuarioModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/usuarios/autenticar", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"📢 Resposta da API de autenticação: {responseContent}");

                if (!response.IsSuccessStatusCode)
                {
                    return (false, null); // Falha na autenticação
                }

                var usuario = JsonSerializer.Deserialize<UsuarioResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Console.WriteLine($"🔹 Nome do usuário autenticado: {usuario?.Nome}");

                return (true, usuario?.Nome); // Retorna sucesso e o nome do usuário
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao autenticar usuário: {ex.Message}");
                return (false, null);
            }
        }





        // Classe para deserializar a resposta da API de autenticação
        public class UsuarioResponse
        {
            public string Nome { get; set; }
        }





        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ProdutoFaltaGetModel), 200)]
        public IActionResult Get(int id)
        {
            try
            {
                var produto = _produtoFaltaDomainService.ObterPorId(id);

                var result = _mapper.Map<ProdutoFaltaGetModel>(produto);

                return Ok(result);
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { Message = "Produto de " + id + "se encontra inativo para exibição" });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(ProdutoFaltaGetModel), 201)]
        public async Task<IActionResult> CadastrarProduto(string matricula, string senha, [FromBody] ProdutoFaltaPostModel model)
        {
            try
            {
                var (autenticado, nomeUsuario) = await AutenticarUsuario(matricula, senha);

                if (!autenticado)
                {
                    return StatusCode(401, new { error = "Matricula ou senha incorreta, tente novamente" });
                }

                var produto = _mapper.Map<ProdutoFalta>(model);

                // 🔹 Passando o nome do usuário corretamente
                var result = _produtoFaltaDomainService.Cadastrar(produto, nomeUsuario);
                // Mapear o resultado de volta para o modelo de resposta
                var produtoFaltaGetModel = _mapper.Map<ProdutoFaltaGetModel>(result);

                return StatusCode(201, new { Message = "Falta de produto cadastrado com sucesso", produtoFaltaGetModel });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }








        [HttpPut]
        [ProducesResponseType(typeof(ProdutoFaltaPutModel), 201)]
        public IActionResult PutModel([FromBody] ProdutoFaltaPutModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produto = new ProdutoFalta
                {
                    Id = model.Id,
                    NomeProduto = model.NomeProduto,
                    CodigoFornecedor = model.CodigoFornecedor,
                    Codigo = model.Codigo,
                    DataHoraAlteracao = DateTime.Now
                };
                var result = _produtoFaltaDomainService.Atualizar(produto);
                return StatusCode(201, new
                {
                    Message = "Falta de produto atualizado com sucesso",
                    result
                }); ;
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _produtoFaltaDomainService.Delete(id);
                return StatusCode(201, new
                {
                    Message = "Falta de produto deletado com sucesso",
                    result
                });
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }



        }


        [HttpPost("confirmar-baixa")]
        [ProducesResponseType(typeof(BaixaAutProdFaltGetModel), 201)]
        public async Task<IActionResult> BaixaProdutoFalta(string matricula, string senha, int Id, [FromBody] BaixaAutProdFaltPostModel baixa)
        {

            try
            {
                var (autenticado, nomeUsuario) = await AutenticarUsuario(matricula, senha);

                if (!autenticado)
                {
                    return StatusCode(401, new { error = "Matricula ou senha incorreta, tente novamente" });
                }

                var baixaconfirma = _produtoFaltaDomainService.ConfirmarBaixa(Id, nomeUsuario);


                // Mapear o resultado de volta para o modelo de resposta
                var produtoFaltaGetModel = _mapper.Map<BaixaAutProdFaltGetModel>(baixaconfirma);

                return StatusCode(201, new { Message = "Falta de produto cadastrado com sucesso", produtoFaltaGetModel });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("consultar-baixa")]
        [ProducesResponseType(typeof(List<BaixaAutProdFaltGetModel>), 200)]
        public IActionResult ConsultarBaixa()
        {
            var baixa = _produtoFaltaDomainService.ConsultarBaixaAll();
            var result = _mapper.Map<List<BaixaAutProdFaltGetModel>>(baixa);
            return Ok(result);
        }

    }
}
