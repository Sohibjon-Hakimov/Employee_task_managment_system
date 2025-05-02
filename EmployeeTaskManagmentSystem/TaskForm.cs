using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace EmployeeTaskManagementSystem
{
    public partial class TaskForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";

        public TaskForm()
        {
            InitializeComponent();
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            LoadEmployees(); // Load employees into ComboBoxes
            LoadProjects();  // Load projects into ComboBox
            LoadTasks();     // Load tasks into DataGridView
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

                            cmbAssignedTo.Items.Add(employee);
                            cmbCreatedBy.Items.Add(employee);
                        }

                        cmbAssignedTo.DisplayMember = "Username"; // Show usernames
                        cmbAssignedTo.ValueMember = "EmployeeID";

                        cmbCreatedBy.DisplayMember = "Username";
                        cmbCreatedBy.ValueMember = "EmployeeID";
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
                    string query = "SELECT ProjectID, ProjectName FROM Projects";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbProjects.Items.Add(new Project
                            {
                                ProjectID = reader.GetInt32(0),
                                ProjectName = reader.GetString(1)
                            });
                        }

                        cmbProjects.DisplayMember = "ProjectName";
                        cmbProjects.ValueMember = "ProjectID";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading projects: " + ex.Message);
                }
            }
        }

        private void LoadTasks()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            t.TaskID,
                            t.Title,
                            t.Description,
                            e1.Username AS AssignedTo,
                            e2.Username AS CreatedBy,
                            t.DueDate,
                            t.Priority,
                            t.Status
                        FROM Tasks t
                        JOIN Employees e1 ON t.AssignedTo = e1.EmployeeID
                        JOIN Employees e2 ON t.CreatedBy = e2.EmployeeID";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvTasks.DataSource = dt; // Show usernames instead of IDs
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tasks: " + ex.Message);
                }
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (cmbAssignedTo.SelectedItem == null || cmbCreatedBy.SelectedItem == null || cmbProjects.SelectedItem == null)
            {
                MessageBox.Show("Please select valid options for Assigned To, Created By, and Project!");
                return;
            }

            var assignedTo = (Employee)cmbAssignedTo.SelectedItem;
            var createdBy = (Employee)cmbCreatedBy.SelectedItem;
            var selectedProject = (Project)cmbProjects.SelectedItem;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Tasks (Title, Description, AssignedTo, CreatedBy, DueDate, Priority, Status, ProjectID) " +
                                   "VALUES (@Title, @Description, @AssignedTo, @CreatedBy, @DueDate, @Priority, @Status, @ProjectID)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@AssignedTo", assignedTo.EmployeeID);
                        cmd.Parameters.AddWithValue("@CreatedBy", createdBy.EmployeeID);
                        cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                        cmd.Parameters.AddWithValue("@Priority", cmbPriority.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ProjectID", selectedProject.ProjectID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task added successfully!");

                        LoadTasks(); // Refresh task list
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int taskID = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = @"
                    UPDATE Tasks 
                    SET Title = @Title, Description = @Description, AssignedTo = @AssignedTo, 
                        CreatedBy = @CreatedBy, DueDate = @DueDate, Priority = @Priority, 
                        Status = @Status, ProjectID = @ProjectID
                    WHERE TaskID = @TaskID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                            cmd.Parameters.AddWithValue("@AssignedTo", ((Employee)cmbAssignedTo.SelectedItem).EmployeeID);
                            cmd.Parameters.AddWithValue("@CreatedBy", ((Employee)cmbCreatedBy.SelectedItem).EmployeeID);
                            cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                            cmd.Parameters.AddWithValue("@Priority", cmbPriority.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@ProjectID", ((Project)cmbProjects.SelectedItem).ProjectID);
                            cmd.Parameters.AddWithValue("@TaskID", taskID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Task updated successfully!");
                            LoadTasks(); // Refresh the task list
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating task: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to edit!");
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int taskID = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "DELETE FROM Tasks WHERE TaskID = @TaskID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@TaskID", taskID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Task deleted successfully!");
                            LoadTasks(); // Refresh the task list
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting task: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete!");
            }
        }

    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Username { get; set; }

        public override string ToString()
        {
            return Username; // Display username in ComboBox
        }
    }

    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public override string ToString()
        {
            return ProjectName; // Display project name in ComboBox
        }
    }
}
