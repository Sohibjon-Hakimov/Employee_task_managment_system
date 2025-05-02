using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace EmployeeTaskManagementSystem
{
    public partial class EmployeeForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";
        private int selectedEmployeeID; // To store the selected Employee ID for editing/deletion

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees(); // Populate the DataGridView with employee data
        }

        private void LoadEmployees()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT EmployeeID, FullName, Username, Email, Phone, Role, DateHired FROM Employees";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvEmployees.DataSource = dt; // Bind data to the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employees: " + ex.Message);
                }
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Employees (FullName, Username, Password, Email, Phone, Role, DateHired) " +
                                   "VALUES (@FullName, @Username, @Password, @Email, @Phone, @Role, @DateHired)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DateHired", dtpDateHired.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee added successfully!");
                        LoadEmployees(); // Refresh the DataGridView
                        ClearFields(); // Clear input fields
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding employee: " + ex.Message);
                }
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == 0)
            {
                MessageBox.Show("Please select an employee to edit!");
                return;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Employees SET FullName = @FullName, Username = @Username, Password = @Password, " +
                                   "Email = @Email, Phone = @Phone, Role = @Role, DateHired = @DateHired WHERE EmployeeID = @EmployeeID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DateHired", dtpDateHired.Value);
                        cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee updated successfully!");
                        LoadEmployees(); // Refresh the DataGridView
                        ClearFields(); // Clear input fields
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error editing employee: " + ex.Message);
                }
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeID == 0)
            {
                MessageBox.Show("Please select an employee to delete!");
                return;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee deleted successfully!");
                        LoadEmployees(); // Refresh the DataGridView
                        ClearFields(); // Clear input fields
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting employee: " + ex.Message);
                }
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                selectedEmployeeID = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                txtFullName.Text = dgvEmployees.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtUsername.Text = dgvEmployees.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                txtEmail.Text = dgvEmployees.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtPhone.Text = dgvEmployees.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                cmbRole.SelectedItem = dgvEmployees.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                dtpDateHired.Value = Convert.ToDateTime(dgvEmployees.Rows[e.RowIndex].Cells["DateHired"].Value);
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbRole.SelectedIndex = -1;
            dtpDateHired.Value = DateTime.Now;
            selectedEmployeeID = 0; // Reset the selected ID
        }
    }
}
