using AutoMapper;
using CasaColombo.Domain.Entities.Depositoss;
using CasaColombo.Domain.Interfaces.Services.IProdOcorrFornLojas;
using CasaColombo.Services.Model.Depositos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasaColombo.Services.Controllers.ProdOcorrFornLojas
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositosController : ControllerBase
    {
        private readonly IDepositosDomainService? _depositosDomainService;
        private readonly IMapper? _mapper;

        public DepositosController
            (IDepositosDomainService? depositosDomainService, IMapper? mapper)
        {
            _depositosDomainService = depositosDomainService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DepositosGetModel>), 200)]
        public IActionResult GetAll()
        {
            var depositos = _depositosDomainService?.Consultar();
            var result = _mapper?.Map<List<DepositosGetModel>>(depositos);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(DepositosGetModel), 201)]
        public IActionResult PostModel([FromBody] DepositosPostModel model)
        {
            try
            {

                var depositos = _mapper?.Map<Depositos>(model);
                var result = _depositosDomainService?.Cadastrar(depositos);

                //HTTP 201 (CREATED)
                return StatusCode(201, _mapper.Map<DepositosGetModel>(result));
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DepositosGetModel), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _mapper?.Map<DepositosGetModel>(_depositosDomainService?.ObterPorId(id));
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
