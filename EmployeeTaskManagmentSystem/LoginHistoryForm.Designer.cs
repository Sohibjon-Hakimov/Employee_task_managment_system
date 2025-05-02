namespace EmployeeTaskManagementSystem
{
    partial class LoginHistoryForm
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
            this.dgvLoginHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoginHistory
            // 
            this.dgvLoginHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginHistory.Location = new System.Drawing.Point(20, 20);
            this.dgvLoginHistory.Name = "dgvLoginHistory";
            this.dgvLoginHistory.RowHeadersWidth = 51;
            this.dgvLoginHistory.RowTemplate.Height = 29;
            this.dgvLoginHistory.Size = new System.Drawing.Size(600, 300);
            this.dgvLoginHistory.TabIndex = 0;
            // 
            // LoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.dgvLoginHistory);
            this.Name = "LoginHistoryForm";
            this.Text = "Login History";
            this.Load += new System.EventHandler(this.LoginHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvLoginHistory;
    }
}
