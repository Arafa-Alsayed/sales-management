using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace products_management.pl
{
    public partial class orders : Form
    {

       
        public orders()
        {
            InitializeComponent();
            creatdatatable();
           
            btn_saveorder.Enabled = false;
            btn_printbill.Enabled = false;
            resize();
            txt_salsman.Text = Program.salesname;
        }
        bl.cls_orders order = new bl.cls_orders();
        DataTable dt = new DataTable();
        void creatdatatable()
        {
            dt.Columns.Add("كود المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("الثمن");
            dt.Columns.Add("الكميه");
            dt.Columns.Add("المبلغ");
            dt.Columns.Add("نسبة الخصم(%)");
            dt.Columns.Add("المبلغ الاجمالى");
            this.dataGridView1.DataSource = dt;

            /* //to add button or text to datagridview
             DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
             btn.HeaderText = "اختيار منتج";    //header columns
             btn.Text = "بحث";                  //text which write on button
             btn.UseColumnTextForButtonValue = true;      //to text on button but it show when edit in datagridview
             this.dataGridView1.Columns.Insert(0,btn);      //to add button to gridview
             */
        }
        //to resize gridview columns witdh to suitable text over it
        void resize()
        {

            this.dataGridView1.RowHeadersWidth = 72;                 //thi i margin that is in datadrid view 
            this.dataGridView1.Columns[0].Width = 73;
            this.dataGridView1.Columns[1].Width = 172;
            this.dataGridView1.Columns[2].Width = 82;
            this.dataGridView1.Columns[3].Width = 88;
            this.dataGridView1.Columns[4].Width = 96;
            this.dataGridView1.Columns[5].Width = 90;
            this.dataGridView1.Columns[6].Width = 120;

        }
        //methode calculate totalprice for product
        void calcprice()
        {
            if (txt_price.Text != string.Empty && txt_quantity.Text != string.Empty)
            {
                double totalprice = Convert.ToDouble(txt_price.Text) * Convert.ToInt32(txt_quantity.Text);
                txt_mony.Text = totalprice.ToString();
            }
            else
            {
                txt_mony.Text = "0";
            }
        }

        //to calulate total afterdiscount
        void calcprice_afterdiscount()
        {//
            if (txt_discount.Text != string.Empty && txt_discount.Text != "0")
            {


                double lastprice = (Convert.ToDouble(txt_mony.Text)) - ((Convert.ToDouble(txt_mony.Text)) * (Convert.ToDouble(txt_discount.Text) / 100));
                txt_priceafterdiscount.Text = lastprice.ToString();

            }
            else
            {


                txt_priceafterdiscount.Text = txt_mony.Text;
            }
        }
        void clearallpro()
        {
            txt_proid.Clear();
            txt_namepro.Clear();
            txt_price.Clear();
            txt_quantity.Clear();
            txt_mony.Clear();
            txt_discount.Clear();
            txt_priceafterdiscount.Clear();
        }
        void clearallcustomer_orderbox()
        {
            txt_customerid.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            txt_phone.Clear();
            txt_email.Clear();
            pictureBox1.Image = null;
            txt_orderid.Clear();
            txt_discription_order.Clear();
            txt_salsman.Clear();
            dt.Clear();
            dataGridView1.Refresh();
            txt_sum.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           txt_orderid.Text = order.getlast_orderid().Rows[0][0].ToString();
            btn_new.Enabled = false;
            btn_printbill.Enabled = false;
            btn_saveorder.Enabled = true;
            clearallpro();
            dt.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void btn_saveorder_Click(object sender, EventArgs e)
        {
            btn_new.Enabled = true;
            btn_printbill.Enabled = true;
            btn_saveorder.Enabled = false;
            //save bill in table order in database
            if(txt_customerid.Text==string.Empty)
            {
                MessageBox.Show("ادخل بيانات العميل");
                btn_saveorder.Enabled = true; 
            }
            else if (this.dataGridView1.Rows.Count-1 < 1)
            {
                MessageBox.Show("لا يوجد منتجات لحفظ الفاتوره");
                btn_saveorder.Enabled = true; 
            }
            else
            {
                order.add_order(Convert.ToInt32(txt_orderid.Text), txt_discription_order.Text, txt_datatimpicer.Value, txt_salsman.Text, Convert.ToInt32(txt_customerid.Text));
                for (int i = 0; i < this.dataGridView1.Rows.Count-1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == string.Empty)
                    {
                        dataGridView1.Rows[i].Cells[5].Value = 0;
                        order.add_detailsorder(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                                      Convert.ToInt32(txt_orderid.Text),
                                               Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                              dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                               Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value),
                                               dataGridView1.Rows[i].Cells[4].Value.ToString(),
                                               dataGridView1.Rows[i].Cells[6].Value.ToString());

                    }
                    else
                    {
                        order.add_detailsorder(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                                    Convert.ToInt32(txt_orderid.Text),
                                             Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                            dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                             Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value),
                                             dataGridView1.Rows[i].Cells[4].Value.ToString(),
                                             dataGridView1.Rows[i].Cells[6].Value.ToString());
                    }
                   


                }
                MessageBox.Show("تمت عمليه الحفظ بنجاح");
                clearallpro();
                clearallcustomer_orderbox();   
            }
           
          

            }

    

        private void btn_searchcust_Click(object sender, EventArgs e)
        {
            frm_allcustomer frm = new frm_allcustomer();
            frm.ShowDialog();
            if (frm.dataGridView1.CurrentRow.Cells[5].Value is DBNull)
            {
                txt_customerid.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_fname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_lname.Text = frm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = frm.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.pictureBox1.Image = null;
                return;
            }
            else
            {
                txt_customerid.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_fname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_lname.Text = frm.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_phone.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = frm.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void orders_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_allproducts frm_pro = new frm_allproducts();
            frm_pro.ShowDialog();
            clearallpro(); //delete textboxs
            this.txt_proid.Text = frm_pro.datagridproduct.CurrentRow.Cells[0].Value.ToString();
            this.txt_namepro.Text = frm_pro.datagridproduct.CurrentRow.Cells[1].Value.ToString();
            this.txt_price.Text = frm_pro.datagridproduct.CurrentRow.Cells[3].Value.ToString();
            txt_quantity.Focus();
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {               //هنا العلامه العشريه بتختلف فى الاجهزه من ناحية اللغه فممكم تكون. او , )
            //so we call globalization library to know separator on computer  //default type is string so you convert to char
            char decimalseparator=Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);


                //if button isnot number   //8 i asccicode has backspace button delete     
 
            if(!char.IsDigit(e.KeyChar) && e.KeyChar!=8 &&e.KeyChar!=decimalseparator)        //to write only numbers in textbox    
            {
                e.Handled = true;
            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
           // calcprice();   here will get error because canot convert during starting this event
        }

        private void txt_price_KeyUp(object sender, KeyEventArgs e)
        {
            calcprice();
            calcprice_afterdiscount();
        }

        private void txt_quantity_KeyUp(object sender, KeyEventArgs e)
        {
            calcprice();
            calcprice_afterdiscount();
        }

        private void txt_priceafterdiscount_KeyUp(object sender, KeyEventArgs e)
        {
            //calcprice_afterdiscount();
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            calcprice_afterdiscount();
            
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void addshowdadagrid_Click(object sender, EventArgs e)
        {
            if(txt_quantity.Text==string.Empty)
            {
                MessageBox.Show("ادخل الكميه");
                return;
            }
            if (order.checkquantity(txt_proid.Text, Convert.ToInt32(txt_quantity.Text)).Rows.Count < 1)
            {
                MessageBox.Show("هذه الكميه اكبر من الكميه الموجوده بالمخزن");
                return;
            }
            
            
            //to check that product id isnot repete
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
			{
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txt_proid.Text && dataGridView1.Rows[i].Cells[0].Value.ToString()!=string.Empty)
              {
                  MessageBox.Show("هذا المنتج ادخل من قبل");
                  return;
              }
			}
           
          
            if (txt_priceafterdiscount.Text != string.Empty)
            {
                DataRow r = dt.NewRow();                   //variable its type datarow  is as new row in datatable
                r[0] = txt_proid.Text;
                r[1] = txt_namepro.Text;
                r[2] = txt_price.Text;
                r[3] = txt_quantity.Text;
                r[4] = txt_mony.Text;
                r[5] = txt_discount.Text;
                r[6] = txt_priceafterdiscount.Text;
                dt.Rows.Add(r);
                clearallpro();                                //make all textbox is empty 
            }
            //this is two ways to find sumfinal linq,,,forloop
            //txt_sum.Text = (from DataGridViewRow row in this.dataGridView1.Rows
            //                where row.Cells[6].FormattedValue.ToString() != string.Empty
            //                select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            double x=0;
            
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString()!=string.Empty)
               x=Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value)+x;
            }
            txt_sum.Text = x.ToString();
            }
       
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {           //to do operation edit on datagridview

            if (MessageBox.Show("'No'واذا كنت تريد تعديله اضغط 'yes'واذا كنت تريد حذفه اضغط ", "edit",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning ) == DialogResult.Yes)
            {
                this.dataGridView1.Rows.Remove(dataGridView1.CurrentRow); return;
                
            }
            else if (MessageBox.Show("'No'واذا كنت تريد تعديله اضغط 'yes'واذا كنت تريد حذفه اضغط ", "edit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.No)
            {
                clearallpro();
                txt_proid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_namepro.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_quantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_mony.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_discount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_priceafterdiscount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                this.dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                return;
            }
           
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
               double x=0;
            
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[6].Value.ToString()!=string.Empty)
               x=Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value)+x;
            }
            txt_sum.Text = x.ToString();
            }

        private void تعديلالسطرالمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearallpro();
            txt_proid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_namepro.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_quantity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_mony.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_discount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_priceafterdiscount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            this.dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void حذفالسطرالمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();              //because data in gridview source is datatable
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_printbill_Click(object sender, EventArgs e)
        {

        }
        }

        }
    

