using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace RestaurantManager
{
    public partial class MainForm : Form
    {
        private readonly string connectionString =
            "server=127.0.0.1;port=3306;user=root;database=Restaurant;password=rootpass;";

        private DataTable orderItems = new DataTable();
        private Dictionary<int, int> dishStock = new Dictionary<int, int>();

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
            InitializeOrderControls();
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
                        LEFT JOIN Categories c ON d.CategoryId = c.Id
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
                            MessageBox.Show("Zero rows returned. Check CategoryId values match Categories table.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadMenuData exploded:\n{ex.Message}\n\n{ex.StackTrace}", "Critical Error");
            }
        }

        private void DgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string dish = DgvMenu.Rows[e.RowIndex].Cells["Dish"].Value?.ToString() ?? "???";
            MessageBox.Show($"Clicked dish: {dish}", "Row Click Debug");
        }

        private void InitializeOrderControls()
        {
            orderItems.Columns.Add("DishId", typeof(int));
            orderItems.Columns.Add("DishName", typeof(string));
            orderItems.Columns.Add("Quantity", typeof(int));
            orderItems.Columns.Add("UnitPrice", typeof(decimal));
            orderItems.Columns.Add("TotalPrice", typeof(decimal));

            dgvOrderItems.DataSource = orderItems;
            dgvOrderItems.Columns["DishId"].Visible = false;
            dgvOrderItems.Columns["UnitPrice"].Visible = false;
            dgvOrderItems.ReadOnly = false;
            dgvOrderItems.AllowUserToDeleteRows = true;

            LoadDishComboBox();
            LoadStockData();
        }

        private void LoadDishComboBox()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id, Name FROM Dishes ORDER BY Name";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbDish.Items.Clear();
                        while (reader.Read())
                        {
                            cmbDish.Items.Add(new { 
                                Id = reader.GetInt32("Id"), 
                                Name = reader.GetString("Name") 
                            });
                        }
                    }
                }
                cmbDish.DisplayMember = "Name";
                cmbDish.ValueMember = "Id";
                if (cmbDish.Items.Count > 0)
                    cmbDish.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dishes: {ex.Message}", "Error");
            }
        }

        private void LoadStockData()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id, quantity FROM Menu";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        dishStock.Clear();
                        while (reader.Read())
                        {
                            dishStock[reader.GetInt32("Id")] = reader.GetInt32("quantity");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock data: {ex.Message}", "Error");
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (cmbDish.SelectedItem == null)
            {
                MessageBox.Show("Please select a dish.", "Validation Error");
                return;
            }

            var selectedDish = cmbDish.SelectedItem;
            int dishId = ((dynamic)selectedDish).Id;
            string dishName = ((dynamic)selectedDish).Name;
            int quantity = (int)nudQuantity.Value;

            if (dishStock.ContainsKey(dishId) && dishStock[dishId] < quantity)
            {
                MessageBox.Show($"Not enough stock for {dishName}. Available: {dishStock[dishId]}", "Stock Error");
                return;
            }

            decimal unitPrice = GetDishPrice(dishId);
            if (unitPrice == 0)
            {
                MessageBox.Show("Could not get dish price.", "Error");
                return;
            }

            DataRow existingRow = orderItems.Select($"DishId = {dishId}").FirstOrDefault();
            if (existingRow != null)
            {
                int newQuantity = (int)existingRow["Quantity"] + quantity;
                existingRow["Quantity"] = newQuantity;
                existingRow["TotalPrice"] = newQuantity * unitPrice;
            }
            else
            {
                orderItems.Rows.Add(dishId, dishName, quantity, unitPrice, quantity * unitPrice);
            }

            UpdateTotal();
        }

        private decimal GetDishPrice(int dishId)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Price FROM Dishes WHERE Id = @dishId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@dishId", dishId);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting dish price: {ex.Message}", "Error");
                return 0;
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in orderItems.Rows)
            {
                total += Convert.ToDecimal(row["TotalPrice"]);
            }
            lblTotal.Text = $"Total: ${total:F2}";
        }

        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            if (orderItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add items to the order first.", "Validation Error");
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            decimal totalPrice = 0;
                            foreach (DataRow row in orderItems.Rows)
                                totalPrice += Convert.ToDecimal(row["TotalPrice"]);

                            string insertOrderSql = @"INSERT INTO Orders (WaiterId, TotalPrice, OrderDate) 
                                                   VALUES (@waiterId, @totalPrice, NOW())";
                            using (var cmd = new MySqlCommand(insertOrderSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@waiterId", GetCurrentUserId());
                                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                                cmd.ExecuteNonQuery();
                                
                                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                                int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                                foreach (DataRow row in orderItems.Rows)
                                {
                                    int dishId = Convert.ToInt32(row["DishId"]);
                                    int quantity = Convert.ToInt32(row["Quantity"]);
                                    decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);

                                    string insertItemSql = @"INSERT INTO OrderItems (OrderId, DishId, Quantity, PriceAtOrder) 
                                                           VALUES (@orderId, @dishId, @quantity, @unitPrice)";
                                    using (var itemCmd = new MySqlCommand(insertItemSql, conn, transaction))
                                    {
                                        itemCmd.Parameters.AddWithValue("@orderId", orderId);
                                        itemCmd.Parameters.AddWithValue("@dishId", dishId);
                                        itemCmd.Parameters.AddWithValue("@quantity", quantity);
                                        itemCmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                                        itemCmd.ExecuteNonQuery();
                                    }

                                    UpdateStock(dishId, quantity, conn, transaction);
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Order completed successfully!", "Success");
                            
                            orderItems.Clear();
                            UpdateTotal();
                            LoadStockData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing order: {ex.Message}", "Error");
            }
        }

        private void UpdateStock(int dishId, int quantity, MySqlConnection conn, MySqlTransaction transaction)
        {
            string updateSql = "UPDATE Menu SET quantity = quantity - @quantity WHERE Id = @dishId AND quantity >= @quantity";
            using (var cmd = new MySqlCommand(updateSql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@dishId", dishId);
                int rowsAffected = cmd.ExecuteNonQuery();
                
                if (rowsAffected == 0)
                {
                    throw new Exception("Insufficient stock or item not found");
                }
            }
        }

        private int GetCurrentUserId()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id FROM Users WHERE Username = @username";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", CurrentUser.Username);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting user ID: {ex.Message}", "Error");
                return 0;
            }
        }
    }
}