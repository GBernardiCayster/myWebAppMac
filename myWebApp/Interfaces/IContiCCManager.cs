
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface IContiCCManager
    {
        public List<ContoCC> GetContiCC();

        public string AddContoCC(ContoCC rk);

        public string UpdateContoCC(string IDContoCC, ContoCC rk);

        public ContoCC GetContoCC(string IdContoCC);

        public ContoCC DeleteContoCC(string IdContoCC);
    }
}