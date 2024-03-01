
using System;
using System.Collections.Generic;


namespace myWebApp.Shared.Models
{


    public partial class SchedaAndamentoCC
    {

        public string Descrizione { get; set; } = string.Empty;     //Descrizione di Azienda e Conto

        public string ContoCC { get; set; } = string.Empty;         //N. Conto CC

        public int Anno { get; set; }

        public List<AndamentoCC> array_AndamentoCC { get; set; } = new();



        public decimal SaldoPeriodo { get; set; } = 0;

    }

    public partial class AndamentoCC
    {

        public int Anno { get; set; }

        public int Mese { get; set; }

        public string MeseDescr { get; set; }

        public decimal Entrate { get; set; } = 0;

        public decimal Uscite { get; set; } = 0;

        public decimal Saldo { get; set; } = 0;

        public decimal SaldoPeriodo { get; set; } = 0;


    }



}