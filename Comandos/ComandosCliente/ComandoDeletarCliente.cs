using FluentResults;
using Mediator;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoDeletarCliente : IRequest<Result<bool>>
    {
        public long idCliente { get; set; }
    }
}
