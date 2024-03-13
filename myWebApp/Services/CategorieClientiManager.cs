using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class CategorieClientiManager : ICategorieClientiManager
    {
        readonly mySQLDbContext _dbContext;

        public CategorieClientiManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks CategorieClienti
        public List<CategoriaClienti> GetCategorieClienti()
        {
            try
            {
                return _dbContext.CategorieClienti.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<CategoriaClienti>();
            }
        }

        //Aggiungo un CategoriaClienti  
        public string AddCategoriaClienti(CategoriaClienti rk)
        {
            try
            {
                _dbContext.CategorieClienti.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk CategoriaClienti  
        public string UpdateCategoriaClienti(string IDCategoria, CategoriaClienti rk)
        {
            if (IDCategoria != rk.IDCategoria) {
                return "NOTFOUND";
            }
            try
            {
                _dbContext.Entry(rk).State = EntityState.Modified;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return "KO";
            }
            return "OK";
        }

        //Leggo un Rk CategoriaClienti  
        public CategoriaClienti GetCategoriaClienti(string IDCategoria)
        {
            try
            {
                CategoriaClienti? rk = _dbContext.CategorieClienti.Find(IDCategoria);

                if (rk != null)
                {
                    return rk;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //Rimozione di un Rk CategoriaClienti    
        public CategoriaClienti DeleteCategoriaClienti(string IDCategoria)
        {
            CategoriaClienti? rk;

            try
            {
                rk = _dbContext.CategorieClienti.Find(IDCategoria);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.CategorieClienti.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new CategoriaClienti { Descrizione = "KO" };
                    }

                }
                else
                {
                    return new CategoriaClienti { Descrizione = "NOTFOUND" };
                }
            }
            catch
            {
                return new CategoriaClienti { Descrizione = "KO" };
            }
            return rk;
        }



    }
}

