using System.Threading.Tasks;
using Asp.Versioning;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Comandos;
using WebApplication1.Comandos.ComandosCliente;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarClientePorId([FromRoute] long id)
        {
            var comandoListarClientePorId = new ComandoListarClientePorId()
            {
                idCliente = id,
            };

            var ResultadoComandoListarClientePorId = await mediator.Send(comandoListarClientePorId);

            if (ResultadoComandoListarClientePorId.IsFailed)
            {
                return BadRequest(ResultadoComandoListarClientePorId.Errors);
            }

            return Ok(ResultadoComandoListarClientePorId.Value);

        }

        [HttpGet("clientes/{cep}")]
        public async Task<IActionResult> ListarClientesPorCep([FromRoute] string cep)
        {
            var ComandoListarClientesPorCep = new ComandoListarClientesPorCep()
            {
                Cep = cep,
            };

            var resultadoComandoListarClientesPorCep = await mediator.Send(ComandoListarClientesPorCep);

            if (resultadoComandoListarClientesPorCep.IsFailed)
            {
                return BadRequest(resultadoComandoListarClientesPorCep.Errors);
            }

            return Ok(resultadoComandoListarClientesPorCep.Value);

        }

        [HttpGet()]
        public async Task<IActionResult> ListarClientes()
        {

            var comandoListarClientes = new ComandoListarClientes();

            var resultadoComadoListarClientes = await mediator.Send(comandoListarClientes);

            return Ok(resultadoComadoListarClientes);

        }

        [HttpPost()]
        public async Task<IActionResult> IncluirCliente([FromBody] CriarCliente cliente)
        {
            var comandoCriarCliente = new ComandoCriarCliente()
            {
                Cliente = cliente,
            };

            var resultadoComandoCriarCliente = await mediator.Send(comandoCriarCliente);
            if (resultadoComandoCriarCliente.IsFailed)
            {
                return BadRequest(resultadoComandoCriarCliente.Errors);

            }

            return Ok(resultadoComandoCriarCliente.Value);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente([FromBody] CriarCliente cliente, [FromRoute] long id)
        {
            var comandoAtualizarCliente = new ComandoAtualizarCliente()
            {
                cliente = cliente,
                idCliente = id,
            };

            var resultadoComandoAtualizarCliente = await mediator.Send(comandoAtualizarCliente);

            if (resultadoComandoAtualizarCliente.IsFailed)
            {
                return BadRequest(resultadoComandoAtualizarCliente.Errors);
            }

            return Ok(resultadoComandoAtualizarCliente.Value);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCliente([FromRoute] long id)
        {
            var comandoDeletarCliente = new ComandoDeletarCliente()
            {
                idCliente = id,
            };

            var resultadoComandoDeletarCliente = await mediator.Send(comandoDeletarCliente);

            if (resultadoComandoDeletarCliente.IsFailed)
            {
                return BadRequest(resultadoComandoDeletarCliente.Errors);
            }

            return NoContent();

        }
    }
}
