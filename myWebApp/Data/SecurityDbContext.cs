using Microsoft.EntityFrameworkCore;
using myWebApp.Shared.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace myWebApp.Data {
    public class SecurityDbContext : DbContext {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
        : base(options) {
        }

        public DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            //Le relazioni sono importanti in EF anche per il caso di Foreign Key
            //in cui va rispettato l'ordine di inserimento dei dati al momento della savechanges
            //ad esempio prima la testata di un ordine e poi le righe


            #region INDICI
            modelBuilder.Entity<User>().HasKey(u => new {
                u.UserName
            });

            #endregion




        }



    }
}
