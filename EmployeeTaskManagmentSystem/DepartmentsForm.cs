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
    public partial class DepartmentsForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";

        public DepartmentsForm()
        {
            InitializeComponent();
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            LoadDepartments(); // Load data when form opens
            LoadManagers(); // Populate the Manager dropdown
        }

        private void LoadDepartments()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT d.departmentid, d.departmentname, e.fullname AS manager " +
                                   "FROM departments d " +
                                   "LEFT JOIN employees e ON d.managerid = e.employeeid";
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvDepartments.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading departments: " + ex.Message);
                }
            }
        }

        private void LoadManagers()
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
                        cmbManager.Items.Clear();
                        while (reader.Read())
                        {
                            cmbManager.Items.Add(new ComboBoxItem
                            {
                                Text = reader.GetString(1), // Full name
                                Value = reader.GetInt32(0)  // Employee ID
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading managers: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbManager.SelectedItem == null)
            {
                MessageBox.Show("Please select a manager.");
                return;
            }

            var selectedManager = (ComboBoxItem)cmbManager.SelectedItem;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO departments (departmentname, managerid) VALUES (@DepartmentName, @ManagerID)";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@ManagerID", selectedManager.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department added successfully!");
                        LoadDepartments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding department: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to update.");
                return;
            }

            if (cmbManager.SelectedItem == null)
            {
                MessageBox.Show("Please select a manager.");
                return;
            }

            var selectedManager = (ComboBoxItem)cmbManager.SelectedItem;
            int departmentId = (int)dgvDepartments.SelectedRows[0].Cells["departmentid"].Value;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE departments SET departmentname = @DepartmentName, managerid = @ManagerID WHERE departmentid = @DepartmentID";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@ManagerID", selectedManager.Value);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department updated successfully!");
                        LoadDepartments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating department: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.");
                return;
            }

            int departmentId = (int)dgvDepartments.SelectedRows[0].Cells["departmentid"].Value;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM departments WHERE departmentid = @DepartmentID";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department deleted successfully!");
                        LoadDepartments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting department: " + ex.Message);
                }
            }
        }

        private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var row = dgvDepartments.SelectedRows[0];
                txtDepartmentName.Text = row.Cells["departmentname"].Value.ToString();
                string managerName = row.Cells["manager"].Value?.ToString();

                foreach (ComboBoxItem item in cmbManager.Items)
                {
                    if (item.Text == managerName)
                    {
                        cmbManager.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }

    // Helper class for ComboBox
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
