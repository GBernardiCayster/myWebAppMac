
using System;
using System.Collections.Generic;


namespace myWebApp.Shared.Models
{

    public partial class SchedaCC
    {

        public string Descrizione { get; set; } = string.Empty;     //Descrizione di Azienda e Conto

        public string ContoCC { get; set; } = string.Empty;         //N. Conto CC

        public DateTime dtStart { get; set; }

        public DateTime dtEnd { get; set; }

        public Decimal Saldo { get; set; }

        public Decimal SaldoVerificati { get; set; }

        public Decimal Carte { get; set; }

        public string TipoMov { get; set; } = "X";       //C=Carta, N=Normali, X=Entrambi

        public string Verificati { get; set; } = "X";     //S=Si, N=No, X=Entrambi

        public List<MovimentoCC> array_MovimentiCC { get; set; } = new();


    }


    public partial class SchedaCCTMP
    {

        public string Descrizione { get; set; } = string.Empty;     //Descrizione di Azienda e Conto

        public string ContoCC { get; set; } = string.Empty;         //N. Conto CC

        public DateTime dtStart { get; set; }

        public DateTime dtEnd { get; set; }

        public string Collegati { get; set; } = "X";     //S=Si, N=No, X=Entrambi

        public List<MovimentoCCTMP> array_MovimentiCC { get; set; } = new();


    }


}