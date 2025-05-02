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
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace EmployeeTaskManagementSystem
{
    public partial class NotificationsForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";
        private string userRole;
        private int employeeID;

        public NotificationsForm(string role, int empID)
        {
            InitializeComponent();
            userRole = role;
            employeeID = empID;
            SetAccessControl();
            LoadEmployees(); // Load employees into the dropdown
            LoadNotifications(); // Load existing notifications
        }

        private void SetAccessControl()
        {
            if (userRole == "Admin")
            {
                btnAddNotification.Enabled = true;
                btnEditNotification.Enabled = true;
                btnDeleteNotification.Enabled = true;
            }
            else if (userRole == "Manager")
            {
                btnAddNotification.Enabled = true;
                btnEditNotification.Enabled = false;
                btnDeleteNotification.Enabled = false;
            }
            else if (userRole == "Employee")
            {
                btnAddNotification.Enabled = false;
                btnEditNotification.Enabled = false;
                btnDeleteNotification.Enabled = false;

                txtMessage.ReadOnly = true;
                cmbType.Enabled = false;
                dtpDate.Enabled = false;
                cmbEmployee.Enabled = false;
            }
        }

        // New method to load employees into cmbEmployee
        private void LoadEmployees()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT employeeid, fullname FROM employees";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable employeeTable = new DataTable();
                        employeeTable.Load(reader);

                        cmbEmployee.DataSource = employeeTable;
                        cmbEmployee.DisplayMember = "fullname";
                        cmbEmployee.ValueMember = "employeeid";
                        cmbEmployee.SelectedIndex = -1; // Ensure no preselection
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employees: " + ex.Message);
                }
            }
        }

        private void LoadNotifications()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = string.Empty;

                    if (userRole == "Admin" || userRole == "Manager")
                    {
                        query = "SELECT n.notificationid, n.message, n.type, n.date, e.fullname AS employee " +
                                "FROM notifications n " +
                                "INNER JOIN employees e ON n.employeeid = e.employeeid";
                    }
                    else if (userRole == "Employee")
                    {
                        query = "SELECT notificationid, message, type, date " +
                                "FROM notifications " +
                                "WHERE employeeid = @EmployeeID";
                    }
                    else
                    {
                        query = "SELECT 1";
                    }

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        if (userRole == "Employee")
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvNotifications.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading notifications: " + ex.Message);
                }
            }
        }

        private void btnAddNotification_Click(object sender, EventArgs e)
        {
            if (!btnAddNotification.Enabled) return;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO notifications (message, type, date, employeeid) " +
                                   "VALUES (@Message, @Type, @Date, @EmployeeID)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Message", txtMessage.Text);
                        cmd.Parameters.AddWithValue("@Type", cmbType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value);

                        // Ensure the user selected an employee
                        if (cmbEmployee.SelectedValue == null)
                        {
                            MessageBox.Show("Please select an employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(cmbEmployee.SelectedValue.ToString()));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Notification added successfully!");
                        LoadNotifications();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding notification: " + ex.Message);
                }
            }
        }

        private void btnEditNotification_Click(object sender, EventArgs e)
        {
            if (!btnEditNotification.Enabled || dgvNotifications.SelectedRows.Count == 0) return;

            int notificationID = Convert.ToInt32(dgvNotifications.SelectedRows[0].Cells["notificationid"].Value);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE notifications SET message = @Message, type = @Type, date = @Date, employeeid = @EmployeeID " +
                                   "WHERE notificationid = @NotificationID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Message", txtMessage.Text);
                        cmd.Parameters.AddWithValue("@Type", cmbType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value);

                        // Ensure the user selected an employee
                        if (cmbEmployee.SelectedValue == null)
                        {
                            MessageBox.Show("Please select an employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(cmbEmployee.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NotificationID", notificationID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Notification updated successfully!");
                        LoadNotifications();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating notification: " + ex.Message);
                }
            }
        }

        private void btnDeleteNotification_Click(object sender, EventArgs e)
        {
            if (!btnDeleteNotification.Enabled || dgvNotifications.SelectedRows.Count == 0) return;

            int notificationID = Convert.ToInt32(dgvNotifications.SelectedRows[0].Cells["notificationid"].Value);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM notifications WHERE notificationid = @NotificationID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NotificationID", notificationID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Notification deleted successfully!");
                        LoadNotifications();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting notification: " + ex.Message);
                }
            }
        }
    }
}
