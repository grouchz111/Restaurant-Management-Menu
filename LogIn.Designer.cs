namespace RestaurantManager
{
    partial class LogIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.RichTextBox();
            this.Password = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.Username);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.LogButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 276);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // LogButton
            // 
            this.LogButton.Location = new System.Drawing.Point(139, 169);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(75, 75);
            this.LogButton.TabIndex = 8;
            this.LogButton.Text = "Log in";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(6, 169);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 75);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(16, 60);
            this.Username.Multiline = false;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(198, 26);
            this.Username.TabIndex = 10;
            this.Username.Text = "";
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(16, 137);
            this.Password.Multiline = false;
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(198, 26);
            this.Password.TabIndex = 11;
            this.Password.Text = "";
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 301);
            this.Controls.Add(this.groupBox1);
            this.Name = "LogIn";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.RichTextBox Password;
        private System.Windows.Forms.RichTextBox Username;
    }
}

