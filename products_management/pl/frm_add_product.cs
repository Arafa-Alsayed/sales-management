using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace products_management.pl
{
   
    public partial class frm_add_product : Form
    {
        public string state = "add";     //field to cure validation in product_id field if he add product or he update
        bl.cls_products opp = new bl.cls_products();
        public frm_add_product()
        {
            InitializeComponent();

            combo_frmaddproduct.DataSource = opp.get_all_category();
            combo_frmaddproduct.DisplayMember = "describtion_cat";
            combo_frmaddproduct.ValueMember = "id_cat";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "ملفات الصور|*.png;*.jpg;*.gif;*.bmp";

            if(of.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(of.FileName);
            }

        }

        private void frm_add_product_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("picimage.png");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        //because this button do two addproduct and update product these use same button so we do variale state 
        { if (state == "add")
            {

                //memorystream is class herient class stream it store image or data in memory or on network if project on web
                MemoryStream ms = new MemoryStream();
                //save picture in memorystream and format its           
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);      //rawformat here store formating picture and type
                byte[] byt_imag = ms.ToArray();

                opp.add_product(Convert.ToInt32(combo_frmaddproduct.SelectedValue), txt_idpro.Text, txt_description_pro.Text, Convert.ToInt32(txt_stock.Text), txt_price.Text, byt_imag);
                MessageBox.Show("تمت الاضافه بنجاح", "الاضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this here we controle form from another form
                frm_management_products1.getmanage_productform.dataGridView1.DataSource = opp.get_all_products();
                
            }

            else if (state == "update")
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byt_image = ms.ToArray();

                opp.update_products(txt_idpro.Text, txt_description_pro.Text, Convert.ToInt32(txt_stock.Text), txt_price.Text, byt_image, Convert.ToInt32(combo_frmaddproduct.SelectedValue));
                MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_management_products1.getmanage_productform.dataGridView1.DataSource = opp.get_all_products();
                  


            }
            } 

        private void txt_idpro_Validated(object sender, EventArgs e)
        {if (state == "add")
            {
                DataTable dt = new DataTable();
                dt = opp.distinctid(txt_idpro.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا الكود موجود مسبقا من فضلك غير الكود", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //this code to do shadow on text if has error
                    //must write three codes
                    txt_idpro.Focus();                        //focus arrow ref on txt_idpro
                    txt_idpro.SelectionStart = 0;             //posistion arrow ref in text
                    txt_idpro.SelectionLength = txt_idpro.TextLength;
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
