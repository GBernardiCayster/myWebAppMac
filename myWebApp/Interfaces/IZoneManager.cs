
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface IZoneManager
    {
        public List<Zona> GetZone();

        public string AddZona(Zona rk);

        public string UpdateZona(string IDZona, Zona rk);

        public Zona GetZona(string IdZona);

        public Zona DeleteZona(string IdZona);
    }
}