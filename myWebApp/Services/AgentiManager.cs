using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class AgentiManager : IAgentiManager
    {
        readonly mySQLDbContext _dbContext;

        public AgentiManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks Agenti
        public List<Agente> GetAgenti()
        {
            try
            {
                return _dbContext.Agenti.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<Agente>();
            }
        }

        //Aggiungo un Agente  
        public string AddAgente(Agente rk)
        {
            try
            {
                _dbContext.Agenti.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk Agente  
        public string UpdateAgente(string IdAgente, Agente rk)
        {
            if (IdAgente != rk.IDAgente) {
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

        //Leggo un Rk Agente  
        public Agente GetAgente(string IDAgente)
        {
            try
            {
                Agente? rk = _dbContext.Agenti.Find(IDAgente);

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

        //Rimozione di un Rk Agente    
        public Agente DeleteAgente(string IdAgente)
        {
            Agente? rk;

            try
            {
                rk = _dbContext.Agenti.Find(IdAgente);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.Agenti.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new Agente { RagioneSociale = "KO" };
                    }

                }
                else
                {
                    return new Agente { RagioneSociale = "NOTFOUND" };
                }
            }
            catch
            {
                return new Agente { RagioneSociale = "KO" };
            }
            return rk;
        }



    }
}

