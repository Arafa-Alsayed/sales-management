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

namespace products_management.pl
{
    public partial class frm_category : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=product_db;Integrated Security=True");
        SqlDataAdapter da;                     //connect with tables in database it do add delete update
        DataTable dt = new DataTable();
        BindingManagerBase bmb;             //class manage in process binding 
        SqlCommandBuilder cmdb;            //this class use with dataAdapter  and datatable and bindingmanager or currencymaanager to do process add or update or delete
        public frm_category()
        {
           
            InitializeComponent();
            //bring all category to datagridview
            da = new SqlDataAdapter("select id_cat as 'الكود' ,describtion_cat as 'الصنف' from category", con);//this code shouldnt write before  InitializeComponent(); because it create error
            da.Fill(dt);
            dgview_category.DataSource = dt;
            //data binding means contact fields in form with fields in tables database
            txt_idcat.DataBindings.Add("text", dt, "الكود");
            txt_desccat.DataBindings.Add("text", dt, "الصنف");
            //txt_idcat.DataBindings.Add("text", dt, "id_cat");  //if you use this it create exception because namefield change to الكود
            //txt_desccat.DataBindings.Add("text", dt, "describtion_cat");//if you use this it create exception because namefield change to الصنف

            bmb = BindingContext[dt];                                          //here give managebinding source data to controle it
            lbl_number.Text = (bmb.Position+1) + "/" + bmb.Count;               //bmb.position return number element in table
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_category_Load(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lbl_number.Text = (bmb.Position + 1) + "/" + bmb.Count;
        
        }

        private void btn_previos_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lbl_number.Text = (bmb.Position+1) + "/" + bmb.Count;
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;                              //here bmb.count=5  but position that has is 4 because podition begin 0
            lbl_number.Text = (bmb.Position+1) + "/" + bmb.Count;



        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lbl_number.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btn_new.Enabled = false;
            btn_add.Enabled = true;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            txt_idcat.Text = id.ToString();
            txt_desccat.Focus();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();      //to end any process add or delete or update here you say finish process add to execute it here complete edit because tools on form contact with databindingmanager 

            cmdb = new SqlCommandBuilder(da);                   //here you give it dataAdapter to treate with it
            da.Update(dt);
            MessageBox.Show("added process completed");
            btn_add.Enabled = false;
            btn_new.Enabled = true;
            lbl_number.Text = (bmb.Position + 1) + "/" + bmb.Count;
         

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("deleted succeed");
            lbl_number.Text = (bmb.Position + 1) + "/" + bmb.Count;
            btn_add.Enabled = false;
            btn_new.Enabled = true;

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("updating succeed");
            lbl_number.Text = (bmb.Position + 1) + "/" + bmb.Count;


        }
    }
}
