using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Kasir
{
    class Koneksi
    {
        public MySqlConnection getConn()
        {
            MySqlConnection Conn = new MySqlConnection("datasource=127.0.0.1;port=8111;username=root;password=;database=db_kasir;");
            return Conn;
        }
    }
}
