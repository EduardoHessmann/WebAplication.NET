using AutoMapper;
using FluentResults;
using Mediator;
using Microsoft.AspNetCore.Components.Forms;
using WebApplication1.Comandos.ComandosCliente;
using WebApplication1.Comandos.ComandosComuns;
using WebApplication1.Context;
using WebApplication1.Modelos;
using WebApplication1.Modelos.DAO.CepDAO;
using WebApplication1.Modelos.DAO.ClienteDAO;

namespace WebApplication1.Comandos.ComandosEndereco
{
    public class ComandoAtualizarEnderecoHandler(IMediator mediator, IMapper mapper, IServiceCep serviceCep, VHubContext context) : ComandosComunsImpl(mediator), IRequestHandler<ComandoAtualizarEndereco, Result<Endereco>>
    {
        public async ValueTask<Result<Endereco>> Handle(ComandoAtualizarEndereco request, CancellationToken cancellationToken)
        {
            var enderecoExistente = await BuscarEnderecoPorId(request.IdCliente, request.IdCliente);

            if (enderecoExistente.IsFailed)
            {
                return Result.Fail(enderecoExistente.Errors);
            }

            var cep = await serviceCep.ConsultarCep(request.Endereco.Cep);

            if (cep.IsSuccess)
            {
                mapper.Map(request.Endereco, enderecoExistente.Value);
                mapper.Map(cep.Value, enderecoExistente.Value);

                await context.SaveChangesAsync();

                return enderecoExistente;
            }
            else
            {
                return Result.Fail(cep.Errors);
            }
        }
    }
}
