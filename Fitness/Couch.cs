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
    public partial class Couch : Form
    {

        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        int UserID;
        public Couch()
        {
            InitializeComponent();
        }
        public Couch(int u)
        {
            InitializeComponent();
            UserID = u;
            openChildForm(new Profile(UserID));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(100, 88, 255);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            mainpanel.Location = Point;
            mainpanel.Show();
            Clients.Hide();
            openChildForm(new Profile(UserID, 1));

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(childForm);
            mainpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        Point Point = new Point(10, 74);
        private void UserButton_Click(object sender, EventArgs e)
        {
            Clients.Hide();
            mainpanel.Location = Point;
            mainpanel.Show();
            openChildForm(new Profile(UserID,1));
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            UpdateClients();
            mainpanel.Hide();
            Clients.Show();
            Clients.Location = Point;

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new ReferenceForCouch());
            Clients.Hide();
            mainpanel.Show();
        }

        private void UpdateClients()
        {
            try
            {
                string query = $"exec GetClients N'{UserID}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    AllDataGridView.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"exec FindClients N'{UserID}',N'%{gunaTextBox2.Text}%'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    AllDataGridView.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaTextBox2_Enter(object sender, EventArgs e)
        {
            gunaTextBox2.Text = "";
        }

        private void gunaButton19_Click(object sender, EventArgs e)
        {

        }
    }
}
