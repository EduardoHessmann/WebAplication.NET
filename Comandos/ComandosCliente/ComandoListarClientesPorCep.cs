using FluentResults;
using Mediator;
using WebApplication1.Modelos;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoListarClientesPorCep : IRequest<Result<List<ResultadoCliente>>>
    {
        public string Cep { get; set; }
    }
}
