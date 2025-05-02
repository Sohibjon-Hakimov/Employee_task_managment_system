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
    public partial class AttendanceForm : Form
    {
        private string userRole; // Role of the logged-in user
        private int employeeID;  // Employee ID of the logged-in user
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";

        public AttendanceForm(string role, int empID)
        {
            InitializeComponent();
            userRole = role;
            employeeID = empID;
            SetAttendanceAccess();
            LoadAttendance();
        }

        private void SetAttendanceAccess()
        {
            if (userRole == "Admin")
            {
                // Admin has full access
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                dgvAttendance.ReadOnly = false;
            }
            else if (userRole == "Manager")
            {
                // Manager can view attendance only
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                dgvAttendance.ReadOnly = true; // No edits allowed
            }
            else if (userRole == "Employee")
            {
                // Employee can only manage their own attendance
                btnCheckIn.Enabled = true;
                btnCheckOut.Enabled = true;
                dgvAttendance.ReadOnly = true; // Cannot edit directly
            }
        }

        private void LoadAttendance()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query;

                    if (userRole == "Admin")
                    {
                        // Admin can view all attendance
                        query = "SELECT * FROM Attendance";
                    }
                    else if (userRole == "Manager")
                    {
                        // Manager can view attendance (future: filter for department)
                        query = "SELECT * FROM Attendance";
                    }
                    else
                    {
                        // Employee can view only their own attendance
                        query = "SELECT * FROM Attendance WHERE EmployeeID = @EmployeeID";
                    }

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        if (userRole == "Employee")
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAttendance.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance: " + ex.Message);
                }
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Attendance (EmployeeID, Date, Status, CheckInTime) " +
                                   "VALUES (@EmployeeID, @Date, @Status, @CheckInTime)";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today);
                        cmd.Parameters.AddWithValue("@Status", "Present");
                        cmd.Parameters.AddWithValue("@CheckInTime", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Check-in successful!");

                        LoadAttendance(); // Refresh attendance table
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Attendance SET CheckOutTime = @CheckOutTime " +
                                   "WHERE EmployeeID = @EmployeeID AND Date = @Date";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Today);
                        cmd.Parameters.AddWithValue("@CheckOutTime", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Check-out successful!");
                        }
                        else
                        {
                            MessageBox.Show("No check-in record found for today!");
                        }

                        LoadAttendance(); // Refresh attendance table
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}

