using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoCriarEndereco : IRequest<Result<Endereco>>
    {
        public long idCliente { get; set; }  

        public CriarEndereco endereco { get; set; }

    }
}
