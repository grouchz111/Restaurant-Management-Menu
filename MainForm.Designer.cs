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
            this.Orders = new System.Windows.Forms.TabPage();
            this.btnFinishOrder = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbDish = new System.Windows.Forms.ComboBox();
            this.lblDish = new System.Windows.Forms.Label();
            this.Admin = new System.Windows.Forms.TabPage();
            this.grpDiscountManagement = new System.Windows.Forms.GroupBox();
            this.btnDeleteDiscount = new System.Windows.Forms.Button();
            this.btnCreateDiscount = new System.Windows.Forms.Button();
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.grpStockManagement = new System.Windows.Forms.GroupBox();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.nudStockQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblStockQuantity = new System.Windows.Forms.Label();
            this.cmbStockDish = new System.Windows.Forms.ComboBox();
            this.lblStockDish = new System.Windows.Forms.Label();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.TabPage();
            this.DgvMenu = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Orders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.Admin.SuspendLayout();
            this.grpDiscountManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.grpStockManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockQuantity)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenu)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Orders
            // 
            this.Orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Orders.Controls.Add(this.lblDish);
            this.Orders.Controls.Add(this.cmbDish);
            this.Orders.Controls.Add(this.lblQuantity);
            this.Orders.Controls.Add(this.nudQuantity);
            this.Orders.Controls.Add(this.btnAddToOrder);
            this.Orders.Controls.Add(this.dgvOrderItems);
            this.Orders.Controls.Add(this.lblTotal);
            this.Orders.Controls.Add(this.btnFinishOrder);
            this.Orders.Location = new System.Drawing.Point(4, 29);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(802, 430);
            this.Orders.TabIndex = 3;
            this.Orders.Text = "Orders";
            this.Orders.UseVisualStyleBackColor = true;
            // 
            // btnFinishOrder
            // 
            this.btnFinishOrder.BackColor = System.Drawing.Color.Green;
            this.btnFinishOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnFinishOrder.ForeColor = System.Drawing.Color.White;
            this.btnFinishOrder.Location = new System.Drawing.Point(600, 335);
            this.btnFinishOrder.Name = "btnFinishOrder";
            this.btnFinishOrder.Size = new System.Drawing.Size(150, 35);
            this.btnFinishOrder.TabIndex = 7;
            this.btnFinishOrder.Text = "Finish Order";
            this.btnFinishOrder.UseVisualStyleBackColor = false;
            this.btnFinishOrder.Click += new System.EventHandler(this.btnFinishOrder_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(10, 340);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 29);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(10, 50);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.Size = new System.Drawing.Size(740, 280);
            this.dgvOrderItems.TabIndex = 5;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.Location = new System.Drawing.Point(430, 12);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(120, 28);
            this.btnAddToOrder.TabIndex = 4;
            this.btnAddToOrder.Text = "Add to Order";
            this.btnAddToOrder.UseVisualStyleBackColor = true;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(340, 12);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(80, 26);
            this.nudQuantity.TabIndex = 3;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(270, 15);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(72, 20);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cmbDish
            // 
            this.cmbDish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDish.FormattingEnabled = true;
            this.cmbDish.Location = new System.Drawing.Point(55, 12);
            this.cmbDish.Name = "cmbDish";
            this.cmbDish.Size = new System.Drawing.Size(200, 28);
            this.cmbDish.TabIndex = 1;
            // 
            // lblDish
            // 
            this.lblDish.AutoSize = true;
            this.lblDish.Location = new System.Drawing.Point(10, 15);
            this.lblDish.Name = "lblDish";
            this.lblDish.Size = new System.Drawing.Size(45, 20);
            this.lblDish.TabIndex = 0;
            this.lblDish.Text = "Dish:";
            // 
            // Admin
            // 
            this.Admin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Admin.Controls.Add(this.lblAdminTitle);
            this.Admin.Controls.Add(this.grpStockManagement);
            this.Admin.Controls.Add(this.grpDiscountManagement);
            this.Admin.Location = new System.Drawing.Point(4, 29);
            this.Admin.Name = "Admin";
            this.Admin.Padding = new System.Windows.Forms.Padding(3);
            this.Admin.Size = new System.Drawing.Size(1113, 430);
            this.Admin.TabIndex = 2;
            this.Admin.Text = "Admin";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // grpDiscountManagement
            // 
            this.grpDiscountManagement.Controls.Add(this.dgvDiscounts);
            this.grpDiscountManagement.Controls.Add(this.btnCreateDiscount);
            this.grpDiscountManagement.Controls.Add(this.btnDeleteDiscount);
            this.grpDiscountManagement.Location = new System.Drawing.Point(568, 60);
            this.grpDiscountManagement.Name = "grpDiscountManagement";
            this.grpDiscountManagement.Size = new System.Drawing.Size(535, 310);
            this.grpDiscountManagement.TabIndex = 2;
            this.grpDiscountManagement.TabStop = false;
            this.grpDiscountManagement.Text = "Discount Management";
            // 
            // btnDeleteDiscount
            // 
            this.btnDeleteDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDiscount.Location = new System.Drawing.Point(149, 251);
            this.btnDeleteDiscount.Name = "btnDeleteDiscount";
            this.btnDeleteDiscount.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteDiscount.TabIndex = 2;
            this.btnDeleteDiscount.Text = "Delete Discount";
            this.btnDeleteDiscount.UseVisualStyleBackColor = false;
            // 
            // btnCreateDiscount
            // 
            this.btnCreateDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnCreateDiscount.ForeColor = System.Drawing.Color.White;
            this.btnCreateDiscount.Location = new System.Drawing.Point(23, 251);
            this.btnCreateDiscount.Name = "btnCreateDiscount";
            this.btnCreateDiscount.Size = new System.Drawing.Size(120, 30);
            this.btnCreateDiscount.TabIndex = 1;
            this.btnCreateDiscount.Text = "Create Discount";
            this.btnCreateDiscount.UseVisualStyleBackColor = false;
            // 
            // dgvDiscounts
            // 
            this.dgvDiscounts.AllowUserToAddRows = false;
            this.dgvDiscounts.AllowUserToDeleteRows = false;
            this.dgvDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscounts.Location = new System.Drawing.Point(23, 25);
            this.dgvDiscounts.Name = "dgvDiscounts";
            this.dgvDiscounts.ReadOnly = true;
            this.dgvDiscounts.RowHeadersWidth = 62;
            this.dgvDiscounts.RowTemplate.Height = 28;
            this.dgvDiscounts.Size = new System.Drawing.Size(497, 220);
            this.dgvDiscounts.TabIndex = 0;
            // 
            // grpStockManagement
            // 
            this.grpStockManagement.Controls.Add(this.lblStockDish);
            this.grpStockManagement.Controls.Add(this.cmbStockDish);
            this.grpStockManagement.Controls.Add(this.lblStockQuantity);
            this.grpStockManagement.Controls.Add(this.nudStockQuantity);
            this.grpStockManagement.Controls.Add(this.btnAddStock);
            this.grpStockManagement.Controls.Add(this.dgvStock);
            this.grpStockManagement.Location = new System.Drawing.Point(10, 50);
            this.grpStockManagement.Name = "grpStockManagement";
            this.grpStockManagement.Size = new System.Drawing.Size(502, 320);
            this.grpStockManagement.TabIndex = 1;
            this.grpStockManagement.TabStop = false;
            this.grpStockManagement.Text = "Stock Management";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(15, 100);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 62;
            this.dgvStock.RowTemplate.Height = 28;
            this.dgvStock.Size = new System.Drawing.Size(385, 200);
            this.dgvStock.TabIndex = 5;
            // 
            // btnAddStock
            // 
            this.btnAddStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddStock.ForeColor = System.Drawing.Color.White;
            this.btnAddStock.Location = new System.Drawing.Point(15, 60);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(120, 30);
            this.btnAddStock.TabIndex = 4;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = false;
            // 
            // nudStockQuantity
            // 
            this.nudStockQuantity.Location = new System.Drawing.Point(320, 22);
            this.nudStockQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStockQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStockQuantity.Name = "nudStockQuantity";
            this.nudStockQuantity.Size = new System.Drawing.Size(80, 26);
            this.nudStockQuantity.TabIndex = 3;
            this.nudStockQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStockQuantity
            // 
            this.lblStockQuantity.AutoSize = true;
            this.lblStockQuantity.Location = new System.Drawing.Point(250, 25);
            this.lblStockQuantity.Name = "lblStockQuantity";
            this.lblStockQuantity.Size = new System.Drawing.Size(72, 20);
            this.lblStockQuantity.TabIndex = 2;
            this.lblStockQuantity.Text = "Quantity:";
            // 
            // cmbStockDish
            // 
            this.cmbStockDish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockDish.FormattingEnabled = true;
            this.cmbStockDish.Location = new System.Drawing.Point(60, 22);
            this.cmbStockDish.Name = "cmbStockDish";
            this.cmbStockDish.Size = new System.Drawing.Size(180, 28);
            this.cmbStockDish.TabIndex = 1;
            // 
            // lblStockDish
            // 
            this.lblStockDish.AutoSize = true;
            this.lblStockDish.Location = new System.Drawing.Point(15, 25);
            this.lblStockDish.Name = "lblStockDish";
            this.lblStockDish.Size = new System.Drawing.Size(45, 20);
            this.lblStockDish.TabIndex = 0;
            this.lblStockDish.Text = "Dish:";
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.AutoSize = true;
            this.lblAdminTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.Location = new System.Drawing.Point(13, 13);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(187, 32);
            this.lblAdminTitle.TabIndex = 0;
            this.lblAdminTitle.Text = "Admin Panel";
            // 
            // Menu
            // 
            this.Menu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Menu.Controls.Add(this.DgvMenu);
            this.Menu.Location = new System.Drawing.Point(4, 29);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(3);
            this.Menu.Size = new System.Drawing.Size(802, 430);
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
            this.DgvMenu.Size = new System.Drawing.Size(792, 420);
            this.DgvMenu.TabIndex = 0;
            this.DgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMenu_CellContentClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Menu);
            this.tabControl1.Controls.Add(this.Admin);
            this.tabControl1.Controls.Add(this.Orders);
            this.tabControl1.Location = new System.Drawing.Point(12, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 463);
            this.tabControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 547);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Orders.ResumeLayout(false);
            this.Orders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.Admin.ResumeLayout(false);
            this.Admin.PerformLayout();
            this.grpDiscountManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.grpStockManagement.ResumeLayout(false);
            this.grpStockManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockQuantity)).EndInit();
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenu)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Orders;
        private System.Windows.Forms.Label lblDish;
        private System.Windows.Forms.ComboBox cmbDish;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFinishOrder;
        private System.Windows.Forms.TabPage Admin;
        private System.Windows.Forms.Label lblAdminTitle;
        private System.Windows.Forms.GroupBox grpStockManagement;
        private System.Windows.Forms.Label lblStockDish;
        private System.Windows.Forms.ComboBox cmbStockDish;
        private System.Windows.Forms.Label lblStockQuantity;
        private System.Windows.Forms.NumericUpDown nudStockQuantity;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.GroupBox grpDiscountManagement;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.Button btnCreateDiscount;
        private System.Windows.Forms.Button btnDeleteDiscount;
        private System.Windows.Forms.TabPage Menu;
        private System.Windows.Forms.DataGridView DgvMenu;
        private System.Windows.Forms.TabControl tabControl1;
    }
}