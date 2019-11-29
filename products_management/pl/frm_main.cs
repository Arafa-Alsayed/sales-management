using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace products_management.pl
{
    public partial class frm_main : Form
    {                      //this code we use to controle in form frm_main from another form  frm_login
        private static frm_main frm;
        static void frm_formclosed(object sender,FormClosedEventArgs e)
        {
            frm = null;
        }
        public static frm_main getmainform
        {
            get
            { 
                if (frm == null)
                {
                    frm = new frm_main();
                    frm.FormClosed += new FormClosedEventHandler(frm_formclosed);
                }
                return frm;
            }
        }


        public frm_main()
        {
            InitializeComponent();
            if(frm==null)
            frm = this;
               this.ToolStripMenuItem_products.Enabled = false;
            this.ToolStripMenuItem_users.Enabled = false;
            this.ToolStripMenuItem_customers.Enabled = false;
            this.ToolStripMenuItem_dobackup.Enabled = false;
            this.ToolStripMenuItem_restore_backup.Enabled = false;


        }

        private void اضافةبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frm_main_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_register_enter_Click(object sender, EventArgs e)
        {
            frm_login frm = new frm_login();
            frm.ShowDialog();
        }

        private void اضافةمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_add_product frm = new frm_add_product();
            frm.ShowDialog();
        }

        private void ادارةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_management_products1 frm = new frm_management_products1();
            frm.ShowDialog();
        }

        private void ادارةالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_category frm = new frm_category();
            frm.ShowDialog();
        }

        private void ادارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_customers frm = new frm_customers();
            frm.ShowDialog();
        }

        private void ادارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orders frm = new orders();
            frm.ShowDialog();

        }

        private void اضافةعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_addusers frm = new frm_addusers();
            frm.ShowDialog();
        }

        private void ادارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_manageuser frm = new frm_manageuser();
            frm.ShowDialog();
        }

        private void ToolStripMenuItem_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_restore_backup_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_dobackup_Click(object sender, EventArgs e)
        {
            frm_backup frm = new frm_backup();
            frm.ShowDialog();
        }
    }
}
