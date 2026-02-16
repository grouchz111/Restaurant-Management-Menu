namespace RestaurantManager
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Menu = new System.Windows.Forms.TabPage();
            this.DgvMenu = new System.Windows.Forms.DataGridView();
            this.Admin = new System.Windows.Forms.TabPage();
            this.Orders = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Menu);
            this.tabControl1.Controls.Add(this.Admin);
            this.tabControl1.Controls.Add(this.Orders);
            this.tabControl1.Location = new System.Drawing.Point(12, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 417);
            this.tabControl1.TabIndex = 1;
            // 
            // Menu
            // 
            this.Menu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Menu.Controls.Add(this.DgvMenu);
            this.Menu.Location = new System.Drawing.Point(4, 29);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(3);
            this.Menu.Size = new System.Drawing.Size(768, 384);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "Menu";
            this.Menu.UseVisualStyleBackColor = true;
            // 
            // DgvMenu
            // 
            this.DgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMenu.Location = new System.Drawing.Point(3, 3);
            this.DgvMenu.Name = "DgvMenu";
            this.DgvMenu.ReadOnly = true;
            this.DgvMenu.RowHeadersWidth = 62;
            this.DgvMenu.RowTemplate.Height = 28;
            this.DgvMenu.Size = new System.Drawing.Size(758, 374);
            this.DgvMenu.TabIndex = 0;
            this.DgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMenu_CellContentClick);
            // 
            // Admin
            // 
            this.Admin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Admin.Location = new System.Drawing.Point(4, 29);
            this.Admin.Name = "Admin";
            this.Admin.Padding = new System.Windows.Forms.Padding(3);
            this.Admin.Size = new System.Drawing.Size(768, 384);
            this.Admin.TabIndex = 2;
            this.Admin.Text = "Admin";
            this.Admin.UseVisualStyleBackColor = true;
            // 
            // Orders
            // 
            this.Orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Orders.Location = new System.Drawing.Point(4, 29);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(768, 384);
            this.Orders.TabIndex = 3;
            this.Orders.Text = "Orders";
            this.Orders.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Menu;
        private System.Windows.Forms.DataGridView DgvMenu;
        private System.Windows.Forms.TabPage Admin;
        private System.Windows.Forms.TabPage Orders;
    }
}