using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InjecaoDeDependencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InjecaoController : ControllerBase
    {
        private readonly IOperacaoSccoped _sccoped;
        private readonly IOperacaoTransient _transient;
        private readonly IOperacaoSingleton _singleton;
        public InjecaoController(
            IOperacaoSccoped sccoped, 
            IOperacaoTransient transient, 
            IOperacaoSingleton singleton)
        {
            _sccoped = sccoped;
            _transient = transient;
            _singleton = singleton;
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor(
            [FromServices] IOperacaoSccoped sccoped, 
            [FromServices] IOperacaoTransient transient, 
            [FromServices] IOperacaoSingleton singleton)
        {
            return Ok(new
            {
                Transient = _transient.Id,
                Sccoped = _sccoped.Id,
                Singleton = _singleton.Id,

                Transient02 = transient.Id,
                Sccoped02 = sccoped.Id,
                Singleton02 = singleton.Id,
            });
        }        
    }
}
