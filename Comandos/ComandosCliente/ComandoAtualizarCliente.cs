using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoAtualizarCliente : IRequest<Result<Cliente>>
    {
        public long idCliente {  get; set; }
        public CriarCliente cliente { get; set; } 
    }
}
