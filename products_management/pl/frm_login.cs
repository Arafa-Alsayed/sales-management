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
    public partial class frm_login : Form
    {
        bl.cls_login log = new bl.cls_login();

        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DataTable dt = log.login(txt_id.Text, txt_password.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "عادى")
                {
                    frm_main.getmainform.ملفToolStripMenuItem.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_products.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_customers.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_users.Visible= false;
                    frm_main.getmainform.ToolStripMenuItem_dobackup.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_restore_backup.Enabled = true;
                    Program.salesname = dt.Rows[0]["salesname"].ToString();
                }
                else if (dt.Rows[0][2].ToString() == "مدير")
                {
                    frm_main.getmainform.ملفToolStripMenuItem.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_products.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_customers.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_users.Visible = true;
                    frm_main.getmainform.ToolStripMenuItem_users.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_dobackup.Enabled = true;
                    frm_main.getmainform.ToolStripMenuItem_restore_backup.Enabled = true;
                    Program.salesname = dt.Rows[0]["salesname"].ToString();

                }
                this.Close();

            }
            else { MessageBox.Show("login failed"); }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {

        }
    }
}
