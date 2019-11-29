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
    public partial class frm_allproducts : Form
    {
        public frm_allproducts()
        {
            InitializeComponent();
            bl.cls_products pro = new bl.cls_products();
            this.datagridproduct.DataSource = pro.get_all_products();
        }
        
        private void frm_allproducts_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
