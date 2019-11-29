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
    public partial class frm_backup : Form
    {//Server=DESKTOP-JI23HNE\arafaalsayed;Database=product_db;Integrated Security=True
        SqlConnection co = new SqlConnection("Data Source=DESKTOP-JI23HNE;Initial Catalog=product_db;Integrated Security=True");
        SqlCommand cmd;
        public frm_backup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text + "\\product_db";//+ DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + DateTime.Now.ToLongTimeString().Replace(':','-');
            string strquery = "Backup Database product_db to Disk='" + filename + ".bak'";
            
            cmd = new SqlCommand(strquery, co);
            co.Open();
            cmd.ExecuteNonQuery();
            co.Close();
            MessageBox.Show("تم انشاء النسخه الاحتياطيه بنجاح", "انشاء نسخه احتياطيه", MessageBoxButtons.OK);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_backup_Load(object sender, EventArgs e)
        {
            
        }
    }
}
