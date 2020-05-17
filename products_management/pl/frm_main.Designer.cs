namespace products_management.pl
{
    partial class frm_main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_register_enter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_restore_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_dobackup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_products = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةمنتجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالمنتجاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ادارةالاصنافToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_customers = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالعملاءToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ادارةالمبيعاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_users = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةمستخدمجديدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادارةالمستخدمينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ملفToolStripMenuItem,
            this.ToolStripMenuItem_products,
            this.ToolStripMenuItem_customers,
            this.ToolStripMenuItem_users});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ملفToolStripMenuItem
            // 
            this.ملفToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.ملفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_register_enter,
            this.ToolStripMenuItem_restore_backup,
            this.ToolStripMenuItem_dobackup,
            this.ToolStripMenuItem_exit});
            this.ملفToolStripMenuItem.Name = "ملفToolStripMenuItem";
            this.ملفToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.ملفToolStripMenuItem.Text = "ملف";
            // 
            // ToolStripMenuItem_register_enter
            // 
            this.ToolStripMenuItem_register_enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ToolStripMenuItem_register_enter.Name = "ToolStripMenuItem_register_enter";
            this.ToolStripMenuItem_register_enter.Size = new System.Drawing.Size(187, 22);
            this.ToolStripMenuItem_register_enter.Text = "تسجيل الدخول";
            this.ToolStripMenuItem_register_enter.Click += new System.EventHandler(this.ToolStripMenuItem_register_enter_Click);
            // 
            // ToolStripMenuItem_restore_backup
            // 
            this.ToolStripMenuItem_restore_backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ToolStripMenuItem_restore_backup.Name = "ToolStripMenuItem_restore_backup";
            this.ToolStripMenuItem_restore_backup.Size = new System.Drawing.Size(187, 22);
            this.ToolStripMenuItem_restore_backup.Text = "استعادة نسخه احتياطيه";
            this.ToolStripMenuItem_restore_backup.Click += new System.EventHandler(this.ToolStripMenuItem_restore_backup_Click);
            // 
            // ToolStripMenuItem_dobackup
            // 
            this.ToolStripMenuItem_dobackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ToolStripMenuItem_dobackup.Name = "ToolStripMenuItem_dobackup";
            this.ToolStripMenuItem_dobackup.Size = new System.Drawing.Size(187, 22);
            this.ToolStripMenuItem_dobackup.Text = "انشاء نسخه احتياطيه";
            this.ToolStripMenuItem_dobackup.Click += new System.EventHandler(this.ToolStripMenuItem_dobackup_Click);
            // 
            // ToolStripMenuItem_exit
            // 
            this.ToolStripMenuItem_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ToolStripMenuItem_exit.Name = "ToolStripMenuItem_exit";
            this.ToolStripMenuItem_exit.Size = new System.Drawing.Size(187, 22);
            this.ToolStripMenuItem_exit.Text = "تسجيل الخروج";
            this.ToolStripMenuItem_exit.Click += new System.EventHandler(this.ToolStripMenuItem_exit_Click);
            // 
            // ToolStripMenuItem_products
            // 
            this.ToolStripMenuItem_products.BackColor = System.Drawing.Color.White;
            this.ToolStripMenuItem_products.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافةمنتجToolStripMenuItem,
            this.ادارةالمنتجاتToolStripMenuItem,
            this.toolStripSeparator1,
            this.ادارةالاصنافToolStripMenuItem});
            this.ToolStripMenuItem_products.Name = "ToolStripMenuItem_products";
            this.ToolStripMenuItem_products.Size = new System.Drawing.Size(62, 20);
            this.ToolStripMenuItem_products.Text = "المنتجات";
            // 
            // اضافةمنتجToolStripMenuItem
            // 
            this.اضافةمنتجToolStripMenuItem.BackColor = System.Drawing.Color.Aqua;
            this.اضافةمنتجToolStripMenuItem.Name = "اضافةمنتجToolStripMenuItem";
            this.اضافةمنتجToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.اضافةمنتجToolStripMenuItem.Text = "اضافة منتج";
            this.اضافةمنتجToolStripMenuItem.Click += new System.EventHandler(this.اضافةمنتجToolStripMenuItem_Click);
            // 
            // ادارةالمنتجاتToolStripMenuItem
            // 
            this.ادارةالمنتجاتToolStripMenuItem.BackColor = System.Drawing.Color.Aqua;
            this.ادارةالمنتجاتToolStripMenuItem.Name = "ادارةالمنتجاتToolStripMenuItem";
            this.ادارةالمنتجاتToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ادارةالمنتجاتToolStripMenuItem.Text = "ادارة المنتجات";
            this.ادارةالمنتجاتToolStripMenuItem.Click += new System.EventHandler(this.ادارةالمنتجاتToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Blue;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // ادارةالاصنافToolStripMenuItem
            // 
            this.ادارةالاصنافToolStripMenuItem.BackColor = System.Drawing.Color.Aqua;
            this.ادارةالاصنافToolStripMenuItem.Name = "ادارةالاصنافToolStripMenuItem";
            this.ادارةالاصنافToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ادارةالاصنافToolStripMenuItem.Text = "ادارة الاصناف";
            this.ادارةالاصنافToolStripMenuItem.Click += new System.EventHandler(this.ادارةالاصنافToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_customers
            // 
            this.ToolStripMenuItem_customers.BackColor = System.Drawing.Color.White;
            this.ToolStripMenuItem_customers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ادارةالعملاءToolStripMenuItem,
            this.toolStripSeparator2,
            this.ادارةالمبيعاتToolStripMenuItem});
            this.ToolStripMenuItem_customers.Name = "ToolStripMenuItem_customers";
            this.ToolStripMenuItem_customers.Size = new System.Drawing.Size(52, 20);
            this.ToolStripMenuItem_customers.Text = "العملاء";
            // 
            // ادارةالعملاءToolStripMenuItem
            // 
            this.ادارةالعملاءToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.ادارةالعملاءToolStripMenuItem.Name = "ادارةالعملاءToolStripMenuItem";
            this.ادارةالعملاءToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ادارةالعملاءToolStripMenuItem.Text = "ادارة العملاء";
            this.ادارةالعملاءToolStripMenuItem.Click += new System.EventHandler(this.ادارةالعملاءToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // ادارةالمبيعاتToolStripMenuItem
            // 
            this.ادارةالمبيعاتToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.ادارةالمبيعاتToolStripMenuItem.Name = "ادارةالمبيعاتToolStripMenuItem";
            this.ادارةالمبيعاتToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ادارةالمبيعاتToolStripMenuItem.Text = "ادارة المبيعات";
            this.ادارةالمبيعاتToolStripMenuItem.Click += new System.EventHandler(this.ادارةالمبيعاتToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_users
            // 
            this.ToolStripMenuItem_users.BackColor = System.Drawing.Color.White;
            this.ToolStripMenuItem_users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافةمستخدمجديدToolStripMenuItem,
            this.ادارةالمستخدمينToolStripMenuItem});
            this.ToolStripMenuItem_users.Name = "ToolStripMenuItem_users";
            this.ToolStripMenuItem_users.Size = new System.Drawing.Size(81, 20);
            this.ToolStripMenuItem_users.Text = "المستخدمون";
            // 
            // اضافةمستخدمجديدToolStripMenuItem
            // 
            this.اضافةمستخدمجديدToolStripMenuItem.BackColor = System.Drawing.Color.DarkKhaki;
            this.اضافةمستخدمجديدToolStripMenuItem.Name = "اضافةمستخدمجديدToolStripMenuItem";
            this.اضافةمستخدمجديدToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.اضافةمستخدمجديدToolStripMenuItem.Text = "اضافة مستخدم جديد";
            this.اضافةمستخدمجديدToolStripMenuItem.Click += new System.EventHandler(this.اضافةمستخدمجديدToolStripMenuItem_Click);
            // 
            // ادارةالمستخدمينToolStripMenuItem
            // 
            this.ادارةالمستخدمينToolStripMenuItem.BackColor = System.Drawing.Color.DarkKhaki;
            this.ادارةالمستخدمينToolStripMenuItem.Name = "ادارةالمستخدمينToolStripMenuItem";
            this.ادارةالمستخدمينToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ادارةالمستخدمينToolStripMenuItem.Text = "ادارة المستخدمين";
            this.ادارةالمستخدمينToolStripMenuItem.Click += new System.EventHandler(this.ادارةالمستخدمينToolStripMenuItem_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.BackgroundImage = global::products_management.Properties.Resources.outer_space_stars_black_hole_wallpaper_1920x1080;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(615, 395);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "برنامج ادارة المبيعات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_register_enter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_exit;
        private System.Windows.Forms.ToolStripMenuItem اضافةمنتجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالمنتجاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ادارةالاصنافToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالعملاءToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ادارةالمبيعاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اضافةمستخدمجديدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ادارةالمستخدمينToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ملفToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_products;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_customers;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_users;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_dobackup;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_restore_backup;
    }
}