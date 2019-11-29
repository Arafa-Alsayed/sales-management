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
    public partial class frm_management_products1 : Form
    {  //this code to controle component this form from anthor form
        private static frm_management_products1 frm;
        static void frm_formclosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_management_products1 getmanage_productform
        {
            get
            {
                if (frm == null)
                {
                    frm = new frm_management_products1();
                    frm.FormClosed += new FormClosedEventHandler(frm_formclosed);
                }
                return frm;
            }
        }

        bl.cls_products opm = new bl.cls_products();
        public frm_management_products1()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            dataGridView1.DataSource=opm.get_all_products();
           
        }

        private void frm_management_products1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_add_product frm = new frm_add_product();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = opm.alldata_searching(txtsearch.Text);
            this.dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {    //to delete data row
           if( MessageBox.Show("هل تريد اتمام عملية الحذف","عملية حذف",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
                {
                bl.cls_products op = new bl.cls_products();
                op.delete_data((string)dataGridView1.CurrentRow.Cells[0].Value);
                MessageBox.Show("تمت عملية الحذف بنجاح"," الحذف", MessageBoxButtons.OK);
                this.dataGridView1.DataSource = op.get_all_products();

                }
            else
            {
                MessageBox.Show("تم الغاء الحذف");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {     //do object as copy from form frm_add_product to active and show it for updating
            frm_add_product frm = new frm_add_product();
            frm.state = "update";                           //variable prevent active event validation
            frm.txt_idpro.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txt_description_pro.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txt_stock.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txt_price.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.combo_frmaddproduct.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.btn_add.Text = "تحديث";
           
            frm.Text = "تحديث المنتج"+" :" + this.dataGridView1.CurrentRow.Cells[1].Value;
            frm.txt_idpro.ReadOnly = true;
            byte[] myimage;
            myimage = (byte[])opm.getimage(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];//why rows[0][0]//when procedure return one field or to datatable return one colomn to convert to byte[]
            MemoryStream ms = new MemoryStream(myimage);
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();
            



        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_image frm = new frm_image();
            byte[] myimage;
            myimage = (byte[])opm.getimage(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];//why rows[0][0]//when procedure return one field or to datatable return one colomn to convert to byte[]
            MemoryStream ms = new MemoryStream(myimage);
            frm.pictureBox1.Image = Image.FromStream(ms);
            frm.ShowDialog();
            


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    rpt.rpt_prd_single myreport = new rpt.rpt_prd_single();
            //    myreport.SetParameterValue("@id", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //    rpt.frm_rpt_product myform = new rpt.frm_rpt_product();
            //    myform.crystalReportViewer1.ReportSource = myreport;
            //    myform.ShowDialog();
            //}
            //catch(Exception ex)
            //{ MessageBox.Show(ex.ToString()); }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
