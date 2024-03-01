﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace myWebApp.Shared.Models
{

    //Modello di Fattura non direttamente collegato ad una tabella nel DB
    public partial class Fattura
    {


        public TestataFattura Testata { get; set; } = new TestataFattura();

        public List<DettaglioFattura> Righe { get; set; } = new List<DettaglioFattura>();

        public Cliente ClienteFattura { get; set; }

        public ClienteIndirizzo CliInd { get; set; }

        public CondizionePagamento cPag { get; set; }

        public DefaultFatturazione DatiAzienda { get; set; }

    }



    //Classe che descrive la singola riga di dati che si aspetta il Report della Fattura
    public partial class RigaFatturaReport
    {

        public int Anno { get; set; }
        public string NumeroFattura { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string CAP { get; set; }
        public string Localita { get; set; }
        public string Provincia { get; set; }
        public string PartitaIVA { get; set; }

        public DateTime DataFattura { get; set; }

        public string DescrizionePagamento { get; set; }
        public decimal Imponibile { get; set; }
        public decimal NonImponibile { get; set; }
        public decimal Imposta { get; set; }
        public decimal TotaleFattura { get; set; }

        public decimal TotaleRA { get; set; }

        public decimal TotaleENASARCO { get; set; }


        public string RagSocAzienda { get; set; }
        public string IndirizzoAzienda { get; set; }
        public string CAPAzienda { get; set; }
        public string LocalitaAzienda { get; set; }

        public string ProvinciaAzienda { get; set; }
        public string PIVAAzienda { get; set; }
        public int NumeroRiga { get; set; }
        public string Descrizione { get; set; }

        public string Aggiuntiva { get; set; }

        public decimal Quantita { get; set; }
        public decimal Prezzo { get; set; }

        public decimal AliquotaIVA { get; set; }

        public decimal ValoreRiga { get; set; }




    }


}