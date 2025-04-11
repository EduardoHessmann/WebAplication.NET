using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FluentResults;
using Mediator;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.CepDAO;

namespace WebApplication1.Comandos.ComandosCliente
{
    public class ComandoListarClientesPorCepHandle(IServiceCep serviceCep, IMediator mediator, IMapper mapper) : IRequestHandler<ComandoListarClientesPorCep, Result<List<ResultadoCliente>>>
    {

        public async ValueTask<Result<List<ResultadoCliente>>> Handle(ComandoListarClientesPorCep request, CancellationToken cancellationToken)
        {

            var cep = await serviceCep.ConsultarCep(request.Cep);

            if (cep.IsFailed)
            {
                return Result.Fail(cep.Errors);
            }

            var comandoListarClientes = new ComandoListarClientes();

            var clientes = await mediator.Send(comandoListarClientes);

            //clientes.Where(cliente => cliente.enderecos.Find(endereco => endereco.Cep == request.Cep) != null)
            //    .Select(mapper.Map<Cliente, ResultadoCliente>).ToList();

            //var query = from cliente in clientes
            //            where cliente.enderecos.Find(e => e.Cep == request.Cep) != null
            //            select cliente;

            return clientes.Where(cliente => cliente.enderecos.Find(endereco => endereco.Cep == request.Cep) != null)
                .Select(mapper.Map<Cliente, ResultadoCliente>).ToList(); ;
        }
    }
}
