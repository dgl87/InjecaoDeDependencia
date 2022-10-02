using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InjecaoDeDependencia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InjecaoController : ControllerBase
    {
        private IOperacao _operacao;
        private IServiceProvider _provider;
        public InjecaoController(IOperacao operacao, IServiceProvider provider)
        {
            _operacao = operacao;
            _provider = provider;
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(_operacao.Id);
        }

        [HttpGet("Anotacao")]
        public IActionResult Anotacao([FromServices] IOperacao operacao)
        {
            return Ok(operacao.Id);
        }

        [HttpGet("Provider")]
        public IActionResult Provider()
        {
            return Ok(_provider.GetRequiredService<IOperacao>());
        }
    }
}
