using Microsoft.EntityFrameworkCore;
using myWebApp.Shared.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace myWebApp.Data {
    public class mySQLDbContext : DbContext {
        public mySQLDbContext(DbContextOptions<mySQLDbContext> options)
        : base(options) {
        }


        public DbSet<Item> Items { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            //Le relazioni sono importanti in EF anche per il caso di Foreign Key
            //in cui va rispettato l'ordine di inserimento dei dati al momento della savechanges
            //ad esempio prima la testata di un ordine e poi le righe


            #region INDICI
            modelBuilder.Entity<Item>().HasKey(p => new {
                p.Id
            });

            //modelBuilder.Entity<Cliente>().HasKey(p => new {
            //    p.Codice
            //});

            //modelBuilder.Entity<Fornitore>().HasKey(p => new {
            //    p.Codice
            //});

            //modelBuilder.Entity<ClienteIndirizzo>().HasKey(p => new {
            //    p.CodiceCliente,
            //    p.CodiceIndirizzo
            //});





            #endregion

            #region RELAZIONI ORDINI

            //modelBuilder.Entity<RigaOrdineServer>()
            //.HasOne<OrdineServer>()
            //.WithMany(o => o.Righe)
            //.HasForeignKey(o => new { o.Provenienza, o.Tipo, o.Numero, o.Data });

            #endregion

            #region RELAZIONI PROMO
            //modelBuilder.Entity<PromozioneElemento>()
            //.HasOne<PromozioneTestata>()
            //.WithMany(p => p.Elementi)
            //.HasForeignKey(p => p.CodicePromozione);

            //modelBuilder.Entity<PromozioneCondizione>()
            //    .HasOne<PromozioneElemento>()
            //    .WithMany(p => p.Condizioni)
            //    .HasForeignKey(p => new { p.CodicePromozione, p.IDElemento });

            //modelBuilder.Entity<PromozioneArticolo>()
            //    .HasOne<PromozioneElemento>()
            //    .WithMany(p => p.Articoli)
            //    .HasForeignKey(p => new { p.CodicePromozione, p.IDElemento });

            //modelBuilder.Entity<PromozioneOmaggio>()
            //    .HasOne<PromozioneCondizione>()
            //    .WithMany(p => p.Omaggi)
            //    .HasForeignKey(p => new { p.CodicePromozione, p.IDElemento, p.IDCondizione });

            //modelBuilder.Entity<PromozioneQtaMinima>()
            //    .HasOne<PromozioneCondizione>()
            //    .WithMany(p => p.QtaMinime)
            //    .HasForeignKey(p => new { p.CodicePromozione, p.IDElemento, p.IDCondizione });

            //modelBuilder.Entity<PromozioneGruppoAderentiDettaglio>()
            //    .HasOne<PromozioneGruppoAderenti>()
            //    .WithMany(p => p.Dettagli)
            //    .HasForeignKey(p => p.IDGruppo);

            #endregion

        }



    }
}
