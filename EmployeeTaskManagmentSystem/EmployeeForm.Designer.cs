namespace EmployeeTaskManagementSystem
{
    partial class EmployeeForm
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
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            cmbRole = new ComboBox();
            dtpDateHired = new DateTimePicker();
            btnAddEmployee = new Button();
            btnEditEmployee = new Button();
            btnDeleteEmployee = new Button();
            dgvEmployees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(20, 20);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Full Name";
            txtFullName.Size = new Size(200, 27);
            txtFullName.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 60);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(20, 180);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 4;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Employee", "Manager" });
            cmbRole.Location = new Point(20, 220);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 28);
            cmbRole.TabIndex = 5;
            // 
            // dtpDateHired
            // 
            dtpDateHired.Location = new Point(20, 260);
            dtpDateHired.Name = "dtpDateHired";
            dtpDateHired.Size = new Size(200, 27);
            dtpDateHired.TabIndex = 6;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(20, 300);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(200, 30);
            btnAddEmployee.TabIndex = 7;
            btnAddEmployee.Text = "Add User";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Location = new Point(20, 340);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(200, 30);
            btnEditEmployee.TabIndex = 8;
            btnEditEmployee.Text = "Edit User";
            btnEditEmployee.UseVisualStyleBackColor = true;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Location = new Point(20, 380);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(200, 30);
            btnDeleteEmployee.TabIndex = 9;
            btnDeleteEmployee.Text = "Delete User";
            btnDeleteEmployee.UseVisualStyleBackColor = true;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(240, 20);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 29;
            dgvEmployees.Size = new Size(600, 390);
            dgvEmployees.TabIndex = 10;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // EmployeeForm
            // 
            ClientSize = new Size(880, 450);
            Controls.Add(dgvEmployees);
            Controls.Add(btnDeleteEmployee);
            Controls.Add(btnEditEmployee);
            Controls.Add(btnAddEmployee);
            Controls.Add(dtpDateHired);
            Controls.Add(cmbRole);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtFullName);
            Name = "EmployeeForm";
            Text = "Employee Management";
            Load += EmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.DateTimePicker dtpDateHired;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.DataGridView dgvEmployees;
    }
}
