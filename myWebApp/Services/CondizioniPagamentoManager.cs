using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class CondizioniPagamentoManager : ICondizioniPagamentoManager
    {
        readonly mySQLDbContext _dbContext;

        public CondizioniPagamentoManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks CondizioniPagamento
        public List<CondizionePagamento> GetCondizioniPagamento()
        {
            try
            {
                return _dbContext.CondizioniPagamento.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<CondizionePagamento>();
            }
        }

        //Aggiungo un CondizionePagamento  
        public string AddCondizionePagamento(CondizionePagamento rk)
        {
            try
            {
                _dbContext.CondizioniPagamento.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk CondizionePagamento  
        public string UpdateCondizionePagamento(string IDPagamento, CondizionePagamento rk)
        {
            if (IDPagamento != rk.IDPagamento) {
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

        //Leggo un Rk CondizionePagamento  
        public CondizionePagamento GetCondizionePagamento(string IDPagamento)
        {
            try
            {
                CondizionePagamento? rk = _dbContext.CondizioniPagamento.Find(IDPagamento);

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

        //Rimozione di un Rk CondizionePagamento    
        public CondizionePagamento DeleteCondizionePagamento(string IDPagamento)
        {
            CondizionePagamento? rk;

            try
            {
                rk = _dbContext.CondizioniPagamento.Find(IDPagamento);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.CondizioniPagamento.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new CondizionePagamento { Descrizione = "KO" };
                    }

                }
                else
                {
                    return new CondizionePagamento { Descrizione = "NOTFOUND" };
                }
            }
            catch
            {
                return new CondizionePagamento { Descrizione = "KO" };
            }
            return rk;
        }



    }
}

