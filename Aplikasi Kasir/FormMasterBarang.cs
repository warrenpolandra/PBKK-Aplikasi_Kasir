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
    public partial class FormMasterBarang : Form
    {
        Koneksi konn = new Koneksi();
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        void munculSatuan()
        {
            comboBox1.Items.Add("PCS");
            comboBox1.Items.Add("BOX");
            comboBox1.Items.Add("BOTOL");
            comboBox1.Items.Add("PAX");
            comboBox1.Items.Add("KILO");
            comboBox1.Items.Add("KARUNG");
        }

        void kondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            munculSatuan();
            MunculDataBarang();
        }
        void MunculDataBarang()
        {
            MySqlConnection conn = konn.getConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM TBL_BARANG", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "TBL_BARANG");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_BARANG";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        public FormMasterBarang()
        {
            InitializeComponent();
        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            kondisiAwal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("INSERT INTO TBL_BARANG VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                kondisiAwal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("UPDATE TBL_BARANG SET NamaBarang='" + textBox2.Text + "', HargaBeli='" + textBox3.Text + "', HargaJual='" + textBox4.Text + "', JumlahBarang='" + textBox5.Text + "', SatuanBarang='" + comboBox1.Text + "' WHERE KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diedit");
                kondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("SELECT * FROM TBL_BARANG WHERE KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    textBox4.Text = rd[3].ToString();
                    textBox5.Text = rd[4].ToString();
                    comboBox1.Text = rd[5].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua form terisi!");
            }
            else
            {
                MySqlConnection conn = konn.getConn();
                cmd = new MySqlCommand("DELETE FROM TBL_BARANG WHERE KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
                kondisiAwal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
