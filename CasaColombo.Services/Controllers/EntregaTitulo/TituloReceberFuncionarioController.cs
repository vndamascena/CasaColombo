using AutoMapper;
using CasaColombo.Domain.Entities.Titulos;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Domain.Interfaces.Services.IEntregasTitulos;
using CasaColombo.Services.Model.Titulo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace EntregaTitulo.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloReceberFuncionarioController : ControllerBase
    {
        private readonly IMapper? _mapper;
        private readonly HttpClient _httpClient;
        private readonly string _imageFolderPath;
        private readonly string _imageEntregaFolderPath;
        private int _nextImageId = 1;
        private readonly ITituloReceberFuncionarioDomainService? _tituloReceberFuncionarioDomainService;
        private readonly IBaixaTituloFuncionarioRepository? _baixaTiituloFuncionarioRepository;

        public TituloReceberFuncionarioController(IMapper? mapper, IHttpClientFactory httpClientFactory,
            ITituloReceberFuncionarioDomainService? tituloReceberFuncionarioDomainService, IBaixaTituloFuncionarioRepository? baixaTiituloFuncionarioRepository)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://colombo01-001-site2.gtempurl.com/usuarios/autenticar");
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagesTituloFuncionario");
            _imageEntregaFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagesTitulosBFuncionario");
            _tituloReceberFuncionarioDomainService = tituloReceberFuncionarioDomainService;
            _baixaTiituloFuncionarioRepository = baixaTiituloFuncionarioRepository;
        }


        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile, int tituloId)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            // Cria o diretório, se ainda não existir
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }

            // Busca todos os arquivos no diretório para calcular o próximo número
            var existingFiles = Directory.GetFiles(_imageFolderPath);
            int nextImageNumber = existingFiles.Length + 1;  // O próximo número será o total de arquivos + 1

            // Gera o nome do arquivo com o número crescente
            string fileName = $"{nextImageNumber}_{Path.GetFileName(imageFile.FileName)}";
            string filePath = Path.Combine(_imageFolderPath, fileName);

            // Salva a imagem no diretório
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Gera o caminho relativo para salvar no banco de dados
            string relativeFilePath = $"/imagesTituloFuncionario/{fileName}";
            await SalvarCaminhoImagemNoBanco(tituloId, relativeFilePath);

            return Ok(new { Message = "Imagem carregada com sucesso.", ImageUrl = relativeFilePath });
        }

        private async Task SalvarCaminhoImagemNoBanco(int tituloId, string relativeFilePath)
        {
            string connectionString = @"Data Source=SQL8020.site4now.net;Initial Catalog=db_aa8a78_entrega;User Id=db_aa8a78_entrega_admin;Password=colombo24";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TITULORECEBERFUNCIONARIO SET IMAGEMURL = @FilePath WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", relativeFilePath);
                    command.Parameters.AddWithValue("@ID", tituloId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        [HttpGet]
        [Route("imagesTituloFuncionario/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            string filePath = Path.Combine(_imageFolderPath, fileName);
            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "image/jpeg");
            }
            else
            {
                return NotFound();
            }
        }









        private async Task<bool> AutenticarUsuario(string matricula, string senha)
        {
            try
            {
                var usuarioModel = new { Matricula = matricula, Senha = senha };
                var json = JsonSerializer.Serialize(usuarioModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/usuarios/autenticar", content); // Substitui "rota-da-autenticacao" pela rota de autenticação da API
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> IsUserAuthorized(string matricula, string senha)
        {
            // Lista de usuários autorizados para autenticação
            Dictionary<string, string> usuariosAutorizados = new Dictionary<string, string>
            {
                { "65", "1723" },   // Exemplo: Matricula e senha do usuário 1
                { "1", "2816" },
                 { "5", "1005" },
                { "2", "1470" },
                {"6", "1457" }
            };

            // Verifica se as credenciais fornecidas estão na lista de usuários autorizados
            if (usuariosAutorizados.ContainsKey(matricula) && usuariosAutorizados[matricula] == senha)
            {
                try
                {
                    // Realiza a chamada à API de autenticação apenas para os usuários autorizados
                    var usuarioModel = new { Matricula = matricula, Senha = senha };
                    var json = JsonSerializer.Serialize(usuarioModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("/api/usuarios/autenticar", content); // Substitua "rota-da-autenticacao" pela rota de autenticação da sua API
                    response.EnsureSuccessStatusCode();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                // Se as credenciais do usuário não estiverem na lista branca, retorne false
                return false;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(TituloReceberFuncionarioGetModel), 201)]
        public async Task<IActionResult> PostModel([FromBody] TituloReceberFuncionarioPostModel model, string matricula, string senha)
        {
            try
            {
                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }


                var tituloReceber = _mapper?.Map<TituloReceberFuncionario>(model);
                var result = _tituloReceberFuncionarioDomainService?.Cadastrar(tituloReceber, matricula);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<TituloReceberFuncionarioGetModel>(result));
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TituloReceberFuncionarioGetModel), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper?.Map<TituloReceberFuncionarioGetModel>(_tituloReceberFuncionarioDomainService.ObterPorId(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TituloReceberFuncionarioGetModel>), 200)]
        public IActionResult GetAll()
        {
            var tituloReceber = _tituloReceberFuncionarioDomainService?.Consultar();
            var result = _mapper?.Map<List<TituloReceberFuncionarioGetModel>>(tituloReceber);
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _tituloReceberFuncionarioDomainService?.Delete(id);
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


        [HttpPut]
        [ProducesResponseType(typeof(TituloReceberFuncionarioGetModel), 201)]
        public async Task<IActionResult> PutModel([FromBody] TituloReceberFuncionarioPutModel model, string matricula, string senha)
        {
            try
            {

                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }

                var entrega = _mapper?.Map<TituloReceberFuncionario>(model);


                var result = _tituloReceberFuncionarioDomainService?.Atualizar(entrega, matricula);

                var entregaGetModel = _mapper.Map<TituloReceberFuncionarioGetModel>(result);

                //HTTP 201 (OK)
                return StatusCode(200, new
                {
                    Message = "Título atualizado com sucesso",
                    entregaGetModel
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


        [HttpPost("baixaTituloFuncionario")]
        [ProducesResponseType(typeof(BaixaTituloFuncionarioGetModel), 201)]
        public async Task<IActionResult> BaixaTitulo(string matricula, string senha, int id, [FromBody] BaixaTituloFuncionarioPostModel baixa)
        {
            try
            {
                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }

                // Execute a baixa de titulo e obtenha o resultado
                var baixaTitulo = _tituloReceberFuncionarioDomainService.BaixaTituloFuncionario(id, matricula);

                if (baixaTitulo != null)
                {
                    // Mapeie o resultado para o modelo de resposta
                    var baixaTituloGetModel = _mapper.Map<BaixaTituloFuncionarioGetModel>(baixaTitulo);

                    // Retorne HTTP 201 (CREATED) com o modelo de resposta
                    return StatusCode(201, baixaTituloGetModel);
                }
                else
                {
                    // Retorne HTTP 400 (BAD REQUEST) se não houver resultado
                    return StatusCode(400, new { error = "Não foi possível realizar a baixa de título." });
                }
            }
            catch (Exception e)
            {
                // HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { error = e.Message });
            }


        }

        [HttpGet("baixaTituloFuncionario")]
        [ProducesResponseType(typeof(List<BaixaTituloFuncionarioGetModel>), 200)]
        public IActionResult BaixaTitulo()
        {
            try
            {
                var baixaTitulo = _tituloReceberFuncionarioDomainService.ConsultarBaixa();
                var baixaTituloModel = _mapper.Map<List<BaixaTituloFuncionarioGetModel>>(baixaTitulo);
                return Ok(baixaTituloModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { erro = e.Message });
            }
        }
    }
}
