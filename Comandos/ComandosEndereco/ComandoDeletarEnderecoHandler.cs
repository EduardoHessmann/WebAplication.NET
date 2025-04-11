using FluentResults;
using Mediator;
using WebApplication1.Modelos.DAO.ClienteDAO;
using WebApplication1.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoDeletarEnderecoHandler(IMediator mediator, VHubContext context) : ComandosComunsImpl(mediator), IRequestHandler<ComandoDeletarEndereco, Result<bool>>
    {
        public async ValueTask<Result<bool>> Handle(ComandoDeletarEndereco request, CancellationToken cancellationToken)
        {

            var cliente = await BuscarClientePorId(request.IdCliente);
            var endereco = await BuscarEnderecoPorId(request.IdCliente, request.IdEndereco);

            if (endereco.IsFailed)
            {
                return Result.Fail(endereco.Errors);
            }

            cliente.Value.enderecos.Remove(endereco.Value);

            await context.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
