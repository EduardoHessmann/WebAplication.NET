using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoListarEnderecoPorIdHandler(IMediator mediator, VHubContext context) : ComandosComunsImpl(mediator), IRequestHandler<ComandoListarEnderecoPorId, Result<Endereco>>
    {
        public async ValueTask<Result<Endereco>> Handle(ComandoListarEnderecoPorId request, CancellationToken cancellationToken)
        {
            var cliente = await BuscarClientePorId(request.IdCliente);

            if (cliente.IsFailed)
            {
                return Result.Fail(cliente.Errors);
            }

            var query = cliente.Value.enderecos.Where(endereco => endereco.Id == request.IdEndereco).First();

            if (query is null)
            {
                return Result.Fail("O endereço não foi encontrado!");
            }

            return query;
        }
    }
}
