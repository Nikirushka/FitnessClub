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
            trainings.Hide();
            Clients.Hide();
            openChildForm(new Profile(UserID, 1));
            Trainings();

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
            trainings.Hide();
            mainpanel.Location = Point;
            mainpanel.Show();
            openChildForm(new Profile(UserID, 1));


        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            trainings.Hide();
            UpdateClients();
            mainpanel.Hide();
            Clients.Show();
            Clients.Location = Point;

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Trainings();
            trainings.Show();
            UpdateClients();
            mainpanel.Hide();
            Clients.Hide();
            trainings.Location = Point;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new ReferenceForCouch());
            Clients.Hide();
            mainpanel.Show();
            Clients.Hide();
            trainings.Hide();
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

        private void Trainings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"exec CouchProfileInfo {UserID}";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    string surn = "";
                    while (reader.Read())
                    {
                        surn = reader.GetString(0);
                    }
                    reader.Close();
                    int CouchID = 0;
                    query = $"exec GetCouch N'{surn}'";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CouchID = reader.GetInt32(0);

                    }
                    reader.Close();
                    query = $"select [User].Surname as Клиент, Description as Описание, Date as Дата from Trainings  join Client on Client.ID_client = Trainings.ID_client join[User] on[User].ID_user = Client.ID_user where ID_couch = N'{CouchID}'";

                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    trainingsDataGrid.DataSource = dataSet.Tables[0];
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
            int index = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string a = (AllDataGridView[0, index].Value.ToString());

            int ClientID = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query1 = $"exec GetClient N'{a}'";
                cmd = new SqlCommand(query1, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClientID = reader.GetInt32(0);
                }
                reader.Close();
                string query = $"exec CouchProfileInfo {UserID}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                string surn = "";
                while (reader.Read())
                {
                    surn = reader.GetString(0);
                }
                reader.Close();
                int CouchID = 0;
                query = $"exec GetCouch N'{surn}'";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CouchID = reader.GetInt32(0);
                }
                reader.Close();
                connection.Close();
                NewTraining newTraining = new NewTraining(ClientID, CouchID, a);
                DialogResult dialogResult = new DialogResult();
                dialogResult = newTraining.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            openChildForm(new About());
            Clients.Hide();
            mainpanel.Show();
            Clients.Hide();
            trainings.Hide();
        }
    }
}
