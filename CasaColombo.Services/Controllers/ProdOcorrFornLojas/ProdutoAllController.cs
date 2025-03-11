using AutoMapper;
using CasaColombo.Domain.Entities.Produtos;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Services.Model.Produtos;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CasaColombo.Services.Controllers.ProdOcorrFornLojas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoAllController : ControllerBase
    {
        private readonly IProdutoAllDomainService _produtoAllDomainService;
        private readonly IMapper _mapper;

        public ProdutoAllController(IProdutoAllDomainService produtoAllDomainService, IMapper mapper)
        {
            _produtoAllDomainService = produtoAllDomainService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoAllGetModel>), 200)]
        public IActionResult GetAll()
        {
            var produtos = _produtoAllDomainService.Consultar();
            var result = _mapper.Map<List<ProdutoAllGetModel>>(produtos);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult PutModel([FromBody] ProdutoAllPutModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("O produto nao pode ser nulo.");
                }
                var produto = new ProdutoAll
                {
                    Id = model.Id,
                    NomeProduto = model.NomeProduto,
                    CodigoFornecedor = model.CodigoFornecedor,
                    Codigo = model.Codigo,
                    DataHoraAlteracao = DateTime.Now
                };
                var result = _produtoAllDomainService.Atualizar(produto);
                return StatusCode(201, new
                {
                    Message = "Fornecedor atualizado com sucesso",
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

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoAllGetModel), 201)]
        public IActionResult PostModel([FromBody] ProdutoAllPostModel model)
        {
            try
            {
                var produto = _mapper.Map<ProdutoAll>(model);
                var result = _produtoAllDomainService.Cadastrar(produto);
                return StatusCode(201, new
                {
                    Message = "Produto cadastrado com sucesso",
                    result
                });
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
                var result = _produtoAllDomainService.Delete(id);
                return StatusCode(201, new
                {
                    Message = "Produto excluido com sucesso",
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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoAllGetModel), 200)]

        public IActionResult Get(int id)
        {
            try
            {
                var result = _mapper?.Map<ProdutoAllGetModel>(_produtoAllDomainService?.ObterPorId(id));
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

        [HttpGet("codigo")]
        [ProducesResponseType(typeof(ProdutoAllGetModel), 200)]
        public IActionResult GetByCodigo(string codigo)
        {
            try
            {
                var result = _mapper?.Map<ProdutoAllGetModel>(_produtoAllDomainService?.GetByCodigo(codigo));
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

        [HttpPost("upload-cadastro")]
        public async Task<IActionResult> UploadCadastrar(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "Arquivo inválido." });
            }

            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    var erros = new List<string>();
                    var produtosParaCadastro = new List<(string Codigo, string NomeProduto)>();

                    try
                    {
                        // Configuração para lidar com aspas duplas
                        csv.Context.Configuration.HasHeaderRecord = false;
                        csv.Context.Configuration.Delimiter = ",";

                        while (csv.Read())
                        {
                            try
                            {
                                var codigo = csv.GetField(0).Trim();
                                var nomeProduto = csv.GetField(1).Trim();

                                produtosParaCadastro.Add((codigo, nomeProduto));
                            }
                            catch (CsvHelper.ReaderException ex)
                            {
                                erros.Add($"Erro na linha  {ex.Message}");
                            }
                        }
                    }
                    catch (CsvHelper.ReaderException ex)
                    {
                        return BadRequest(new { error = $"Erro ao ler o arquivo CSV: {ex.Message}" });
                    }

                    foreach (var produto in produtosParaCadastro)
                    {
                        try
                        {
                            _produtoAllDomainService.UploadCadastrar(produto.Codigo, produto.NomeProduto);
                        }
                        catch (ApplicationException ex)
                        {
                            erros.Add($"Erro ao cadastrar o produto {produto.Codigo}: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            erros.Add($"Erro inesperado ao cadastrar o produto {produto.Codigo}: {ex.Message}");
                        }
                    }

                    if (erros.Any())
                    {
                        return StatusCode(207, new { message = "Processo concluído, mas alguns produtos não foram cadastrados.", erros });
                    }
                }

                return Ok(new { message = "Produtos cadastrados com sucesso!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = e.Message });
            }
        }


    }
}
