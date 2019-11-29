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
    public partial class frm_addusers : Form
    {
        public frm_addusers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_name_user.Text == string.Empty || txt_fullname.Text == string.Empty || txt_password.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("يجب ان تملا البيانات");
                return;
            }
            else
            {
                if (btn_add.Text == "حفظ المستخدم"||btn_add.Text=="اضافه")
                {
                    bl.cls_login op = new bl.cls_login();
                    op.add_users(txt_name_user.Text, txt_password.Text, comboBox1.Text, txt_fullname.Text);
                    MessageBox.Show("تمت عملية الاضافه بنجاح");
                }
                else if(btn_add.Text=="تعديل المستخدم")
                {
                    bl.cls_login op = new bl.cls_login();
                    op.edit_users(txt_name_user.Text, txt_password.Text, comboBox1.Text, txt_fullname.Text);
                    MessageBox.Show("تمت عملية التعديل بنجاح");
                }
            }



        }

        private void txt_password_Validated(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text != txt_password.Text)
                MessageBox.Show("كلمتا المرور غير متطابقتان");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
