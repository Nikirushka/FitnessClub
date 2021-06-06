using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness
{
    public partial class NewTraining : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int UserID, UserdID2;
        public NewTraining()
        {
            InitializeComponent();
        }
        int abon;
        public NewTraining(int Client, int Couch, string cliname)
        {
            InitializeComponent();
            UserID = Client;
            UserdID2 = Couch;
            label2.Text = "Клиент : " + cliname;
        }


        private void ReferenceForAdmin_Load(object sender, EventArgs e)
        {

            gunaDateTimePicker1.Value = DateTime.Now;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {  
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"insert into [Trainings] values(N'{UserID}',N'{UserdID2}',N'{gunaTextBox1.Text}',N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}')";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
