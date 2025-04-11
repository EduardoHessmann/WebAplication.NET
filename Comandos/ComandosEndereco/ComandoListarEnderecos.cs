using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoListarEnderecos : IRequest<Result<List<Endereco>>>
    {
        public long IdCliente { get; set; }  
    }
}
