using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemUKT.Konfigurasi
{
    internal class Koneksi : Konfigurasi
    {
        MySqlConnection _con;
        MySqlCommand _com;
        MySqlDataAdapter _adapter;

        static string[] data = Seting.ambilSeting("konfig.txt");

        // FIX connection string
        string _link = $"{data[1]};port={data[0]};{data[2]};{data[3]};{data[4]}";

        public Koneksi()
        {
            _con = new MySqlConnection(_link);
            _com = new MySqlCommand();
            _adapter = new MySqlDataAdapter();
        }

        private void bukaKoneksi()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
        }

        private void tutupKoneksi()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }

        public override int eksskusiNonQuery(string query)
        {
            int retVal = -1;
            try
            {
                bukaKoneksi();
                _com.Connection = _con;
                _com.CommandText = query;
                retVal = _com.ExecuteNonQuery();
            }
            finally
            {
                tutupKoneksi();
            }

            return retVal;
        }

        public override DataTable eksekusiQuery(string query)
        {
            DataTable retVal = new DataTable();
            try
            {
                bukaKoneksi();
                _com.Connection = _con;
                _com.CommandText = query;
                _adapter.SelectCommand = _com;
                _adapter.Fill(retVal);
            }
            finally
            {
                tutupKoneksi();
            }

            return retVal;
        }
    }
}
