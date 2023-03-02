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
    public partial class FormMasterKasir : Form
    {
        Koneksi konn = new Koneksi();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void munculLevel()
        {
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("USER");
        }

        void kondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            munculLevel();
            MunculDataKasir();
        }

        public FormMasterKasir()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void MunculDataKasir()
        {
            MySqlConnection conn = konn.getConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM TBL_KASIR", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "TBL_KASIR");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_KASIR";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("INSERT INTO TBL_KASIR VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                kondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("SELECT * FROM TBL_KASIR WHERE KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    comboBox1.Text = rd[3].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("UPDATE TBL_KASIR SET NamaKasir='" + textBox2.Text + "', PasswordKasir='" + textBox3.Text + "', LevelKasir='" + comboBox1.Text + "' WHERE KodeKasir='" + textBox1.Text +"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diedit");
                kondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("DELETE FROM TBL_KASIR WHERE KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                kondisiAwal();
            }
        }
    }
}
