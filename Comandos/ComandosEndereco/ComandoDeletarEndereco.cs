using FluentResults;
using Mediator;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoDeletarEndereco : IRequest<Result<bool>>
    {
        public long IdCliente { get; set; }
        public long IdEndereco { get; set; } 
    }
}
