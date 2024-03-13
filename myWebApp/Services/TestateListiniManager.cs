using myWebApp.Interfaces;
using myWebApp.Data;
using myWebApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace myWebApp.Services
{
    public class TestateListiniManager : ITestateListiniManager
    {
        readonly mySQLDbContext _dbContext;

        public TestateListiniManager(mySQLDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        //Leggo tutti i Rks TestateListini
        public List<TestataListino> GetTestateListini()
        {
            try
            {
                return _dbContext.TestateListini.ToList();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return new List<TestataListino>();
            }
        }

        //Aggiungo un record TestataListino  
        public string AddTestataListino(TestataListino rk)
        {
            try
            {
                _dbContext.TestateListini.Add(rk);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Possible invalid data or Key already exist
                return "KO";
            }
            return "OK";
        }

        //Update di un Rk TestataListino  
        public string UpdateTestataListino(string IDListino, TestataListino rk)
        {
            if (IDListino != rk.IDListino) {
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

        //Leggo un Rk TestataListino  
        public TestataListino GetTestataListino(string IDListino)
        {
            try
            {
                TestataListino? rk = _dbContext.TestateListini.Find(IDListino);

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

        //Rimozione di un Rk TestataListino    
        public TestataListino DeleteTestataListino(string IDListino)
        {
            TestataListino? rk;

            try
            {
                rk = _dbContext.TestateListini.Find(IDListino);

                if (rk != null)
                {
                    try
                    {
                        _dbContext.TestateListini.Remove(rk);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        //Errore tipicamente in caso di foreign key violation
                        return new TestataListino { Descrizione = "KO" };
                    }

                }
                else
                {
                    return new TestataListino { Descrizione = "NOTFOUND" };
                }
            }
            catch
            {
                return new TestataListino { Descrizione = "KO" };
            }
            return rk;
        }



    }
}

