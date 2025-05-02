namespace EmployeeTaskManagementSystem
{
    partial class ProjectForm
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
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCreatedBy = new System.Windows.Forms.ComboBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnEditProject = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.dgvProjects = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(120, 30);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(200, 27);
            this.txtProjectName.TabIndex = 0;
            this.txtProjectName.PlaceholderText = "Project Name";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.PlaceholderText = "Project Description";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(120, 150);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 27);
            this.dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(120, 190);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 27);
            this.dtpEndDate.TabIndex = 3;
            // 
            // cmbCreatedBy
            // 
            this.cmbCreatedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreatedBy.FormattingEnabled = true;
            this.cmbCreatedBy.Location = new System.Drawing.Point(120, 230);
            this.cmbCreatedBy.Name = "cmbCreatedBy";
            this.cmbCreatedBy.Size = new System.Drawing.Size(200, 28);
            this.cmbCreatedBy.TabIndex = 4;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(50, 280);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(150, 40);
            this.btnAddProject.TabIndex = 5;
            this.btnAddProject.Text = "Add Project";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnEditProject
            // 
            this.btnEditProject.Location = new System.Drawing.Point(220, 280);
            this.btnEditProject.Name = "btnEditProject";
            this.btnEditProject.Size = new System.Drawing.Size(150, 40);
            this.btnEditProject.TabIndex = 6;
            this.btnEditProject.Text = "Edit Project";
            this.btnEditProject.UseVisualStyleBackColor = true;
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(390, 280);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteProject.TabIndex = 7;
            this.btnDeleteProject.Text = "Delete Project";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // dgvProjects
            // 
            this.dgvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjects.Location = new System.Drawing.Point(50, 350);
            this.dgvProjects.Name = "dgvProjects";
            this.dgvProjects.RowHeadersWidth = 51;
            this.dgvProjects.RowTemplate.Height = 29;
            this.dgvProjects.Size = new System.Drawing.Size(600, 200);
            this.dgvProjects.TabIndex = 8;
            // 
            // ProjectForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.dgvProjects);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnEditProject);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.cmbCreatedBy);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtProjectName);
            this.Name = "ProjectForm";
            this.Text = "Project Management";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cmbCreatedBy;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnEditProject;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.DataGridView dgvProjects;
    }
}
