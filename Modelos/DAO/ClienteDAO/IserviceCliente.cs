namespace WebApplication1.Modelos.DAO.ClienteDAO
{
    public interface IserviceCliente
    {
        public Cliente? ListarClientePorId(int id);

        public List<Cliente> ListarClientes();

        public Cliente? IncluirCliente(CriarCliente cliente);

        public Cliente? AtualizarCliente(CriarCliente cliente, int id);

        public bool RemoverCliente(int id);

    }
}
