
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface IClientiManager
    {
        public List<Cliente> GetClienti();

        public string AddCliente(Cliente rk);

        public string UpdateCliente(string IDCliente, Cliente rk);

        public Cliente GetCliente(string IdCliente);

        public Cliente DeleteCliente(string IdCliente);
    }
}