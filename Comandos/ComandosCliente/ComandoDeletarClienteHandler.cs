using AutoMapper;
using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoDeletarClienteHandler(IMediator mediator, VHubContext context, IMapper mapper) : ComandosComunsImpl(mediator), IRequestHandler<ComandoDeletarCliente, Result<bool>>
    {
        public async ValueTask<Result<bool>> Handle(ComandoDeletarCliente request, CancellationToken cancellationToken)
        {
            var cliente = await BuscarClientePorId(request.idCliente);

            if (cliente.IsFailed)
            {
                return Result.Fail(cliente.Errors);
            }

            context.Cliente.Remove(cliente.Value);

            await context.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
