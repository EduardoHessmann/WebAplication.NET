using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosCliente;
using WebApplication1.Comandos.ComandosEndereco;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosComuns
{
    public class ComandosComunsImpl(IMediator mediator)
    {
        
        public async Task<Result<Cliente>> BuscarClientePorId(long idCliente)
        {
            var comandoListarClientePorId = new ComandoListarClientePorId()
            {
                idCliente = idCliente,
            };

            var resultadoComandoListarClientePorId = await mediator.Send(comandoListarClientePorId);

            if (resultadoComandoListarClientePorId.IsFailed)
            {
                return Result.Fail(resultadoComandoListarClientePorId.Errors);
            }

            return resultadoComandoListarClientePorId;
        }

        public async ValueTask<Result<Endereco>> BuscarEnderecoPorId(long idCliente, long idEndereco)
        {
            var comandoListarEnderecoPorId = new ComandoListarEnderecoPorId()
            {
                IdCliente = idCliente,
                IdEndereco = idEndereco,
            };

            var resultadoComandoListarEnderecoPorId = await mediator.Send(comandoListarEnderecoPorId);

            if (resultadoComandoListarEnderecoPorId.IsFailed)
            {
                return Result.Fail(resultadoComandoListarEnderecoPorId.Errors);
            }

            return resultadoComandoListarEnderecoPorId;
        }


    }
}
