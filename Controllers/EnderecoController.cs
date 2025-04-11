using System.Threading.Tasks;
using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Comandos.ComandosCliente;
using WebApplication1.Comandos.ComandosEndereco;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;
using WebApplication1.Modelos.DAO.EnderecoDAO;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]/{idCliente}")]
    public class EnderecoController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{idEndereco}")]
        public async Task<IActionResult> ListarEnderecoPorId([FromRoute] long idCliente, long idEndereco)
        {
            var comandoListarEnderecoPorId = new ComandoListarEnderecoPorId()
            {
                IdCliente = idCliente,
                IdEndereco = idEndereco
            };

            var resultadoComandoListarEnderecoPorId = await mediator.Send(comandoListarEnderecoPorId);


            if (resultadoComandoListarEnderecoPorId.IsFailed)
            {
                return BadRequest(resultadoComandoListarEnderecoPorId.Errors);
            }

            return Ok(resultadoComandoListarEnderecoPorId.Value);
        }

        [HttpGet()]
        public async Task<IActionResult> ListarEnderecos([FromRoute] long idCliente)
        {
            var comandoListarEnderecos = new ComandoListarEnderecos()
            {
                IdCliente = idCliente,
            };

            var resultadoComandoListarEnderecos = await mediator.Send(comandoListarEnderecos);

            if (resultadoComandoListarEnderecos.IsFailed)
            {
                return BadRequest(resultadoComandoListarEnderecos.Errors);
            }

            return Ok(resultadoComandoListarEnderecos.Value);
        }

        [HttpPost()]
        public async Task<IActionResult> IncluirEndereco([FromRoute] long idCliente, [FromBody] CriarEndereco endereco)
        {

            var comandoCriarEndereco = new ComandoCriarEndereco()
            {
                idCliente = idCliente,
                endereco = endereco
            };

            var resultadoComandoCriarEndereco = await mediator.Send(comandoCriarEndereco);

            if (resultadoComandoCriarEndereco.IsFailed)
            {
                return BadRequest(resultadoComandoCriarEndereco.Errors);
                
            }

            return Ok(resultadoComandoCriarEndereco.Value);

        }

        [HttpPut("{idEndereco}")]
        public async Task<IActionResult> AtualizarEndereco([FromRoute] long idCliente, long idEndereco, [FromBody] CriarEndereco endereco)
        {
            var comandoAtualizarEndereco = new ComandoAtualizarEndereco()
            {
                IdCliente = idCliente,
                IdEndereco = idEndereco,
                Endereco = endereco
            };

            var resultadoComandoAtualizarEndereco = await mediator.Send(comandoAtualizarEndereco);

            if (resultadoComandoAtualizarEndereco.IsFailed)
            {
                return BadRequest(resultadoComandoAtualizarEndereco.Errors);
            }

            return Ok(resultadoComandoAtualizarEndereco.Value);
        }

        [HttpDelete("{idEndereco}")]
        public async Task<IActionResult> RemoverEndereco([FromRoute] long idCliente, long idEndereco)
        {
            var comandoDeletarEndereco = new ComandoDeletarEndereco()
            {
                IdCliente = idCliente,
                IdEndereco = idEndereco,
            };

            var resultadoComandoDeletarEnderco = await mediator.Send(comandoDeletarEndereco);

            if (resultadoComandoDeletarEnderco.IsFailed)
            {
                return BadRequest(resultadoComandoDeletarEnderco.Errors);
            }

            return NoContent();
        }
    }
}

