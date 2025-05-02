namespace EmployeeTaskManagementSystem
{
    partial class TaskCommentsForm
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
            this.dgvTaskComments = new System.Windows.Forms.DataGridView();
            this.txtCommentText = new System.Windows.Forms.TextBox();
            this.cmbTasks = new System.Windows.Forms.ComboBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskComments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaskComments
            // 
            this.dgvTaskComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskComments.Location = new System.Drawing.Point(50, 200);
            this.dgvTaskComments.Name = "dgvTaskComments";
            this.dgvTaskComments.RowHeadersWidth = 51;
            this.dgvTaskComments.RowTemplate.Height = 29;
            this.dgvTaskComments.Size = new System.Drawing.Size(700, 250);
            this.dgvTaskComments.TabIndex = 0;
            // 
            // txtCommentText
            // 
            this.txtCommentText.Location = new System.Drawing.Point(150, 100);
            this.txtCommentText.Multiline = true;
            this.txtCommentText.Name = "txtCommentText";
            this.txtCommentText.Size = new System.Drawing.Size(300, 60);
            this.txtCommentText.TabIndex = 1;
            // 
            // cmbTasks
            // 
            this.cmbTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTasks.FormattingEnabled = true;
            this.cmbTasks.Location = new System.Drawing.Point(150, 50);
            this.cmbTasks.Name = "cmbTasks";
            this.cmbTasks.Size = new System.Drawing.Size(300, 28);
            this.cmbTasks.TabIndex = 2;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(50, 50);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(43, 20);
            this.lblTask.TabIndex = 3;
            this.lblTask.Text = "Task:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(50, 100);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(78, 20);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Comment:";
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(500, 50);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(150, 40);
            this.btnAddComment.TabIndex = 5;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // btnEditComment
            // 
            this.btnEditComment.Location = new System.Drawing.Point(500, 100);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(150, 40);
            this.btnEditComment.TabIndex = 6;
            this.btnEditComment.Text = "Edit Comment";
            this.btnEditComment.UseVisualStyleBackColor = true;
            this.btnEditComment.Click += new System.EventHandler(this.btnEditComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Location = new System.Drawing.Point(500, 150);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteComment.TabIndex = 7;
            this.btnDeleteComment.Text = "Delete Comment";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // TaskCommentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnDeleteComment);
            this.Controls.Add(this.btnEditComment);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.cmbTasks);
            this.Controls.Add(this.txtCommentText);
            this.Controls.Add(this.dgvTaskComments);
            this.Name = "TaskCommentsForm";
            this.Text = "Task Comments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvTaskComments;
        private System.Windows.Forms.TextBox txtCommentText;
        private System.Windows.Forms.ComboBox cmbTasks;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
    }
}
