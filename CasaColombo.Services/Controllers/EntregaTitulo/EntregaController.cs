using AutoMapper;
using CasaColombo.Domain.Entities.Entregas;
using CasaColombo.Domain.Interfaces.Repositories.IEntregasTitulos;
using CasaColombo.Domain.Interfaces.Services.IEntregasTitulos;
using CasaColombo.Services.Model.Entrega;
using CasaColombo.Services.Model.Impressao;
using CasaColombo.Services.Model.Pagamento;
using CasaColombo.Services.Model.PendenciaEntrega;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Text;

namespace CasaColombo.Services.Controllers.EntregaTitulo
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregaDomainService? _entregaDomainService;
        private readonly IMapper? _mapper;
        private readonly HttpClient _httpClient;
        private readonly IBaixaEntregaRepository _baixaEntregaRepository;
        private readonly IPendenciaEntregaRepository _pendenciaEntregaRepository;
        private readonly IImpressaoRepository _impressaoRepository;
        private readonly string _imageFolderPath;
        private readonly string _imageEntregaFolderPath;
        private int _nextImageId = 1;

        public EntregaController(IEntregaDomainService? entregaDomainService, IMapper? mapper, IHttpClientFactory httpClientFactory,
            IBaixaEntregaRepository baixaEntregaRepository, IPendenciaEntregaRepository pendenciaEntregaRepository
            , IImpressaoRepository impressaoRepository)
        {
            _entregaDomainService = entregaDomainService;
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://colombo01-001-site2.gtempurl.com/usuarios/autenticar");
            _pendenciaEntregaRepository = pendenciaEntregaRepository;
            _baixaEntregaRepository = baixaEntregaRepository;
            _pendenciaEntregaRepository = pendenciaEntregaRepository;
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            _imageEntregaFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagesEntregas");
            _impressaoRepository = impressaoRepository;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile, int entregaId)
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
            string relativeFilePath = $"/images/{fileName}";
            await SalvarCaminhoImagemNoBanco(entregaId, relativeFilePath);

            return Ok(new { Message = "Imagem carregada com sucesso.", ImageUrl = relativeFilePath });
        }

        private async Task SalvarCaminhoImagemNoBanco(int entregaId, string relativeFilePath)
        {
            string connectionString = @"Data Source=SQL8020.site4now.net;Initial Catalog=db_aa8a78_entrega;User Id=db_aa8a78_entrega_admin;Password=colombo24";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ENTREGA SET IMAGEMURL = @FilePath WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", relativeFilePath);
                    command.Parameters.AddWithValue("@ID", entregaId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        [HttpGet]
        [Route("images/{fileName}")]
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

        [HttpPost]
        [Route("uploadEntrega")]
        public async Task<IActionResult> UploadImageEntrega(IFormFile imageFile, int idBaixaEntrega)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }


            string fileName = $"{_nextImageId}_{Path.GetFileName(imageFile.FileName)}";
            _nextImageId++;

            string filePath = Path.Combine(_imageEntregaFolderPath, fileName);


            if (!Directory.Exists(_imageEntregaFolderPath))
            {
                Directory.CreateDirectory(_imageEntregaFolderPath);
            }


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }


            string relativeFilePath = $"/imagesEntrega/{fileName}";
            await SalvarBaixaCaminhoImagemNoBanco(idBaixaEntrega, relativeFilePath);

            return Ok(new { Message = "Imagem carregada com sucesso.", ImageUrl = relativeFilePath });
        }


        private async Task SalvarBaixaCaminhoImagemNoBanco(int idBaixaEntrega, string relativeFilePath)
        {
            string connectionString = @"Data Source=SQL8020.site4now.net;Initial Catalog=db_aa8a78_entrega;User Id=db_aa8a78_entrega_admin;Password=colombo24";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE BAIXAENTREGA SET URLIMAGEM = @FilePath WHERE IDBAIXAENTREGA = @IDBAIXAENTREGA";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", relativeFilePath);
                    command.Parameters.AddWithValue("@IDBAIXAENTREGA", idBaixaEntrega);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        [HttpGet]
        [Route("imagesEntrega/{fileName}")]
        public IActionResult GetImageEntrega(string fileName)
        {
            string filePath = Path.Combine(_imageEntregaFolderPath, fileName);
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





        [HttpPost]
        [ProducesResponseType(typeof(EntregaGetModel), 201)]
        public async Task<IActionResult> PostModel([FromBody] EntregaPostModel model, string matricula, string senha)
        {
            try
            {
                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }


                var entrega = _mapper?.Map<Entrega>(model);
                var result = _entregaDomainService?.Cadastrar(entrega, matricula);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<EntregaGetModel>(result));
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EntregaGetModel), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper?.Map<EntregaGetModel>(_entregaDomainService?.ObterPorId(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EntregaGetModel>), 200)]
        public IActionResult GetAll()
        {
            var entrega = _entregaDomainService?.Consultar();
            var result = _mapper?.Map<List<EntregaGetModel>>(entrega);
            return Ok(result);


        }

        [HttpPut]
        [ProducesResponseType(typeof(EntregaGetModel), 201)]
        public async Task<IActionResult> PutModel([FromBody] EntregaPutModel model, string matricula, string senha)
        {
            try
            {

                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }

                var entrega = _mapper?.Map<Entrega>(model);


                var result = _entregaDomainService?.Atualizar(entrega, matricula);

                var entregaGetModel = _mapper.Map<EntregaGetModel>(result);

                //HTTP 201 (OK)
                return StatusCode(200, new
                {
                    Message = "Produto atualizado com sucesso",
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

        [HttpPut("motoristaAtual")]
        [ProducesResponseType(typeof(EntregaGetModel), 201)]
        public async Task<IActionResult> MotoristaPutModel([FromBody] EntregaPutModel model, string matricula, string senha)
        {
            try
            {

                if (!(await IsUserAuthorized(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }

                var entrega = _mapper?.Map<Entrega>(model);


                var result = _entregaDomainService?.AtualizarMotorista(entrega);

                var entregaGetModel = _mapper.Map<EntregaGetModel>(result);

                //HTTP 201 (OK)
                return StatusCode(200, new
                {
                    Message = "Entrega atualizada com sucesso",
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

        [HttpPut("motorista")]
        [ProducesResponseType(typeof(EntregaGetModel), 201)]
        public async Task<IActionResult> CadastrarMotoristaPutModel([FromBody] EntregaPutModel model)
        {
            try
            {



                var entrega = _mapper?.Map<Entrega>(model);


                var result = _entregaDomainService?.CadastrarMotorista(entrega);

                var entregaGetModel = _mapper.Map<EntregaGetModel>(result);

                //HTTP 201 (OK)
                return StatusCode(200, new
                {
                    Message = "Entrega atualizada com sucesso",
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



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _entregaDomainService?.Delete(id);
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

        [HttpPost("baixaEntrega")]
        [ProducesResponseType(typeof(BaixaEntregaGetModel), 201)]
        public async Task<IActionResult> BaixaEntrega(string matricula, string senha, int id, [FromBody] BaixaEntregaPostModel baixa)
        {
            try
            {
                // Verifique se o usuário está autorizado
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }

                // Execute a baixa de entrega e obtenha o resultado
                var baixaEntrega = _entregaDomainService.BaixaEntrega(id, matricula, baixa.DataEntregaBaixa, baixa.DiaSemanaBaixa);

                if (baixaEntrega != null)
                {
                    // Mapeie o resultado para o modelo de resposta
                    var baixaEntregaGetModel = _mapper.Map<BaixaEntregaGetModel>(baixaEntrega);

                    // Retorne HTTP 201 (CREATED) com o modelo de resposta
                    return StatusCode(201, baixaEntregaGetModel);
                }
                else
                {
                    // Retorne HTTP 400 (BAD REQUEST) se não houver resultado
                    return StatusCode(400, new { error = "Não foi possível realizar a baixa de entrega." });
                }
            }
            catch (Exception e)
            {
                // HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { error = e.Message });
            }
        }



        [HttpGet("baixaEntrega")]
        [ProducesResponseType(typeof(List<BaixaEntregaGetModel>), 200)]
        public IActionResult BaixaEntregaAll()
        {
            try
            {
                var baixaEntrega = _entregaDomainService.ConsultarBaixa();
                var baixaEntregaModel = _mapper.Map<List<BaixaEntregaGetModel>>(baixaEntrega);
                return Ok(baixaEntregaModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { erro = e.Message });
            }
        }


        [HttpPost("pendenciaEntrega")]
        public async Task<IActionResult> PendenciaEntrega(string matricula, string senha, int Id, [FromBody] PendenciaEntregaPostModel pendencia)
        {
            try
            {
                if (await AutenticarUsuario(matricula, senha))
                {
                    _entregaDomainService.PendenciaEntrega(Id, matricula, pendencia.ObservacaoPendencia, pendencia.DiaSemanaPendencia, pendencia.DataEntregaProximaEntrega);
                    return Ok(new { message = "Pendência registrada com sucesso!" });
                }
                else
                {
                    return StatusCode(401, new { message = "Matricula ou senha incorreta, tente novamente" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }



        [HttpGet("pendenciaEntrega")]
        [ProducesResponseType(typeof(List<PendenciaEntregaGetModel>), 200)]
        public IActionResult PendenciaEntregaAll()
        {
            try
            {
                var pendenciaEntrega = _entregaDomainService.ConsultarPendencia();
                var pendenciaEntregaModel = _mapper.Map<List<PendenciaEntregaGetModel>>(pendenciaEntrega);
                return Ok(pendenciaEntregaModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { erro = e.Message });
            }
        }

        [HttpPost("Impressao")]
        public async Task<IActionResult> Impressao(string matricula, string senha, int Id, [FromBody] ImpressaoPostModel impressao)
        {
            try
            {
                if (await AutenticarUsuario(matricula, senha))
                {
                    _entregaDomainService.Impressao(Id, matricula);
                    return Ok(new { message = "impressao registrada com sucesso!" });
                }
                else
                {
                    return StatusCode(401, new { error = "Matricula ou senha incorreta, tente novamente" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }


        [HttpGet("Impressao")]
        [ProducesResponseType(typeof(List<ImpressaoGetModel>), 200)]
        public IActionResult ImpressaoAll()
        {
            try
            {
                var impressao = _entregaDomainService.ConsultarImpressao();
                var impressaomodel = _mapper.Map<List<ImpressaoGetModel>>(impressao);
                return Ok(impressaomodel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { erro = e.Message });
            }
        }



        [HttpPost("Pagamento")]
        [ProducesResponseType(typeof(PagamentoGetModel), 201)]
        public async Task<IActionResult> Pagamento([FromBody] PagamentoPostModel model, string matricula, string senha, int id)
        {
            try
            {
                if (!(await AutenticarUsuario(matricula, senha)))
                {
                    return StatusCode(401, new { error = "Usuário não autorizado." });
                }


                var pagamento = _mapper?.Map<Pagamento>(model);
                var result = _entregaDomainService?.CadastrarPagamento(pagamento, id, matricula);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<PagamentoGetModel>(result));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }



        [HttpGet("Pagamento")]
        [ProducesResponseType(typeof(List<PagamentoGetModel>), 200)]
        public IActionResult PagamentoAll()
        {
            try
            {
                var pagamento = _entregaDomainService.ConsultarPagamento();
                var pagamentomodel = _mapper.Map<List<PagamentoGetModel>>(pagamento);
                return Ok(pagamentomodel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { erro = e.Message });
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
                { "1", "2816" }, // Exemplo: Matricula e senha do usuário 2
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

    }
}
