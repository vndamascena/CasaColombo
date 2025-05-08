using AutoMapper;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Services.Model.Produtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using CasaColombo.Domain.Interfaces.Repositories.IProdOcorrFornLojas;

namespace CasaColombo.Services.Controllers.ProdOcorrFornLojas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFaltaController : ControllerBase
    {
        private readonly IProdutoFaltaDomainService _produtoFaltaDomainService;
        private readonly IFornecProdFaltRepository _fornecProdFaltRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ProdutoFaltaController(IProdutoFaltaDomainService produtoFaltaDomainService, IMapper mapper, IHttpClientFactory httpClientFactory,
            IFornecProdFaltRepository fornecProdFaltRepository)
        {
            _produtoFaltaDomainService = produtoFaltaDomainService;
            _fornecProdFaltRepository = fornecProdFaltRepository;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://colombo01-001-site2.gtempurl.com/usuarios/autenticar");

        }



        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoFaltaGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var produtos = _produtoFaltaDomainService.Consultar();
                var produtosFaltaModel = _mapper.Map<List<ProdutoFaltaGetModel>>(produtos, opt => opt.Items["IncludeFornecProdFalt"] = true);
                return Ok(produtosFaltaModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }

           
            
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
        private async Task<(bool, string)> IsUserAuthorized(string matricula, string senha)
        {
            Dictionary<string, string> usuariosAutorizados = new Dictionary<string, string>
    {
        { "65", "1723" },
        { "1", "5555" },
        { "3", "1601" },
        { "2", "1470" },
    };

            if (usuariosAutorizados.ContainsKey(matricula) && usuariosAutorizados[matricula] == senha)
            {
                try
                {
                    var usuarioModel = new { Matricula = matricula, Senha = senha };
                    var json = JsonSerializer.Serialize(usuarioModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("/api/usuarios/autenticar", content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return (false, null);
                    }

                    var usuario = JsonSerializer.Deserialize<UsuarioResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return (true, usuario?.Nome);
                }
                catch
                {
                    return (false, null);
                }
            }
            else
            {
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
                var produtos = _produtoFaltaDomainService.ProdutoObterPorId(id);

                var produtosFaltaModel = _mapper.Map<ProdutoFaltaGetModel>(produtos);
                return Ok(produtosFaltaModel);

               
            }
            catch (ApplicationException e)
            {
                //HTTP 400 (BAD REQUEST)
                return StatusCode(400, new { Message = "Produto de " + id + " se encontra inativo para exibição" });
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("fornecedorProduto")]
        [ProducesResponseType(typeof(FornecProdFaltGetModel), 200)]
        public IActionResult GetFornecProdFaltAll()
        {
            try
            {
                var fornecProdFalt = _fornecProdFaltRepository.GetAll();
               
                var result = _mapper.Map<List<FornecProdFaltGetModel>>(fornecProdFalt);
               
                return Ok(result);
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

        [HttpGet("{id}/fornecedorProduto")]
        [ProducesResponseType(typeof(FornecProdFaltGetModel), 200)]
        public IActionResult GetFornecProdFalt(int id)
        {
            try
            {
                var fornec = _produtoFaltaDomainService.ConsultarFornecAll(id);
                var result = _mapper.Map<List<FornecProdFaltGetModel>>(fornec);
                return Ok(result);
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
                var result = _produtoFaltaDomainService.Cadastrar(produto ,nomeUsuario);
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



        [HttpPost("fornecedorProduto")]
        [ProducesResponseType(typeof(FornecProdFaltPostModel), 201)]
        public IActionResult CadastrarFornecedorProduto([FromBody] FornecProdFaltPostModel model)
        {
            try
            {
               var forneceProdFalt = _mapper.Map<FornecProdFalt>(model);
                var result = _produtoFaltaDomainService.CadastrarFornec(forneceProdFalt);
                return StatusCode(201, new
                {
                    Message = "Fornecedor de produto cadastrado com sucesso",
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




        [HttpPut]
        [ProducesResponseType(typeof(ProdutoFaltaPutModel), 201)]
        public async Task<IActionResult> PutModel(string matricula, string senha, [FromBody] ProdutoFaltaPutModel model)
        {
            try
            {


                var (autenticado, nomeUsuario) = await IsUserAuthorized(matricula, senha);

                if (!autenticado)
                {
                    return StatusCode(401, new { error = "Matricula ou senha incorreta, tente novamente" });
                }


                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produtoFalta = _mapper.Map<ProdutoFalta>(model);
                var result = _produtoFaltaDomainService.Atualizar(produtoFalta);
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
        [HttpPut("chegouCor")]
        [ProducesResponseType(typeof(ProdutoFaltaPutModel), 201)]
        public async Task<IActionResult> PutModelChegouCor( [FromBody] ProdutoFaltaPutModel model)
        {
            try
            {
              


                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produtoFalta = _mapper.Map<ProdutoFalta>(model);
                var result = _produtoFaltaDomainService.AtualizarStatusProduto(produtoFalta);
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

        [HttpPut("autorizar")]
        [ProducesResponseType(typeof(FornecProdFaltPutModel), 201)]
        public async Task<IActionResult> PutModelAutorizar(string matricula, string senha, [FromBody] FornecProdFaltPutModel model)
        {
            try
            {


                var (autenticado, nomeUsuario) = await IsUserAuthorized(matricula, senha);

                if (!autenticado)
                {
                    return StatusCode(401, new { error = "Matricula ou senha incorreta, tente novamente" });
                }


                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produtoFalta = _mapper.Map<FornecProdFalt>(model);
                var result = _produtoFaltaDomainService.Autorizar(produtoFalta, nomeUsuario);
                return StatusCode(201, new
                {
                    Message = "Produto autorizado para compra",
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


        [HttpPut("lojas")]
        [ProducesResponseType(typeof(ProdutoFaltaPutModel), 201)]
        public async Task<IActionResult> PutModelLojas([FromBody] ProdutoFaltaPutModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produtoFalta = _mapper.Map<ProdutoFalta>(model);
                var result = _produtoFaltaDomainService.AtualizarLoja(produtoFalta);
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

        [HttpDelete("fornecProdFalt/{fornecProdFaltId}")]
        public IActionResult delteFornec( int fornecProdFaltId)
        {
            try
            {
                _produtoFaltaDomainService.ExcluirFornec(fornecProdFaltId);
                return StatusCode(201, new { Message = "Fornecedor deletado com sucesso" });
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

                return StatusCode(201, new { Message = "Falta de produto concluido com sucesso", produtoFaltaGetModel });
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
