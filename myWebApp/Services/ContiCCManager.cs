using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class ContiCCManager : IContiCCManager
    {
        readonly mySQLDbContext _dbContext;

        public ContiCCManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks ContiCC
        public List<ContoCC> GetContiCC()
        {
            try
            {
                return _dbContext.ContiCC.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<ContoCC>();
            }
        }

        //Aggiungo un ContoCC  
        public string AddContoCC(ContoCC rk)
        {
            try
            {
                _dbContext.ContiCC.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk ContoCC  
        public string UpdateContoCC(string IdContoCC, ContoCC rk)
        {
            if (IdContoCC != rk.IDContoCC) {
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

        //Leggo un Rk ContoCC  
        public ContoCC GetContoCC(string codice)
        {
            try
            {
                ContoCC? rk = _dbContext.ContiCC.Find(codice);

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

        //Rimozione di un Rk ContoCC    
        public ContoCC DeleteContoCC(string IdContoCC)
        {
            ContoCC? rk;

            try
            {
                rk = _dbContext.ContiCC.Find(IdContoCC);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.ContiCC.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex) {
                        //Errore tipicamente in caso di foreign key violation
                        return new ContoCC{ Descrizione = "KO" };
                    }
                    
                }
                else
                {
                    return new ContoCC { Descrizione = "NOTFOUND" };
                }
            }
            catch
            {
                return new ContoCC { Descrizione = "KO" };
            }
            return rk;
        }
    }
}

