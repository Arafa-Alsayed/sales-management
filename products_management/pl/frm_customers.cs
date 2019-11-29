using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace products_management.pl
{
    
    public partial class frm_customers : Form
    {
        int position;
        bl.cls_customers custom = new bl.cls_customers();
        public frm_customers()
        {
            InitializeComponent();
            dataGridView1.DataSource = custom.allcustomer();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            btn_add.Enabled = false;
            lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_customers_Load(object sender, EventArgs e)
        {    //fill field on form with data from datagridview
            try
            {
                byte[] picture;

                txt_idcustomer.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;

                MemoryStream ms = new MemoryStream(picture);            //here put picture in memory stream 
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch { return; }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
          
            try
            {
                byte[] img;
                if (pictureBox1.Image == null)                     //if picturebox is null
                {
                    img = new byte[0];                             //here we assign value for img to dont do error
                    custom.addcustomer(Convert.ToInt32(txt_idcustomer.Text), txt_fname.Text, txt_lname.Text, txt_phone.Text, txt_email.Text, img, "no image");//here img no send

                }

                else
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    img = ms.ToArray();

                    custom.addcustomer(Convert.ToInt32(txt_idcustomer.Text), txt_fname.Text, txt_lname.Text, txt_phone.Text, txt_email.Text, img, "with image");
                }
             
             MessageBox.Show("تمت عملية الاضافة");
                dataGridView1.DataSource = custom.allcustomer();
                lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);

            }
            catch
            {
                return;
            }
            finally { btn_add.Enabled = false; }

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {           
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "ملفات الصور|*.png;*.jpg";
            if(op.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);

            }
        }

    


      

        private void txt_idcustomer_Validated(object sender, EventArgs e)
        {     
           try
            {
                DataTable dt = new DataTable();
                bl.cls_customers custom = new bl.cls_customers();
                dt = custom.checkrows(Convert.ToInt32(txt_idcustomer.Text));
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("كود هذا العميل موجود مسبقا");
                    txt_idcustomer.Clear();
                    txt_idcustomer.Focus();

                }
            }
            catch { return; }
             

        
}
    
        private void txt_idcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txt_fname.Focus();
            }
        }

        private void txt_fname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_lname.Focus();
            }
        }

      

        private void txt_lname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_phone.Focus();
            }
        }

        private void txt_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_email.Focus();
            }
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_add.Focus();
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
            if (txt_phone.TextLength > 11)
                MessageBox.Show("رقم التليفون يجب ان يكون 11 رقم");
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            clearall();
            txt_idcustomer.Enabled = true;
            btn_add.Enabled = true;
        }

     

     

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pictureBox1.Image = null;                         //to empty previous picture before select new row to show
                txt_idcustomer.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_idcustomer.Enabled = false;
                btn_add.Enabled = false;
                byte[] picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;

                MemoryStream ms = new MemoryStream(picture);
                pictureBox1.Image = Image.FromStream(ms);

            }                                             //so we use try catch [return means when error happen dont do anything]
            catch { return; }                                         //here it exception because pic bring null in database 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_idcustomer.Text == null || txt_idcustomer.Text=="")
            {
                MessageBox.Show("كود العميل فارغا يجب ان تحدد قيمه له");
            }
              else if(custom.checkrows(Convert.ToInt32(txt_idcustomer.Text)).Rows.Count==0)
            {
                MessageBox.Show("كود هذا العميل غير موجود");
            }
            else
            {
                bl.cls_customers cs = new bl.cls_customers();
                if( MessageBox.Show("هل تريد الحذف فعلا","الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cs.del_customer(Convert.ToInt32(txt_idcustomer.Text));
                    dataGridView1.DataSource = cs.allcustomer();                  //to update datagridview  do refresh
                    MessageBox.Show("تمت عملية الحذف");
                    clearall();
                    nav(0);
                    lbl_count.Text = (0 + 1) + "/" + (custom.allcustomer().Rows.Count);
                }
            }
        }
        public void clearall()
        {
            txt_idcustomer.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            txt_phone.Clear();
            txt_email.Clear();
            pictureBox1.Image = null;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            byte[]mypic;
            if (pictureBox1.Image == null)
            {
                mypic = new byte[0];
                custom.update_customer(Convert.ToInt32(txt_idcustomer.Text), txt_fname.Text, txt_lname.Text, txt_phone.Text, txt_email.Text, mypic, "no image");
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                mypic = ms.ToArray();
                custom.update_customer(Convert.ToInt32(txt_idcustomer.Text), txt_fname.Text, txt_lname.Text, txt_phone.Text, txt_email.Text, mypic,"with image");

            }
            dataGridView1.DataSource = custom.allcustomer();
            MessageBox.Show("تمت عملية تحديث البيانات");
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = custom.serchcustomer(textBox5.Text);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode==Keys.Enter)
            //{
            //    textBox1_TextChanged(sender, e);            //this is code if you want execute event means code which inside it you write event
            //}
        }  
        
       void nav(int index)
        {
            try
            {
                pictureBox1.Image = null;
                DataTable dt = new DataTable();
                dt = custom.allcustomer();
                txt_idcustomer.Text = dt.Rows[index][0].ToString();
                txt_fname.Text = dt.Rows[index][1].ToString();
                txt_lname.Text = dt.Rows[index][2].ToString();
                txt_phone.Text = dt.Rows[index][3].ToString();
                txt_email.Text = dt.Rows[index][4].ToString();
                byte[] picture = (byte[])dt.Rows[index][5];
                MemoryStream ms = new MemoryStream(picture);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch { return; }
        }

       private void btn_first_Click(object sender, EventArgs e)
       {
           position = custom.allcustomer().Rows.Count - 1;
           nav(position);
           lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);
       }

       private void button4_Click(object sender, EventArgs e)
       {
           position = 0;
           nav(position);
           lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);
           
       }

       private void btn_next_Click(object sender, EventArgs e)
       {
           if (position == custom.allcustomer().Rows.Count-1)
           {
               MessageBox.Show("هذا هو اخر عنصر");
           }

           else if (position <= custom.allcustomer().Rows.Count - 1)
           {
               position += 1;
               nav(position);
               lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);
           }
       
           
       }

       private void btn_previous_Click(object sender, EventArgs e)
       {
            if(position==0)
           {
               MessageBox.Show("هذا هو اول عنصر");
           }

            else if (position >= 0)
            {
                position -= 1;
                nav(position);
                lbl_count.Text = (position + 1) + "/" + (custom.allcustomer().Rows.Count);
            }
           
       } 



    }
}
