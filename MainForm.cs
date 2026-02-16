using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RestaurantManager
{
    public partial class MainForm : Form
    {
        private readonly string connectionString =
            "server=localhost;user=root;database=idk12;password=12311231000;";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            

           
            if (CurrentUser.IsAdmin)
            {
            Text = "Restaurant Manager – Admin Mode";
            }
            else if (CurrentUser.IsWaiter)
            {
                Text = "Restaurant Manager – Waiter Mode";
            }

            LoadMenuData();
        }

        private void LoadMenuData()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    

                    string sql = @"
                        SELECT 
                            d.Id,
                            d.Name           AS 'Dish',
                            c.Name           AS 'Category',
                            d.Price,
                            d.Description,
                            IFNULL(d.ImagePath, 'No image') AS 'Image Path'
                        FROM Dishes d
                        LEFT JOIN Categories c ON d.CategoryId = c.Id   -- LEFT instead of INNER so you see dishes even if category missing
                        ORDER BY c.Name, d.Name";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        int rows = adapter.Fill(dt);
                        MessageBox.Show($"Query executed. Fetched {rows} rows from DB.");

                        if (DgvMenu == null)
                        {
                            MessageBox.Show("DgvMenu control is null in code. Designer name mismatch or form broken.");
                            return;
                        }

                        DgvMenu.DataSource = dt;
                        

                        // Column tweaks
                        if (DgvMenu.Columns["Id"] != null) DgvMenu.Columns["Id"].Visible = false;
                        if (DgvMenu.Columns["Image Path"] != null) DgvMenu.Columns["Image Path"].Visible = false;

                        DgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        DgvMenu.ReadOnly = true;
                        DgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        DgvMenu.AllowUserToAddRows = false;
                        DgvMenu.RowHeadersVisible = false;

                        if (DgvMenu.Columns["Price"] != null)
                        {
                            DgvMenu.Columns["Price"].DefaultCellStyle.Format = "C2";
                            DgvMenu.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }

                        if (rows == 0)
                        {
                            MessageBox.Show("Zero rows returned. But COUNT(*) says 12? Check CategoryId values match Categories table.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadMenuData exploded:\n{ex.Message}\n\n{ex.StackTrace}", "Critical Fuck-up");
            }
        }

        private void DgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string dish = DgvMenu.Rows[e.RowIndex].Cells["Dish"].Value?.ToString() ?? "???";
            MessageBox.Show($"Clicked dish: {dish}", "Row Click Debug");
        }
    }
}