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
                SetupAdminControls();
            }
            else if (CurrentUser.IsWaiter)
            {
                Text = "Restaurant Manager – Waiter Mode";
                // Hide admin tab for non-admin users
                tabControl1.TabPages.Remove(Admin);
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
                    string sql = @"
                        SELECT d.Id, COALESCE(s.Quantity, 0) AS quantity 
                        FROM Dishes d
                        LEFT JOIN Stock s ON d.Id = s.DishId";
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

            DataRow[] existingRows = orderItems.Select($"DishId = {dishId}");
            if (existingRows.Length > 0)
            {
                DataRow existingRow = existingRows[0];
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
            string updateSql = "UPDATE Stock SET Quantity = Quantity - @quantity, LastUpdated = NOW() WHERE DishId = @dishId AND Quantity >= @quantity";
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

        private void SetupAdminControls()
        {
            try
            {
                // Setup stock management controls
                LoadStockDishComboBox();
                LoadStockGrid();
                LoadDiscountGrid();

                // Wire up event handlers
                btnAddStock.Click += BtnAddStock_Click;
                btnCreateDiscount.Click += BtnCreateDiscount_Click;
                btnDeleteDiscount.Click += BtnDeleteDiscount_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up admin controls: {ex.Message}", "Error");
            }
        }

        private void LoadStockDishComboBox()
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
                        cmbStockDish.Items.Clear();
                        while (reader.Read())
                        {
                            cmbStockDish.Items.Add(new { 
                                Id = reader.GetInt32("Id"), 
                                Name = reader.GetString("Name") 
                            });
                        }
                    }
                }
                cmbStockDish.DisplayMember = "Name";
                cmbStockDish.ValueMember = "Id";
                if (cmbStockDish.Items.Count > 0)
                    cmbStockDish.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock dishes: {ex.Message}", "Error");
            }
        }

        private void LoadStockGrid()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            d.Id,
                            d.Name AS 'Dish',
                            COALESCE(s.Quantity, 0) AS 'Stock',
                            s.LastUpdated AS 'Last Updated'
                        FROM Dishes d
                        LEFT JOIN Stock s ON d.Id = s.DishId
                        ORDER BY d.Name";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStock.DataSource = dt;

                        if (dgvStock.Columns["Id"] != null) dgvStock.Columns["Id"].Visible = false;

                        dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvStock.ReadOnly = true;
                        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvStock.AllowUserToAddRows = false;
                        dgvStock.RowHeadersVisible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading stock grid: {ex.Message}", "Error");
            }
        }

        private void LoadDiscountGrid()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            Id,
                            Name AS 'Discount Name',
                            DiscountType AS 'Type',
                            DiscountValue AS 'Value',
                            MinOrderAmount AS 'Min Order',
                            StartDate AS 'Start Date',
                            EndDate AS 'End Date',
                            IsActive AS 'Active'
                        FROM Discounts
                        ORDER BY CreatedAt DESC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvDiscounts.DataSource = dt;

                        if (dgvDiscounts.Columns["Id"] != null) dgvDiscounts.Columns["Id"].Visible = false;

                        dgvDiscounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvDiscounts.ReadOnly = true;
                        dgvDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvDiscounts.AllowUserToAddRows = false;
                        dgvDiscounts.RowHeadersVisible = false;

                        // Format columns
                        if (dgvDiscounts.Columns["Value"] != null)
                        {
                            dgvDiscounts.Columns["Value"].DefaultCellStyle.Format = "C2";
                        }
                        if (dgvDiscounts.Columns["Min Order"] != null)
                        {
                            dgvDiscounts.Columns["Min Order"].DefaultCellStyle.Format = "C2";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discount grid: {ex.Message}", "Error");
            }
        }

        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            if (cmbStockDish.SelectedItem == null)
            {
                MessageBox.Show("Please select a dish.", "Validation Error");
                return;
            }

            var selectedDish = cmbStockDish.SelectedItem;
            int dishId = ((dynamic)selectedDish).Id;
            int quantityToAdd = (int)nudStockQuantity.Value;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Check if stock record exists
                            string checkSql = "SELECT Quantity FROM Stock WHERE DishId = @dishId";
                            using (var checkCmd = new MySqlCommand(checkSql, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@dishId", dishId);
                                object result = checkCmd.ExecuteScalar();

                                if (result != null)
                                {
                                    // Update existing stock
                                    string updateSql = "UPDATE Stock SET Quantity = Quantity + @quantity, LastUpdated = NOW(), UpdatedBy = @userId WHERE DishId = @dishId";
                                    using (var updateCmd = new MySqlCommand(updateSql, conn, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@quantity", quantityToAdd);
                                        updateCmd.Parameters.AddWithValue("@dishId", dishId);
                                        updateCmd.Parameters.AddWithValue("@userId", GetCurrentUserId());
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Insert new stock record
                                    string insertSql = "INSERT INTO Stock (DishId, Quantity, UpdatedBy) VALUES (@dishId, @quantity, @userId)";
                                    using (var insertCmd = new MySqlCommand(insertSql, conn, transaction))
                                    {
                                        insertCmd.Parameters.AddWithValue("@dishId", dishId);
                                        insertCmd.Parameters.AddWithValue("@quantity", quantityToAdd);
                                        insertCmd.Parameters.AddWithValue("@userId", GetCurrentUserId());
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Successfully added {quantityToAdd} units to stock!", "Success");
                            
                            // Refresh displays
                            LoadStockGrid();
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
                MessageBox.Show($"Error adding stock: {ex.Message}", "Error");
            }
        }

        private void BtnCreateDiscount_Click(object sender, EventArgs e)
        {
            // Create a simple discount creation dialog
            using (var form = new Form())
            {
                form.Text = "Create New Discount";
                form.Size = new Size(400, 350);
                form.StartPosition = FormStartPosition.CenterParent;

                // Controls
                var lblName = new Label { Text = "Discount Name:", Location = new Point(20, 20), Size = new Size(100, 23) };
                var txtName = new TextBox { Location = new Point(120, 20), Size = new Size(250, 23) };
                
                var lblType = new Label { Text = "Discount Type:", Location = new Point(20, 50), Size = new Size(100, 23) };
                var cmbType = new ComboBox { Location = new Point(120, 50), Size = new Size(250, 23) };
                cmbType.Items.AddRange(new[] { "Percentage", "FixedAmount" });
                cmbType.SelectedIndex = 0;
                
                var lblValue = new Label { Text = "Discount Value:", Location = new Point(20, 80), Size = new Size(100, 23) };
                var nudValue = new NumericUpDown { Location = new Point(120, 80), Size = new Size(100, 23), Minimum = 0, Maximum = 10000, DecimalPlaces = 2 };
                
                var lblMinOrder = new Label { Text = "Min Order Amount:", Location = new Point(20, 110), Size = new Size(100, 23) };
                var nudMinOrder = new NumericUpDown { Location = new Point(120, 110), Size = new Size(100, 23), Minimum = 0, Maximum = 10000, DecimalPlaces = 2 };
                
                var lblStartDate = new Label { Text = "Start Date:", Location = new Point(20, 140), Size = new Size(100, 23) };
                var dtpStartDate = new DateTimePicker { Location = new Point(120, 140), Size = new Size(150, 23) };
                
                var lblEndDate = new Label { Text = "End Date:", Location = new Point(20, 170), Size = new Size(100, 23) };
                var dtpEndDate = new DateTimePicker { Location = new Point(120, 170), Size = new Size(150, 23) };
                
                var btnCreate = new Button { Text = "Create Discount", Location = new Point(120, 220), Size = new Size(100, 30), BackColor = Color.Green, ForeColor = Color.White };
                var btnCancel = new Button { Text = "Cancel", Location = new Point(230, 220), Size = new Size(80, 30) };

                form.Controls.AddRange(new Control[] { lblName, txtName, lblType, cmbType, lblValue, nudValue, lblMinOrder, nudMinOrder, lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, btnCreate, btnCancel });

                btnCreate.Click += (s, args) =>
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        MessageBox.Show("Please enter a discount name.", "Validation Error");
                        return;
                    }

                    if (nudValue.Value <= 0)
                    {
                        MessageBox.Show("Discount value must be greater than 0.", "Validation Error");
                        return;
                    }

                    if (dtpEndDate.Value <= dtpStartDate.Value)
                    {
                        MessageBox.Show("End date must be after start date.", "Validation Error");
                        return;
                    }

                    try
                    {
                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string sql = @"
                                INSERT INTO Discounts (Name, DiscountType, DiscountValue, MinOrderAmount, StartDate, EndDate, CreatedBy)
                                VALUES (@name, @type, @value, @minOrder, @startDate, @endDate, @userId)";

                            using (var cmd = new MySqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", txtName.Text);
                                cmd.Parameters.AddWithValue("@type", cmbType.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@value", nudValue.Value);
                                cmd.Parameters.AddWithValue("@minOrder", nudMinOrder.Value);
                                cmd.Parameters.AddWithValue("@startDate", dtpStartDate.Value);
                                cmd.Parameters.AddWithValue("@endDate", dtpEndDate.Value);
                                cmd.Parameters.AddWithValue("@userId", GetCurrentUserId());
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Discount created successfully!", "Success");
                        LoadDiscountGrid();
                        form.DialogResult = DialogResult.OK;
                        form.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating discount: {ex.Message}", "Error");
                    }
                };

                btnCancel.Click += (s, args) => { form.DialogResult = DialogResult.Cancel; form.Close(); };

                form.ShowDialog();
            }
        }

        private void BtnDeleteDiscount_Click(object sender, EventArgs e)
        {
            if (dgvDiscounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a discount to delete.", "Validation Error");
                return;
            }

            int discountId = Convert.ToInt32(dgvDiscounts.SelectedRows[0].Cells["Id"].Value);
            string discountName = dgvDiscounts.SelectedRows[0].Cells["Discount Name"].Value?.ToString() ?? "Unknown";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the discount '{discountName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM Discounts WHERE Id = @discountId";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@discountId", discountId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Discount deleted successfully!", "Success");
                    LoadDiscountGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting discount: {ex.Message}", "Error");
                }
            }
        }

        private void Admin_Click(object sender, EventArgs e)
        {

        }
    }
}