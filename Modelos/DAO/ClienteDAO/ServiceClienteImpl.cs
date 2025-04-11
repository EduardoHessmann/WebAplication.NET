//using AutoMapper;
//using WebApplication1.Context;

//namespace WebApplication1.Modelos.DAO.ClienteDAO
//{
//    public class ServiceClienteImpl(VHubContext context ,IMapper mapper) : IserviceCliente
//    {

//        public Cliente? AtualizarCliente(CriarCliente cliente, int id)
//        {

//            var clienteEncontrado = context.Cliente.FirstOrDefault(procurarCliente => procurarCliente.Id == id);

//            if (cliente == -1)
//            {
//                return null;
//            }

//            var clienteExistente = Clientes[indice];
//            mapper.Map(cliente, clienteExistente);
//            return clienteExistente;

//        }

//        public Cliente? IncluirCliente(CriarCliente cliente)
//        {

//            var novoCliente = new Cliente();
//            novoCliente = mapper.Map<CriarCliente, Cliente>(cliente);

//            novoCliente.Id = IdCliente++;

//            Clientes.Add(novoCliente);

//            return novoCliente;

//        }

//        public Cliente? ListarClientePorId(int id)
//        {
//            var indice = Clientes.FindIndex(procurarCliente => procurarCliente.Id == id);

//            if (indice == -1)
//            {

//                return null;

//            }

//            return Clientes[indice];

//        }

//        public List<Cliente> ListarClientes()
//        {
//            return Clientes;

//        }

//        public bool RemoverCliente(int id)
//        {
//            var indice = Clientes.FindIndex(procurarCliente => procurarCliente.Id == id);

//            if (indice == -1)
//            {

//                return false;

//            }

//            Clientes.RemoveAt(indice);

//            return true;

//        }
//    }
//}
