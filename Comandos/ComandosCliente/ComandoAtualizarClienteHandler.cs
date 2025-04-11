using AutoMapper;
using FluentResults;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoAtualizarClienteHandler(IMediator mediator, VHubContext context, IMapper mapper ) : ComandosComunsImpl(mediator), IRequestHandler<ComandoAtualizarCliente, Result<Cliente>>
    {
        public async ValueTask<Result<Cliente>> Handle(ComandoAtualizarCliente request, CancellationToken cancellationToken)
        {
            var cliente = await BuscarClientePorId(request.idCliente);

            if (cliente.IsFailed)
            {
                return Result.Fail(cliente.Errors);
            }

            mapper.Map(request.cliente, cliente.Value);

            await context.SaveChangesAsync();

            return cliente.Value;
        }
    }
}
