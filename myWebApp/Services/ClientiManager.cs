using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class ClientiManager : IClientiManager
    {
        readonly mySQLDbContext _dbContext;

        public ClientiManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks Clienti
        public List<Cliente> GetClienti()
        {
            try
            {
                return _dbContext.Clienti.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<Cliente>();
            }
        }

        //Aggiungo un Cliente  
        public string AddCliente(Cliente rk)
        {
            try
            {
                _dbContext.Clienti.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk Cliente  
        public string UpdateCliente(string IdCliente, Cliente rk)
        {
            if (IdCliente != rk.IDCliente) {
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

        //Leggo un Rk Cliente  
        public Cliente GetCliente(string codice)
        {
            try
            {
                Cliente? rk = _dbContext.Clienti.Find(codice);

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

        //Rimozione di un Rk Cliente    
        public Cliente DeleteCliente(string IdCliente)
        {
            Cliente? rk;

            try
            {
                rk = _dbContext.Clienti.Find(IdCliente);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.Clienti.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new Cliente { RagioneSociale = "KO" };
                    }

                }
                else
                {
                    return new Cliente { RagioneSociale = "NOTFOUND" };
                }
            }
            catch
            {
                return new Cliente { RagioneSociale = "KO" };
            }
            return rk;
        }



    }
}

