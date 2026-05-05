using SistemUKT.Konfigurasi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemUKT.Services
{
    public class AuthService
    {
        public bool Login(string username, string password)
        {
            Koneksi koneksi = new Koneksi();

            string query = $"SELECT * FROM users WHERE username='{username}' AND password='{password}'";

            DataTable dt = koneksi.eksekusiQuery(query);

            if (dt.Rows.Count > 0)
            {
                SessionManager.IdUser = Convert.ToInt32(dt.Rows[0]["id_user"]);
                SessionManager.Username = dt.Rows[0]["username"].ToString();
                SessionManager.Role = dt.Rows[0]["role"].ToString();

                return true;
            }

            return false;
        }
    }
}
