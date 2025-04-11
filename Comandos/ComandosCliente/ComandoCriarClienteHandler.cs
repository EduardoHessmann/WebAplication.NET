using AutoMapper;
using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoCriarClienteHandler(VHubContext context, IMapper mapper) : IRequestHandler<ComandoCriarCliente, Result<Cliente>>
    {
        public async ValueTask<Result<Cliente>> Handle(ComandoCriarCliente request, CancellationToken cancellationToken)
        {

            var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var novoCliente = new Cliente();
                novoCliente = mapper.Map<CriarCliente, Cliente>(request.Cliente);

                await context.Cliente.AddAsync(novoCliente);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return novoCliente;
            }
            catch (Exception ex)
            {

                transaction.Rollback();
                return Result.Fail(ex.Message);
            }
        }
    }
}
