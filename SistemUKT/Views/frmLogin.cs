using SistemUKT.Konfigurasi;
using SistemUKT.Services;
using SistemUKT.Views.Keuangan;
using SistemUKT.Views.Mahasiswa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemUKT.Views.Admin;

namespace SistemUKT.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = usn_txt.Text.Trim();
            string password = pw_txt.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan password wajib diisi");
                return;
            }

            AuthService auth = new AuthService();
            bool success = auth.Login(username, password);

            if (success)
            {
                MessageBox.Show("Login berhasil");

                if (SessionManager.Role == "admin")
                {
                    new frmDashAdmin().Show();
                }
                else if (SessionManager.Role == "keuangan")
                {
                    new frmDashboardKeuangan().Show();
                }
                else
                {
                    new frmDashboardMahasiswa().Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah");
            }
        }
    }
}
