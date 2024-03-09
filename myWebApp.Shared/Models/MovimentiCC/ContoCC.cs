
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace myWebApp.Shared.Models
{
    [Table("Conti Correnti")]
    public partial class ContoCC
    {
        [Key]

        public string IDContoCC { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }


        [Required]
        [StringLength(1)]
        public string Chiuso { get; set; } = "N";        //S=Si  N=No

        [NotMapped]
        public bool fChiuso {           //Utilizzato per l'editing con uno switch
            get {
                if (Chiuso == "S") {
                    return true;
                }
                else {
                    return false;
                }

            }
            set
            {
                if (value)
                {
                    Chiuso = "S";
                }
                else {
                    Chiuso = "N";
                }
            }
        }

        [StringLength(50)]
        public string? IBAN { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string Default { get; set; } = "N";        //S=Si  N=No

        [NotMapped]
        public bool fDefault        //Utilizzato per l'editing con uno switch
        {
            get
            {
                if (Default == "S")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            set
            {
                if (value)
                {
                    Default = "S";
                }
                else
                {
                    Default = "N";
                }
            }
        }

    }



}