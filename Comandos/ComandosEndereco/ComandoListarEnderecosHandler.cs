using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosCliente;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoListarEnderecosHandler(IMediator mediator, VHubContext context) : ComandosComunsImpl(mediator), IRequestHandler<ComandoListarEnderecos, Result<List<Endereco>>>
    {
        public async ValueTask<Result<List<Endereco>>> Handle(ComandoListarEnderecos request, CancellationToken cancellationToken)
        {
            var cliente = await BuscarClientePorId(request.IdCliente);

            if (cliente.IsFailed)
            {
                return Result.Fail(cliente.Errors);
            }

            return cliente.Value.enderecos;
        }
    }
}
