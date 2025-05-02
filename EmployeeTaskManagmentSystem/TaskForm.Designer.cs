namespace EmployeeTaskManagementSystem
{
    partial class TaskForm
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
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            cmbAssignedTo = new ComboBox();
            cmbCreatedBy = new ComboBox();
            cmbProjects = new ComboBox();
            dtpDueDate = new DateTimePicker();
            cmbPriority = new ComboBox();
            cmbStatus = new ComboBox();
            btnAddTask = new Button();
            dgvTasks = new DataGridView();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(120, 30);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Task Title";
            txtTitle.Size = new Size(200, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(120, 70);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Task Description";
            txtDescription.Size = new Size(200, 60);
            txtDescription.TabIndex = 1;
            // 
            // cmbAssignedTo
            // 
            cmbAssignedTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedTo.FormattingEnabled = true;
            cmbAssignedTo.Location = new Point(120, 150);
            cmbAssignedTo.Name = "cmbAssignedTo";
            cmbAssignedTo.Size = new Size(200, 28);
            cmbAssignedTo.TabIndex = 2;
            // 
            // cmbCreatedBy
            // 
            cmbCreatedBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCreatedBy.FormattingEnabled = true;
            cmbCreatedBy.Location = new Point(120, 190);
            cmbCreatedBy.Name = "cmbCreatedBy";
            cmbCreatedBy.Size = new Size(200, 28);
            cmbCreatedBy.TabIndex = 3;
            // 
            // cmbProjects
            // 
            cmbProjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjects.FormattingEnabled = true;
            cmbProjects.Location = new Point(120, 230);
            cmbProjects.Name = "cmbProjects";
            cmbProjects.Size = new Size(200, 28);
            cmbProjects.TabIndex = 4;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(120, 270);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(200, 27);
            dtpDueDate.TabIndex = 5;
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Low", "Medium", "High" });
            cmbPriority.Location = new Point(120, 310);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(200, 28);
            cmbPriority.TabIndex = 6;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Not Started", "In Progress", "Completed" });
            cmbStatus.Location = new Point(120, 350);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 28);
            cmbStatus.TabIndex = 7;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(50, 400);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(154, 40);
            btnAddTask.TabIndex = 8;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(50, 460);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.RowTemplate.Height = 29;
            dgvTasks.Size = new Size(600, 200);
            dgvTasks.TabIndex = 9;
            // 
            // btnEditTask
            // 
            btnEditTask.Location = new Point(244, 400);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(154, 40);
            btnEditTask.TabIndex = 10;
            btnEditTask.Text = "Edit Task";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(442, 400);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(154, 40);
            btnDeleteTask.TabIndex = 11;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // TaskForm
            // 
            ClientSize = new Size(700, 700);
            Controls.Add(btnEditTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(cmbAssignedTo);
            Controls.Add(cmbCreatedBy);
            Controls.Add(cmbProjects);
            Controls.Add(dgvTasks);
            Controls.Add(btnAddTask);
            Controls.Add(cmbStatus);
            Controls.Add(cmbPriority);
            Controls.Add(dtpDueDate);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Name = "TaskForm";
            Text = "Task Management";
            Load += TaskForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbAssignedTo;
        private System.Windows.Forms.ComboBox cmbCreatedBy;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.DataGridView dgvTasks;
    }
}
