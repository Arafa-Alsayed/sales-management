namespace products_management.pl
{
    partial class frm_allproducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.datagridproduct = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridproduct)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridproduct
            // 
            this.datagridproduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridproduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridproduct.Location = new System.Drawing.Point(0, 0);
            this.datagridproduct.MultiSelect = false;
            this.datagridproduct.Name = "datagridproduct";
            this.datagridproduct.ReadOnly = true;
            this.datagridproduct.Size = new System.Drawing.Size(551, 401);
            this.datagridproduct.TabIndex = 0;
            this.datagridproduct.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // frm_allproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 401);
            this.Controls.Add(this.datagridproduct);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_allproducts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة المنتجات";
            this.Load += new System.EventHandler(this.frm_allproducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridproduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView datagridproduct;

    }
}