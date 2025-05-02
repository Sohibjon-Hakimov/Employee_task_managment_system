using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace EmployeeTaskManagementSystem
{
    public partial class ProjectForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";
        private string userRole; // Store the user's role

        public ProjectForm(string role) // Accept role as parameter
        {
            InitializeComponent();
            userRole = role;
            SetAccessControl(); // Adjust controls based on role
        }

        private void SetAccessControl()
        {
            if (userRole == "Employee")
            {
                // Disable buttons for employees
                btnAddProject.Enabled = false;
                btnEditProject.Enabled = false;
                btnDeleteProject.Enabled = false;
                txtProjectName.Enabled = false;
                txtDescription.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                cmbCreatedBy.Enabled = false;
            }
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            LoadEmployees(); // Load employees into ComboBox
            LoadProjects();  // Load projects into DataGridView
        }

        private void LoadEmployees()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT EmployeeID, Username FROM Employees";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                EmployeeID = reader.GetInt32(0),
                                Username = reader.GetString(1)
                            };

                            cmbCreatedBy.Items.Add(employee); // Add employee to ComboBox
                        }

                        cmbCreatedBy.DisplayMember = "Username"; // Show usernames in the dropdown
                        cmbCreatedBy.ValueMember = "EmployeeID"; // Use EmployeeID internally
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employees: " + ex.Message);
                }
            }
        }

        private void LoadProjects()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT p.ProjectID, p.ProjectName, p.Description, p.StartDate, p.EndDate, e.Username AS CreatedBy
                        FROM Projects p
                        JOIN Employees e ON p.CreatedBy = e.EmployeeID";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvProjects.DataSource = dt; // Show projects with usernames
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading projects: " + ex.Message);
                }
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            if (cmbCreatedBy.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid employee for 'Created By'!");
                return;
            }

            var createdBy = (Employee)cmbCreatedBy.SelectedItem;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Projects (ProjectName, Description, StartDate, EndDate, CreatedBy) " +
                                   "VALUES (@ProjectName, @Description, @StartDate, @EndDate, @CreatedBy)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@CreatedBy", createdBy.EmployeeID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Project added successfully!");

                        LoadProjects(); // Refresh the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                int projectID = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "UPDATE Projects SET ProjectName = @ProjectName, Description = @Description, " +
                                       "StartDate = @StartDate, EndDate = @EndDate, CreatedBy = @CreatedBy " +
                                       "WHERE ProjectID = @ProjectID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                            cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                            cmd.Parameters.AddWithValue("@CreatedBy", ((Employee)cmbCreatedBy.SelectedItem).EmployeeID);
                            cmd.Parameters.AddWithValue("@ProjectID", projectID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Project updated successfully!");
                            LoadProjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating project: " + ex.Message);
                    }
                }
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                int projectID = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectID"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM Projects WHERE ProjectID = @ProjectID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ProjectID", projectID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Project deleted successfully!");
                            LoadProjects();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting project: " + ex.Message);
                    }
                }
            }
        }
    }
}
