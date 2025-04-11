using Mediator;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoListarClientesHandler(VHubContext context) : IRequestHandler<ComandoListarClientes, List<Cliente>>
    {
        public async ValueTask<List<Cliente>> Handle(ComandoListarClientes request, CancellationToken cancellationToken)
        {
            return await context.Cliente.OrderBy(cliente => cliente.Id).ToListAsync();
        }
    }
}
