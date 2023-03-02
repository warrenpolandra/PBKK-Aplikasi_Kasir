using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_Kasir
{
    public partial class FormMenuUtama : Form
    {
        public static FormMenuUtama menu;
        MenuStrip mnStrip;
        FormLogin frmLogin;
        
        void frmLogin_formClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin = null;
        }

        FormMasterKasir frmKasir;
        void frmKasir_formClosed(object sender, FormClosedEventArgs e)
        {
            frmKasir = null;
        }

        FormMasterBarang frmBarang;
        void frmBarang_formClosed(object sender, FormClosedEventArgs e)
        {
            frmBarang = null;
        }

        void MenuTerkunci()
        {
            menuLogin.Enabled = true;
            menuLogout.Enabled = false;
            menuMaster.Enabled = false;
            menuTransaksi.Enabled = false;
            menuLaporan.Enabled = false;
            menuUtility.Enabled = false;

            menu = this;
        }
        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            MenuTerkunci();
        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            if (frmLogin == null)
            {
                frmLogin = new FormLogin();
                frmLogin.FormClosed += new FormClosedEventHandler(frmLogin_formClosed);
                frmLogin.ShowDialog();
            }
            else
            {
                frmLogin.Activate();
            }
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            MenuTerkunci();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKasir == null)
            {
                frmKasir = new FormMasterKasir();
                frmKasir.FormClosed += new FormClosedEventHandler(frmKasir_formClosed);
                frmKasir.ShowDialog();
            }
            else
            {
                frmKasir.Activate();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBarang == null)
            {
                frmBarang = new FormMasterBarang();
                frmBarang.FormClosed += new FormClosedEventHandler(frmBarang_formClosed);
                frmBarang.ShowDialog();
            }
            else
            {
                frmBarang.Activate();
            }
        }
    }
}
