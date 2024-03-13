
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface ICategorieClientiManager
    {
        public List<CategoriaClienti> GetCategorieClienti();

        public string AddCategoriaClienti(CategoriaClienti rk);

        public string UpdateCategoriaClienti(string IDCategoria, CategoriaClienti rk);

        public CategoriaClienti GetCategoriaClienti(string IdCategoria);

        public CategoriaClienti DeleteCategoriaClienti(string IdCategoria);
    }
}