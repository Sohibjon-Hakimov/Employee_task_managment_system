namespace EmployeeTaskManagementSystem
{
    partial class NotificationsForm
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
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbEmployee = new System.Windows.Forms.ComboBox(); // Changed to ComboBox
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label(); // Updated label
            this.btnAddNotification = new System.Windows.Forms.Button();
            this.btnEditNotification = new System.Windows.Forms.Button();
            this.btnDeleteNotification = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Location = new System.Drawing.Point(50, 250);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.RowHeadersWidth = 51;
            this.dgvNotifications.RowTemplate.Height = 29;
            this.dgvNotifications.Size = new System.Drawing.Size(700, 250);
            this.dgvNotifications.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(150, 30);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(200, 60);
            this.txtMessage.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Info",
            "Warning",
            "Error"});
            this.cmbType.Location = new System.Drawing.Point(150, 110);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 28);
            this.cmbType.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(150, 160);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 27);
            this.dtpDate.TabIndex = 3;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(150, 210);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(200, 28);
            this.cmbEmployee.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(50, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(69, 20);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(50, 110);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 20);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 160);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date:";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(50, 210);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(75, 20);
            this.lblEmployee.TabIndex = 8;
            this.lblEmployee.Text = "Employee:";
            // 
            // btnAddNotification
            // 
            this.btnAddNotification.Location = new System.Drawing.Point(400, 30);
            this.btnAddNotification.Name = "btnAddNotification";
            this.btnAddNotification.Size = new System.Drawing.Size(150, 40);
            this.btnAddNotification.TabIndex = 9;
            this.btnAddNotification.Text = "Add Notification";
            this.btnAddNotification.UseVisualStyleBackColor = true;
            this.btnAddNotification.Click += new System.EventHandler(this.btnAddNotification_Click);
            // 
            // btnEditNotification
            // 
            this.btnEditNotification.Location = new System.Drawing.Point(400, 80);
            this.btnEditNotification.Name = "btnEditNotification";
            this.btnEditNotification.Size = new System.Drawing.Size(150, 40);
            this.btnEditNotification.TabIndex = 10;
            this.btnEditNotification.Text = "Edit Notification";
            this.btnEditNotification.UseVisualStyleBackColor = true;
            this.btnEditNotification.Click += new System.EventHandler(this.btnEditNotification_Click);
            // 
            // btnDeleteNotification
            // 
            this.btnDeleteNotification.Location = new System.Drawing.Point(400, 130);
            this.btnDeleteNotification.Name = "btnDeleteNotification";
            this.btnDeleteNotification.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteNotification.TabIndex = 11;
            this.btnDeleteNotification.Text = "Delete Notification";
            this.btnDeleteNotification.UseVisualStyleBackColor = true;
            this.btnDeleteNotification.Click += new System.EventHandler(this.btnDeleteNotification_Click);
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnDeleteNotification);
            this.Controls.Add(this.btnEditNotification);
            this.Controls.Add(this.btnAddNotification);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.dgvNotifications);
            this.Name = "NotificationsForm";
            this.Text = "Notifications";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvNotifications;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnAddNotification;
        private System.Windows.Forms.Button btnEditNotification;
        private System.Windows.Forms.Button btnDeleteNotification;
    }
}
