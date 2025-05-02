using System;
using System.Windows.Forms;
using EmployeeTaskManagementSystem;


using System;
using System.Windows.Forms;
using EmployeeTaskManagementSystem;

namespace EmployeeTaskManagementSystem
{
    public partial class MainForm : Form
    {
        private string userRole; // Store the role of the logged-in user
        private int employeeID; // Store the logged-in employee ID

        // Constructor accepts the role and employee ID from LoginForm
        public MainForm(string role, int empID)
        {
            InitializeComponent();
            userRole = role;
            employeeID = empID;
            SetAccessControl(); // Adjust UI based on role
        }

        private void SetAccessControl()
        {
            if (userRole == "Admin")
            {
                // Admin has full access
                btnEmployeeManagement.Enabled = true;
                btnTaskManagement.Enabled = true;
                btnProjectManagement.Enabled = true;
                btnLoginHistory.Enabled = true;
                btnAttendance.Enabled = true;
                btnDepartmentManagement.Enabled = true;
                btnNotificationManagement.Enabled = true;
                btnTaskComments.Enabled = true; // Enable Task Comments button
            }
            else if (userRole == "Manager")
            {
                // Manager can manage tasks, projects, and departments
                btnEmployeeManagement.Enabled = false;
                btnTaskManagement.Enabled = true;
                btnProjectManagement.Enabled = true;
                btnLoginHistory.Enabled = false;
                btnAttendance.Enabled = true;
                btnDepartmentManagement.Enabled = true;
                btnNotificationManagement.Enabled = true;
                btnTaskComments.Enabled = true; // Enable Task Comments button
            }
            else if (userRole == "Employee")
            {
                // Employee can only manage their own tasks and comments
                btnEmployeeManagement.Enabled = false;
                btnTaskManagement.Enabled = true;
                btnProjectManagement.Enabled = true;
                btnLoginHistory.Enabled = false;
                btnAttendance.Enabled = true;
                btnDepartmentManagement.Enabled = false;
                btnNotificationManagement.Enabled = true;
                btnTaskComments.Enabled = true; // Enable Task Comments button
            }
            else
            {
                // Unrecognized roles have no access
                btnEmployeeManagement.Enabled = false;
                btnTaskManagement.Enabled = false;
                btnProjectManagement.Enabled = false;
                btnLoginHistory.Enabled = false;
                btnAttendance.Enabled = false;
                btnDepartmentManagement.Enabled = false;
                btnNotificationManagement.Enabled = false;
                btnTaskComments.Enabled = false;
                MessageBox.Show("Unauthorized access detected!");
            }
        }

        private void btnTaskComments_Click(object sender, EventArgs e)
        {
            TaskCommentsForm taskCommentsForm = new TaskCommentsForm(userRole, employeeID);
            taskCommentsForm.Show();
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
        }

        private void btnTaskManagement_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.Show();
        }

        private void btnProjectManagement_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm(userRole); // Pass the userRole
            projectForm.Show();
        }


        private void btnNotificationManagement_Click(object sender, EventArgs e)
        {
            NotificationsForm notificationsForm = new NotificationsForm(userRole, employeeID);
            notificationsForm.Show();
        }

        private void btnDepartmentManagement_Click(object sender, EventArgs e)
        {
            DepartmentsForm departmentsForm = new DepartmentsForm();
            departmentsForm.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm(userRole, employeeID);
            attendanceForm.Show();
        }

        private void btnLoginHistory_Click(object sender, EventArgs e)
        {
            if (userRole == "Admin")
            {
                LoginHistoryForm loginHistoryForm = new LoginHistoryForm();
                loginHistoryForm.Show();
            }
            else
            {
                MessageBox.Show("Access Denied! Only Admins can view login history.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}