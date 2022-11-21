using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant
{
    internal class DataInsert
    {
        private string _noPesanan;
        private string _nama;
        private string _pesan1;
        private string _pesan2;
        private string _pesan3;
        private string _pesan4;
        private string _total;


        public string NoPesanan { get => _noPesanan; set => _noPesanan = value; }
        public string Nama { get => _nama; set => _nama = value; }
        public string Pesan1 { get => _pesan1; set => _pesan1 = value; }
        public string Pesan2 { get => _pesan2; set => _pesan2 = value; }
        public string Pesan3 { get => _pesan3; set => _pesan3 = value; }
        public string Pesan4 { get => _pesan4; set => _pesan4 = value; }
        public string Total { get => _total; set => _total = value; }

        public DataInsert(string _nama, string _pesan1, string _pesan2, string _pesan3, string _pesan4, string _total)
        {
            this.Nama = _nama;
            this.Pesan1 = _pesan1;
            this.Pesan2 = _pesan2;
            this.Pesan3 = _pesan3;
            this.Pesan4 = _pesan4;
            this.Total = _total;

        }

        public DataInsert(string _no_pesanan, string _nama, string _pesan1, string _pesan2, string _pesan3, string _pesan4, string _total)
        {
            this.NoPesanan = _no_pesanan;
            this.Nama = _nama;
            this.Pesan1 = _pesan1;
            this.Pesan2 = _pesan2;
            this.Pesan3 = _pesan3;
            this.Pesan4 = _pesan4;
            this.Total = _total;
        }
    }
}
