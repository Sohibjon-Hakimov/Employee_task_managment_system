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
    public partial class TaskCommentsForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";
        private string userRole;
        private int employeeID;

        public TaskCommentsForm(string role, int empID)
        {
            InitializeComponent();
            userRole = role;
            employeeID = empID;
            SetAccessControl();
            LoadTasks();
            LoadComments();
        }

        // Role-based Access Control
        private void SetAccessControl()
        {
            if (userRole == "Admin" || userRole == "Manager")
            {
                btnAddComment.Enabled = true;
                btnEditComment.Enabled = true;
                btnDeleteComment.Enabled = true;
            }
            else if (userRole == "Employee")
            {
                btnAddComment.Enabled = true;
                btnEditComment.Enabled = false;
                btnDeleteComment.Enabled = false;
            }
            else
            {
                btnAddComment.Enabled = false;
                btnEditComment.Enabled = false;
                btnDeleteComment.Enabled = false;
                MessageBox.Show("Unauthorized access detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load tasks into ComboBox
        private void LoadTasks()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT taskid, title FROM tasks";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable tasks = new DataTable();
                        tasks.Load(reader);
                        cmbTasks.DataSource = tasks;
                        cmbTasks.DisplayMember = "title";
                        cmbTasks.ValueMember = "taskid";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tasks: " + ex.Message);
                }
            }
        }

        // Load comments into DataGridView
        private void LoadComments()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query;

                    if (userRole == "Admin" || userRole == "Manager")
                    {
                        query = @"
                            SELECT c.commentid, c.commenttext, c.commentdate, e.fullname AS commentedby, t.title AS task
                            FROM taskcomments c
                            INNER JOIN employees e ON c.commentedby = e.employeeid
                            INNER JOIN tasks t ON c.taskid = t.taskid";
                    }
                    else // Employee can only view their own comments
                    {
                        query = @"
                            SELECT c.commentid, c.commenttext, c.commentdate, t.title AS task
                            FROM taskcomments c
                            INNER JOIN tasks t ON c.taskid = t.taskid
                            WHERE c.commentedby = @EmployeeID";
                    }

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        if (userRole == "Employee")
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        }

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable comments = new DataTable();
                            adapter.Fill(comments);
                            dgvTaskComments.DataSource = comments;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading comments: " + ex.Message);
                }
            }
        }

        // Add Comment
        private void btnAddComment_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO taskcomments (taskid, commenttext, commentedby, commentdate)
                        VALUES (@TaskID, @CommentText, @CommentedBy, @CommentDate)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TaskID", cmbTasks.SelectedValue);
                        cmd.Parameters.AddWithValue("@CommentText", txtCommentText.Text);
                        cmd.Parameters.AddWithValue("@CommentedBy", employeeID);
                        cmd.Parameters.AddWithValue("@CommentDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Comment added successfully!");
                        LoadComments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding comment: " + ex.Message);
                }
            }
        }

        // Edit Comment
        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if (dgvTaskComments.SelectedRows.Count > 0)
            {
                int commentID = Convert.ToInt32(dgvTaskComments.SelectedRows[0].Cells["commentid"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = @"
                            UPDATE taskcomments
                            SET commenttext = @CommentText
                            WHERE commentid = @CommentID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@CommentText", txtCommentText.Text);
                            cmd.Parameters.AddWithValue("@CommentID", commentID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Comment updated successfully!");
                            LoadComments();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating comment: " + ex.Message);
                    }
                }
            }
        }

        // Delete Comment
        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (dgvTaskComments.SelectedRows.Count > 0)
            {
                int commentID = Convert.ToInt32(dgvTaskComments.SelectedRows[0].Cells["commentid"].Value);

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM taskcomments WHERE commentid = @CommentID";

                        using (var cmd = new NpgsqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@CommentID", commentID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Comment deleted successfully!");
                            LoadComments();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting comment: " + ex.Message);
                    }
                }
            }
        }
    }
}
