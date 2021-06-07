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
    public partial class Admin : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int UserID;
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(int UserID_)
        {
            InitializeComponent();
            UserID = UserID_;
            mainpanel.Hide();
            ClientPanel.Hide();
            choosepanel.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }
        private void UpdateClients()
        {
            try
            {
                string query = $"select * from ClientInfo";

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

        private void UpdateCouch()
        {
            try
            {
                string query = $"select * from CouchInfo";

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

        private void UpdateWorker()
        {
            try
            {
                string query = $"select * from WorkerInfo";

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

        private void UpdateTranings()
        {
            try
            {
                string query = $"Select [User].Surname, TrainingsAll.[Тренер],TrainingsAll.[Специализация],TrainingsAll.[Описание], TrainingsAll.[Дата] from TrainingsAll inner join [Client] on [Client].ID_client = TrainingsAll.ID_client inner join [User] on[User].ID_user = Client.ID_user";

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


        private void Admin_Load(object sender, EventArgs e)
        {
            UpdateCouch();
            UpdateClients();
            UpdateWorker();
            choosepanel.Show();
            mainpanel.Hide();
            ClientPanel.Hide();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            NewClient newClient = new NewClient();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newClient.ShowDialog();
            UpdateClients();
        }
        
        private void gunaButton7_Click(object sender, EventArgs e)
        {
            try
            {
                
                int index = 0;
                foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string query = $"select * from [user] join client on [User].ID_user=Client.Id_user";
                AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                AllDataGridView.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    AllDataGridView.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
                connection = new SqlConnection(connectionString);
                connection.Open();

                string choose_id = (AllDataGridView[0, index].Value.ToString());

                string delQuery = $"DELETE FROM [client] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                delQuery = $"DELETE FROM [user] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
                UpdateClients();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string a = (AllDataGridView[0, index].Value.ToString());
            string b = (AllDataGridView[1, index].Value.ToString());
            string c = (AllDataGridView[2, index].Value.ToString());
            string d = (AllDataGridView[3, index].Value.ToString());
            string ee = (AllDataGridView[4, index].Value.ToString());
            string f = (AllDataGridView[5, index].Value.ToString());
            string g = (AllDataGridView[6, index].Value.ToString());
             int h= Convert.ToInt32((AllDataGridView[8, index].Value));
            int i = Convert.ToInt32((AllDataGridView[9, index].Value));
            DateTime date = Convert.ToDateTime((AllDataGridView[7, index].Value));
            int index1 = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index1 = cell.RowIndex;
            }
            string query = $"select * from [user] join client on [User].ID_user=Client.Id_user";
            AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllDataGridView.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);

                dataSet = new DataSet();
                adapter.Fill(dataSet);
                AllDataGridView.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            connection = new SqlConnection(connectionString);
            connection.Open();

            string choose_id = (AllDataGridView[0, index1].Value.ToString());

            UpdateClients();
            NewClient newClient = new NewClient(Convert.ToInt32(choose_id), a, b, c, d, ee, f,g,date,h,i);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newClient.ShowDialog();
            UpdateClients();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            choosepanel.Hide();
            ClientPanel.Show();
            mainpanel.Hide();
            UpdateCouch();
            gunaButton20.Visible = false;
            gunaButton21.Visible = false;

            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
            gunaButton8.Visible = true;
            gunaButton9.Visible = true;
            gunaButton10.Visible = true;
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            ClientPanel.Show();
            UpdateClients();
            mainpanel.Hide();
            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            choosepanel.Hide();
            gunaButton20.Visible = false;
            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton21.Visible = false;

            gunaButton5.Visible = true;
            gunaButton6.Visible = true;
            gunaButton7.Visible = true;
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            NewCouch newCouch = new NewCouch();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newCouch.ShowDialog();
            UpdateCouch();
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string a = (AllDataGridView[0, index].Value.ToString());
            string b = (AllDataGridView[1, index].Value.ToString());
            string c = (AllDataGridView[2, index].Value.ToString());
            string d = (AllDataGridView[5, index].Value.ToString());
            string ee = (AllDataGridView[6, index].Value.ToString());
            string f = (AllDataGridView[8, index].Value.ToString());
            string g = (AllDataGridView[9, index].Value.ToString());
            string h = (AllDataGridView[3, index].Value.ToString());
            int i = Convert.ToInt32((AllDataGridView[4, index].Value));
            int ll = Convert.ToInt32((AllDataGridView[7, index].Value));
            DateTime date = Convert.ToDateTime((AllDataGridView[10, index].Value));
            int index1 = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index1 = cell.RowIndex;
            }
            string query = $"select * from [user] join couch on [User].ID_user=couch.Id_user";
            AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllDataGridView.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);

                dataSet = new DataSet();
                adapter.Fill(dataSet);
                AllDataGridView.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            connection = new SqlConnection(connectionString);
            connection.Open();
            
            string choose_id = (AllDataGridView[0, index1].Value.ToString());
            UpdateCouch();
            NewCouch newCouch = new NewCouch(Convert.ToInt32(choose_id), a, b, c, d, ee, f, g, date, h, i,ll);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newCouch.ShowDialog();
            UpdateCouch();
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string query = $"select * from [user] join couch on [User].ID_user=couch.Id_user";
                AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                AllDataGridView.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    AllDataGridView.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
                connection = new SqlConnection(connectionString);
                connection.Open();

                string choose_id = (AllDataGridView[0, index].Value.ToString());

                string delQuery = $"DELETE FROM [couch] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                delQuery = $"DELETE FROM [user] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
                UpdateCouch();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            choosepanel.Hide();
            ClientPanel.Hide();
            mainpanel.Show();
            openChildForm(new ReferenceForAdmin());
            gunaButton20.Visible = false;
            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton21.Visible = false;

            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            choosepanel.Hide();
            mainpanel.Hide();
            ClientPanel.Show();
            UpdateWorker();
            gunaButton21.Visible = false;

            gunaButton20.Visible = true;
            gunaButton19.Visible = true;
            gunaButton18.Visible = true;
            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
        }

        private void gunaButton14_Click(object sender, EventArgs e)
        {
            mainpanel.Hide();
            ClientPanel.Show();
            choosepanel.Hide();
            UpdateWorker();
            gunaButton20.Visible = true;
            gunaButton19.Visible = true;
            gunaButton18.Visible = true;
            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainpanel.Hide();
            choosepanel.Show();
            ClientPanel.Hide();
        }

        private void gunaButton20_Click(object sender, EventArgs e)
        {
            NewWorker newWorker = new NewWorker();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newWorker.ShowDialog();
            UpdateWorker();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            UpdateTranings();
            choosepanel.Hide();
            ClientPanel.Show();
            mainpanel.Hide();
            gunaButton20.Visible = false;
            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
            gunaButton21.Visible = true;

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            gunaButton20.Visible = false;
            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
        }

        private void gunaButton19_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string a = (AllDataGridView[0, index].Value.ToString());
            string b = (AllDataGridView[1, index].Value.ToString());
            string c = (AllDataGridView[2, index].Value.ToString());
            string d = (AllDataGridView[3, index].Value.ToString());
            string ee = (AllDataGridView[4, index].Value.ToString());
            string f = (AllDataGridView[5, index].Value.ToString());
            string g = (AllDataGridView[6, index].Value.ToString());
            DateTime date = Convert.ToDateTime((AllDataGridView[7, index].Value));
            int index1 = 0;
            foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            {
                index1 = cell.RowIndex;
            }
            string query = $"select * from [user] join admin on [User].ID_user=admin.Id_user";
            AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllDataGridView.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);

                dataSet = new DataSet();
                adapter.Fill(dataSet);
                AllDataGridView.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            connection = new SqlConnection(connectionString);
            connection.Open();

            string choose_id = (AllDataGridView[0, index1].Value.ToString());
            UpdateWorker();
            NewWorker newWorker = new NewWorker(Convert.ToInt32(choose_id), a, b, c, d, ee, f, g, date);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newWorker.ShowDialog();
            UpdateWorker();
        }

        private void gunaButton18_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string query = $"select * from [user] join admin on [User].ID_user=admin.Id_user";
                AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                AllDataGridView.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    AllDataGridView.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
                connection = new SqlConnection(connectionString);
                connection.Open();

                string choose_id = (AllDataGridView[0, index].Value.ToString());

                string delQuery = $"DELETE FROM [admin] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                delQuery = $"DELETE FROM [admin] WHERE ID_user = {choose_id}";


                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
                UpdateWorker();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton4_Click_1(object sender, EventArgs e)
        {
            choosepanel.Hide();
        }

        private void gunaButton21_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    int index = 0;
            //    foreach (DataGridViewCell cell in AllDataGridView.SelectedCells)
            //    {
            //        index = cell.RowIndex;
            //    }
            //    string query = $"select * from [user] join admin on [User].ID_user=admin.Id_user";
            //    AllDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    AllDataGridView.AllowUserToAddRows = false;

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        adapter = new SqlDataAdapter(query, connection);

            //        dataSet = new DataSet();
            //        adapter.Fill(dataSet);
            //        AllDataGridView.DataSource = dataSet.Tables[0];
            //        connection.Close();
            //    }
            //    connection = new SqlConnection(connectionString);
            //    connection.Open();

            //    string choose_id = (AllDataGridView[0, index].Value.ToString());

            //    string delQuery = $"DELETE FROM [admin] WHERE ID_user = {choose_id}";


            //    cmd = new SqlCommand(delQuery, connection);

            //    cmd.ExecuteNonQuery();
            //    delQuery = $"DELETE FROM [admin] WHERE ID_user = {choose_id}";


            //    cmd = new SqlCommand(delQuery, connection);

            //    cmd.ExecuteNonQuery();
            //    connection.Close();
            //    UpdateWorker();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void gunaButton22_Click(object sender, EventArgs e)
        {
            choosepanel.Hide();
            ClientPanel.Hide();
            mainpanel.Show();
            openChildForm(new About());
            gunaButton20.Visible = false;
            gunaButton19.Visible = false;
            gunaButton18.Visible = false;
            gunaButton21.Visible = false;

            gunaButton8.Visible = false;
            gunaButton9.Visible = false;
            gunaButton10.Visible = false;
            gunaButton5.Visible = false;
            gunaButton6.Visible = false;
            gunaButton7.Visible = false;
        }
    }
}
