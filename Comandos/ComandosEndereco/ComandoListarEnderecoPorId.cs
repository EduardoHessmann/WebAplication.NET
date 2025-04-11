using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoListarEnderecoPorId : IRequest<Result<Endereco>>
    {
        public long IdCliente { get; set; }
        public long IdEndereco { get; set; }
    }
}
