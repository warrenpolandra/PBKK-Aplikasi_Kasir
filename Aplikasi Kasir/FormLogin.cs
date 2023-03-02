using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aplikasi_Kasir
{
    public partial class FormLogin : Form
    {
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            MySqlConnection conn = koneksi.getConn();
            {
                conn.Open();
                cmd = new MySqlCommand("SELECT * FROM TBL_KASIR WHERE KodeKasir='" + textBox1.Text + "' AND PasswordKasir='" + textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    FormMenuUtama.menu.menuLogin.Enabled = false;
                    FormMenuUtama.menu.menuLogout.Enabled = true;
                    FormMenuUtama.menu.menuMaster.Enabled = true;
                    FormMenuUtama.menu.menuTransaksi.Enabled = true;
                    FormMenuUtama.menu.menuLaporan.Enabled = true;
                    FormMenuUtama.menu.menuUtility.Enabled = true;
                    //FormMenuUtama frmUtama = new FormMenuUtama();
                    //frmUtama.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = 'X';
            textBox1.Text = "KSR001";
            textBox2.Text = "ADMIN";
        }
    }
}
