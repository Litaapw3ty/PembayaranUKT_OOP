using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemUKT.Konfigurasi
{
    internal class Seting
    {
            public static string Server { get; set; }
            public static string Port { get; set; }
            public static string DBase { get; set; }
            public static string Uid { get; set; }
            public static string Pwd { get; set; }

            // simpan ke file (tiap baris 1 nilai)
            public static void simpanSeting(string path)
            {
                string[] data = {
                Port,
                Server,
                DBase,
                Uid,
                Pwd
            };

                File.WriteAllLines(path, data);
            }

            // ambil dari file
            public static string[] ambilSeting(string path)
            {
                return File.ReadAllLines(path);
            }
        }
}
