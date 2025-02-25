using AutoMapper;
using CasaColombo.Domain.Entities.Lojas;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Services.Model.Lojas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaColombo.Services.Controllers.ProdOcorrFornLojas
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly ILojaDomainService? _lojaDomainService;
        private readonly IMapper? _mapper;
        public LojaController

        (ILojaDomainService? lojaDomainService, IMapper? mapper)

        {
            _lojaDomainService = lojaDomainService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<LojaGetModel>), 200)]
        public IActionResult GetAll()
        {
            var lojas = _lojaDomainService?.Consultar();
            var result = _mapper?.Map<List<LojaGetModel>>(lojas);
            return Ok(result);
        }

       
        [HttpPost]
        [ProducesResponseType(typeof(LojaGetModel), 201)]
        public IActionResult PostModel([FromBody] LojaPostModel model)
        {
            try
            {
                //cadastrando o produto
                var loja = _mapper?.Map<Loja>(model);
                var result = _lojaDomainService?.Cadastrar(loja);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<LojaGetModel>(result));
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
                var result = _lojaDomainService?.Delete(id);
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LojaGetModel), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper?.Map<LojaGetModel>(_lojaDomainService?.ObterPorId(id));
                return Ok(result);
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    }

}

