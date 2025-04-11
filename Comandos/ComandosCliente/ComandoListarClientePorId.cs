using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoListarClientePorId : IRequest<Result<Cliente>>
    {
        public long idCliente { get; set; }
    }
}
