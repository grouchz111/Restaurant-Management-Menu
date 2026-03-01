using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RestaurantManager
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string connStr = "server=127.0.0.1;port=3306;user=root;database=idk12;password=rootpass;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MessageBox.Show("Connected! MySQL is alive.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Password.Text = "";
            Username.Text = "";
            Username.Focus();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Username and password are required, genius.", "Missing info");
                return;
            }

            string connStr = "server=127.0.0.1;port=3306;user=root;database=Restaurant;password=rootpass;";

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", Password.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            CurrentUser.Username = Username.Text.Trim();
                            CurrentUser.Role = role;

                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong username or password.", "Login failed");
                            Password.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database unavailable.\n{ex.Message}", "Error");
            }
        }
    }
}
