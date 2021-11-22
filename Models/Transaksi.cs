using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_089_C.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Pembelis = new HashSet<Pembeli>();
        }

        public int IdTransaksi { get; set; }
        public int? IdProduk { get; set; }
        public DateTime? Tanggal { get; set; }

        public virtual Product IdProdukNavigation { get; set; }
        public virtual ICollection<Pembeli> Pembelis { get; set; }
    }
}
