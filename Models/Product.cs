using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_089_C.Models
{
    public partial class Product
    {
        public Product()
        {
            Penjuals = new HashSet<Penjual>();
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public string Harga { get; set; }

        public virtual ICollection<Penjual> Penjuals { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
