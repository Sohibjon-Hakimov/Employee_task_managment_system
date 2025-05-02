namespace EmployeeTaskManagementSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnEmployeeManagement = new Button();
            btnTaskManagement = new Button();
            btnProjectManagement = new Button();
            btnLoginHistory = new Button();
            btnAttendance = new Button();
            btnDepartmentManagement = new Button();
            btnNotificationManagement = new Button();
            btnTaskComments = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnEmployeeManagement
            // 
            btnEmployeeManagement.Location = new Point(100, 20);
            btnEmployeeManagement.Name = "btnEmployeeManagement";
            btnEmployeeManagement.Size = new Size(200, 40);
            btnEmployeeManagement.TabIndex = 0;
            btnEmployeeManagement.Text = "Employee Management";
            btnEmployeeManagement.UseVisualStyleBackColor = true;
            btnEmployeeManagement.Click += btnEmployeeManagement_Click;
            // 
            // btnTaskManagement
            // 
            btnTaskManagement.Location = new Point(100, 170);
            btnTaskManagement.Name = "btnTaskManagement";
            btnTaskManagement.Size = new Size(200, 40);
            btnTaskManagement.TabIndex = 1;
            btnTaskManagement.Text = "Task Management";
            btnTaskManagement.UseVisualStyleBackColor = true;
            btnTaskManagement.Click += btnTaskManagement_Click;
            // 
            // btnProjectManagement
            // 
            btnProjectManagement.Location = new Point(100, 220);
            btnProjectManagement.Name = "btnProjectManagement";
            btnProjectManagement.Size = new Size(200, 40);
            btnProjectManagement.TabIndex = 2;
            btnProjectManagement.Text = "Project Management";
            btnProjectManagement.UseVisualStyleBackColor = true;
            btnProjectManagement.Click += btnProjectManagement_Click;
            // 
            // btnLoginHistory
            // 
            btnLoginHistory.Location = new Point(100, 70);
            btnLoginHistory.Name = "btnLoginHistory";
            btnLoginHistory.Size = new Size(200, 40);
            btnLoginHistory.TabIndex = 3;
            btnLoginHistory.Text = "Login History";
            btnLoginHistory.UseVisualStyleBackColor = true;
            btnLoginHistory.Click += btnLoginHistory_Click;
            // 
            // btnAttendance
            // 
            btnAttendance.Location = new Point(100, 271);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Size = new Size(200, 40);
            btnAttendance.TabIndex = 4;
            btnAttendance.Text = "Attendance";
            btnAttendance.UseVisualStyleBackColor = true;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnDepartmentManagement
            // 
            btnDepartmentManagement.Location = new Point(100, 121);
            btnDepartmentManagement.Name = "btnDepartmentManagement";
            btnDepartmentManagement.Size = new Size(200, 40);
            btnDepartmentManagement.TabIndex = 5;
            btnDepartmentManagement.Text = "Department Management";
            btnDepartmentManagement.UseVisualStyleBackColor = true;
            btnDepartmentManagement.Click += btnDepartmentManagement_Click;
            // 
            // btnNotificationManagement
            // 
            btnNotificationManagement.Location = new Point(100, 320);
            btnNotificationManagement.Name = "btnNotificationManagement";
            btnNotificationManagement.Size = new Size(200, 40);
            btnNotificationManagement.TabIndex = 6;
            btnNotificationManagement.Text = "Notification Management";
            btnNotificationManagement.UseVisualStyleBackColor = true;
            btnNotificationManagement.Click += btnNotificationManagement_Click;
            // 
            // btnTaskComments
            // 
            btnTaskComments.Location = new Point(100, 370);
            btnTaskComments.Name = "btnTaskComments";
            btnTaskComments.Size = new Size(200, 40);
            btnTaskComments.TabIndex = 7;
            btnTaskComments.Text = "Task Comments";
            btnTaskComments.UseVisualStyleBackColor = true;
            btnTaskComments.Click += btnTaskComments_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(100, 420);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 40);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 500);
            Controls.Add(btnExit);
            Controls.Add(btnTaskComments);
            Controls.Add(btnNotificationManagement);
            Controls.Add(btnDepartmentManagement);
            Controls.Add(btnAttendance);
            Controls.Add(btnLoginHistory);
            Controls.Add(btnProjectManagement);
            Controls.Add(btnTaskManagement);
            Controls.Add(btnEmployeeManagement);
            Name = "MainForm";
            Text = "Main Form";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnEmployeeManagement;
        private System.Windows.Forms.Button btnTaskManagement;
        private System.Windows.Forms.Button btnProjectManagement;
        private System.Windows.Forms.Button btnLoginHistory;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnDepartmentManagement;
        private System.Windows.Forms.Button btnNotificationManagement;
        private System.Windows.Forms.Button btnTaskComments; // Declare Task Comments button
        private System.Windows.Forms.Button btnExit;
    }
}
