using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemUKT.Konfigurasi
{
        abstract class Konfigurasi
        {
            //untuk menangani fungsi INSERT, UPDATE, DELETE
            public abstract int eksskusiNonQuery(string query);

            //untuk menangani fungsi SELECT
            public abstract DataTable eksekusiQuery(string query);
        }
}
