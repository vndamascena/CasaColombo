using AutoMapper;
using CasaColombo.Domain.Entities.Home;
using CasaColombo.Domain.Interfaces.Repositories.IHome;
using CasaColombo.Domain.Interfaces.Services.IHome;
using CasaColombo.Services.Model.HomeModel.EscalaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text;

namespace CasaColombo.Services.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper? _mapper;
        private readonly HttpClient _httpClient;
        private readonly string _imageEscalaFolderPath;
        private int _nextImageId = 1;
        private readonly IEscalaRepository? _escalaRepository;
        private readonly IHomeDomainService _homeDomainService;

        public HomeController(IMapper? mapper, IHttpClientFactory httpClientFactory,

            IEscalaRepository? escalaRepository, IHomeDomainService homeDomainService)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://colombo01-001-site2.gtempurl.com/usuarios/autenticar");
            _imageEscalaFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagesEscala");
            _escalaRepository = escalaRepository;
            _homeDomainService = homeDomainService;
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
        [Route("escala")]
        [ProducesResponseType(typeof(EscalaGetModel), 201)]

        public async Task<IActionResult> PostModel([FromBody] EscalaPostModel model)
        {
            try
            {


                var escala = _mapper?.Map<Escala>(model);
                var result = _homeDomainService?.Cadastrar(escala);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<EscalaGetModel>(result));
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }

        }


        [HttpGet]
        [Route("escala")]
        [ProducesResponseType(typeof(List<EscalaGetModel>), 200)]
        public IActionResult GetAll()
        {
            var escala = _homeDomainService?.Consultar();
            var result = _mapper?.Map<List<EscalaGetModel>>(escala);
            return Ok(result);
        }





        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile, int Id, string matricula, string senha)
        {
            // Verifique se o usuário está autorizado
            if (!(await IsUserAuthorized(matricula, senha)))
            {
                return StatusCode(401, new { error = "Usuário não autorizado." });
            }

            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            // Cria o diretório, se ainda não existir
            if (!Directory.Exists(_imageEscalaFolderPath))
            {
                Directory.CreateDirectory(_imageEscalaFolderPath);
            }

            // Busca todos os arquivos no diretório para calcular o próximo número
            var existingFiles = Directory.GetFiles(_imageEscalaFolderPath);
            int nextImageNumber = existingFiles.Length + 1;  // O próximo número será o total de arquivos + 1

            // Gera o nome do arquivo com o número crescente
            string fileName = $"{nextImageNumber}_{Path.GetFileName(imageFile.FileName)}";
            string filePath = Path.Combine(_imageEscalaFolderPath, fileName);

            // Salva a imagem no diretório
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Gera o caminho relativo para salvar no banco de dados
            string relativeFilePath = $"/imagesEscala/{fileName}";
            await SalvarCaminhoImagemNoBanco(Id, relativeFilePath);

            return Ok(new { Message = "Imagem carregada com sucesso.", ImageUrl = relativeFilePath });
        }

        private async Task SalvarCaminhoImagemNoBanco(int Id, string relativeFilePath)
        {
            string connectionString = @"Data Source=SQL8020.site4now.net;Initial Catalog=db_aa8a78_entrega;User Id=db_aa8a78_entrega_admin;Password=colombo24";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ESCALA SET IMAGEMURL = @FilePath WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", relativeFilePath);
                    command.Parameters.AddWithValue("@ID", Id);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        [HttpGet]
        [Route("imagesEscala/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            string filePath = Path.Combine(_imageEscalaFolderPath, fileName);
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


    }
}

