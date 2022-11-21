using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestaurant
{
    class Data
    {
        public NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=e_rest");
        public string sql = null;

        private DataGridViewRow r;
        private DataTable dt;
        public static NpgsqlCommand cmd;

        private static string _nama;
        private static string _noPesanan;
        private static string _pesan1;
        private static string _pesan2;
        private static string _pesan3;
        private static string _pesan4;
        private static string _total;
        public string NoPesanan
        {
            get { return _noPesanan; }
            set { _noPesanan = value; }
        }
        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        public string Pesan1
        {
            get { return _pesan1; }
            set { _pesan1 = value; }
        }
        public string Pesan2
        {
            get { return _pesan2; }
            set { _pesan2 = value; }
        }
        public string Pesan3
        {
            get { return _pesan3; }
            set { _pesan3 = value; }
        }
        public string Pesan4
        {
            get { return _pesan4; }
            set { _pesan4 = value; }
        }
        public string Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public Data() { }
        public Data(string noPesan, string nama, string pesan1, string pesan2, string pesan3, string pesan4, string total)
        {
            this.NoPesanan = noPesan;
            this.Nama = nama;
            this.Pesan1 = pesan1;
            this.Pesan2 = pesan2;
            this.Pesan3 = pesan3;
            this.Pesan4 = pesan4;
            this.Total = total;
        }
    }
}
