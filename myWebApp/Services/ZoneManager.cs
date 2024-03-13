using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class ZoneManager : IZoneManager
    {
        readonly mySQLDbContext _dbContext;

        public ZoneManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks Zone
        public List<Zona> GetZone()
        {
            try
            {
                return _dbContext.Zone.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<Zona>();
            }
        }

        //Aggiungo un Zona  
        public string AddZona(Zona rk)
        {
            try
            {
                _dbContext.Zone.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk Zona  
        public string UpdateZona(string IdZona, Zona rk)
        {
            if (IdZona != rk.IDZona) {
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

        //Leggo un Rk Zona  
        public Zona GetZona(string codice)
        {
            try
            {
                Zona? rk = _dbContext.Zone.Find(codice);

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

        //Rimozione di un Rk Zona    
        public Zona DeleteZona(string IdZona)
        {
            Zona? rk;

            try
            {
                rk = _dbContext.Zone.Find(IdZona);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.Zone.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new Zona { Descrizione = "KO" };
                    }

                }
                else
                {
                    return new Zona { Descrizione = "NOTFOUND" };
                }
            }
            catch
            {
                return new Zona { Descrizione = "KO" };
            }
            return rk;
        }



    }
}

