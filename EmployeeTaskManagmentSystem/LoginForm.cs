using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace EmployeeTaskManagementSystem
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Username and password are required.";
                return;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to validate user and get EmployeeID and Role
                    string query = "SELECT EmployeeID, Role FROM Employees WHERE Username = @Username AND Password = @Password";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int employeeId = reader.GetInt32(0); // Get EmployeeID
                                string role = reader.GetString(1);  // Get Role

                                // Insert into LoginHistory
                                InsertLoginHistory(employeeId);

                                // Open MainForm with both role and EmployeeID
                                MainForm mainForm = new MainForm(role, employeeId);
                                this.Hide();
                                mainForm.Show();
                            }
                            else
                            {
                                lblError.Text = "Invalid username or password.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Method to insert login activity into LoginHistory
        private void InsertLoginHistory(int employeeId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO LoginHistory (EmployeeID, LoginTime) VALUES (@EmployeeID, @LoginTime)";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@LoginTime", DateTime.Now); // Add current time for login
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error logging login activity: " + ex.Message);
                }
            }
        }
    }
}

