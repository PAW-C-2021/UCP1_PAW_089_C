using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_089_C.Models
{
    public partial class Penjual
    {
        public int IdPenjual { get; set; }
        public string NamaPenjual { get; set; }
        public string EmailPenjual { get; set; }
        public string Alamat { get; set; }
        public string NoHpPenjual { get; set; }
        public int? IdProduk { get; set; }

        public virtual Product IdProdukNavigation { get; set; }
    }
}
