using AutoMapper;
using FluentResults;
using Mediator;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.CepDAO;
using WebApplication1.Modelos.DAO.ClienteDAO;
using WebApplication1.Modelos.DAO.EnderecoDAO;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoCriarEnderecoHandler(IMediator mediator, IMapper mapper, IServiceCep serviceCep, VHubContext context) : ComandosComunsImpl(mediator), IRequestHandler<ComandoCriarEndereco, Result<Endereco>>
    {
        public async ValueTask<Result<Endereco>> Handle(ComandoCriarEndereco request, CancellationToken cancellationToken)
        {

            var cliente = await BuscarClientePorId(request.idCliente);

            if (cliente.IsFailed)
            {

                return Result.Fail(cliente.Errors);

            }

            var cep = await serviceCep.ConsultarCep(request.endereco.Cep);

            if (cep.IsSuccess)
            {
                var novoEndereco = new Endereco();
                mapper.Map(request.endereco, novoEndereco);
                mapper.Map(cep.Value, novoEndereco);

                cliente.Value.enderecos.Add(novoEndereco);

                await context.SaveChangesAsync();

                return novoEndereco;

            }
            else
            {
                return Result.Fail(cep.Errors);
            }
        }
    }
}
