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
    public partial class frm_manageuser : Form
    {
        bl.cls_login op = new bl.cls_login();
        public frm_manageuser()
        {
            InitializeComponent();
            this.dgv_users.DataSource = op.serchusers("");
        }

        private void frm_manageuser_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dgv_users.DataSource = op.serchusers(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_addusers frm = new frm_addusers();
            frm.btn_add.Text = "حفظ المستخدم";
            frm.ShowDialog();
            this.dgv_users.DataSource = op.serchusers("");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            frm_addusers frm = new frm_addusers();
            frm.txt_name_user.Text = this.dgv_users.CurrentRow.Cells[0].Value.ToString();
            frm.txt_password.Text = this.dgv_users.CurrentRow.Cells[1].Value.ToString();
            frm.comboBox1.Text = this.dgv_users.CurrentRow.Cells[2].Value.ToString();
            frm.txt_fullname.Text = this.dgv_users.CurrentRow.Cells[3].Value.ToString();
            frm.textBox1.Text = this.dgv_users.CurrentRow.Cells[1].Value.ToString();
            frm.btn_add.Text = "تعديل المستخدم";
            frm.txt_name_user.ReadOnly = true;
            frm.ShowDialog();
            this.dgv_users.DataSource = op.serchusers("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحذف فعلا", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                op.delete_users(dgv_users.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عملية الحذف بنجاح");
                this.dgv_users.DataSource = op.serchusers("");
            }
            else MessageBox.Show("تم الغاء عملية الحذف");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
