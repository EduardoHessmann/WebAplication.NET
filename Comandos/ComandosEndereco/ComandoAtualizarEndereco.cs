using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoAtualizarEndereco : IRequest<Result<Endereco>>
    {
        public long IdCliente { get; set; }
        public long IdEndereco { get; set; }
        public CriarEndereco Endereco { get; set; }
    }
}
