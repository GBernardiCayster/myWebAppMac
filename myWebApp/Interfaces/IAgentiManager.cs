
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface IAgentiManager
    {
        public List<Agente> GetAgenti();

        public string AddAgente(Agente rk);

        public string UpdateAgente(string IDAgente, Agente rk);

        public Agente GetAgente(string IdAgente);

        public Agente DeleteAgente(string IdAgente);
    }
}