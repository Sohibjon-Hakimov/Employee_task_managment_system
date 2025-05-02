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
    public partial class LoginHistoryForm : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=Boburjon2005";

        public LoginHistoryForm()
        {
            InitializeComponent();
        }

        private void LoginHistoryForm_Load(object sender, EventArgs e)
        {
            LoadLoginHistory();
        }

        private void LoadLoginHistory()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT lh.LoginID, e.FullName AS EmployeeName, lh.LoginTime
                        FROM LoginHistory lh
                        JOIN Employees e ON lh.EmployeeID = e.EmployeeID
                        ORDER BY lh.LoginTime DESC";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLoginHistory.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading login history: " + ex.Message);
                }
            }
        }
    }
}
