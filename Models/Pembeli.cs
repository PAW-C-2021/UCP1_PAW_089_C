using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_089_C.Models
{
    public partial class Pembeli
    {
        public int IdPembeli { get; set; }
        public string NamaPembeli { get; set; }
        public string NoHpPembeli { get; set; }
        public int? IdTransaksi { get; set; }

        public virtual Transaksi IdTransaksiNavigation { get; set; }
    }
}
