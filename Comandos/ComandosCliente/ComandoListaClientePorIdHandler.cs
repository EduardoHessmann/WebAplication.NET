using FluentResults;
using Mediator;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoListaClientePorIdHandler(VHubContext context) : IRequestHandler<ComandoListarClientePorId, Result<Cliente>>
    {
        public async ValueTask<Result<Cliente>> Handle(ComandoListarClientePorId request, CancellationToken cancellationToken)
        {

            var query = await context.Cliente.Where(cliente => cliente.Id == request.idCliente).FirstOrDefaultAsync();

            //var indice = serviceCliente.Clientes.FindIndex(procurarCliente => procurarCliente.Id == request.idCliente);

            if (query is null)
            {
                return Result.Fail("O cliente não foi encontrado!");
            }

            return query;
        }
    }
}
