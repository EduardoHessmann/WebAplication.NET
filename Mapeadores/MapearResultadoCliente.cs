using AutoMapper;
using WebApplication1.Modelos;

namespace WebApplication1.Mapeadores
{
    public class MapearResultadoCliente : Profile
    {

        public MapearResultadoCliente()
        {
            this.CreateMap<Cliente, ResultadoCliente>(MemberList.Destination);
        }
    }
}
