using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fitness
{

    public partial class Client : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int UserID; int ClientID;
        public Client()
        {
            InitializeComponent();
        }
        public Client(int u)
        {
            InitializeComponent();
            UserID = u;
            openChildForm(new Profile(UserID));
            MembershipDataGrid.Hide();
            panel5.Hide();
            groupBox1.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            // label2.ForeColor = Color.FromArgb(100, 88, 255);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //label2.ForeColor = Color.Black;
        }
        Point location = new Point(6, 12);
        private void Client_Load(object sender, EventArgs e)
        {
            gunaButton2.Show();
            gunaButton2.Location = close_loc;
            gunaButton1.Hide();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select [Name] from [User] where [id_user]= {UserID}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label11.Text = $"Здравствуйте, {reader.GetString(0)}!\nВыберите действие :";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select [id_client] from [client] where [id_user]= {UserID}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClientID = reader.GetInt32(0);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            mainpanel.Hide();
            buyabon.Hide();
            main_menu.Location = location;
            main_menu.Show();
            panel5.Hide();
            gunaDateTimePicker1.Value = DateTime.Now;
            gunaDateTimePicker2.Value = DateTime.Now;
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

        private void UserButton_Click(object sender, EventArgs e)
        {
            openChildForm(new Profile(UserID));
            buyabon.Hide();
            panel5.Hide();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            buyabon.Show();
            mainpanel.Hide();
            main_menu.Hide();
            panel5.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            buyabon.Hide();
            panel5.Hide();
        }

        private void gunaButton19_Click(object sender, EventArgs e)
        {
            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            openChildForm(new Profile(UserID));
            buyabon.Hide();
            main_menu.Hide();
            panel5.Hide();
            mainpanel.Location = location;
            mainpanel.Show();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {

            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            buyabon.Location = location;
            mainpanel.Hide();
            buyabon.Show();
            panel5.Hide();
            main_menu.Hide();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            UpdateMemberships();
            MembershipDataGrid.Show();
            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            panel5.Show();
            panel5.Location = location;
            mainpanel.Hide();
            buyabon.Hide();
            main_menu.Hide();
            groupBox1.Hide();
        }

        private void UpdateMemberships()
        {
            try
            {
                string query = $"exec ClientMemberships N'{ClientID}'";
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MembershipDataGrid.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateTrainings()
        {
            try
            {
                string query = $"exec ClientTrainings N'{ClientID}'";
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MembershipDataGrid.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateTrainingsDates()
        {
            try
            {
                string query = $"exec ClientTrainingsDates N'{ClientID}',N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',N'{gunaDateTimePicker2.Value.ToString("yyyy-MM-dd")}'";
                connection = new SqlConnection(connectionString);
                connection.Open();
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label15.Text = reader.GetInt32(0).ToString();              
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void gunaButton8_Click(object sender, EventArgs e)
        {
            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            openChildForm(new ReferenceForClient());
            buyabon.Hide();
            mainpanel.Location = location;
            main_menu.Hide();
            mainpanel.Show();
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            openChildForm(new About());
            buyabon.Hide();
            mainpanel.Location = location;
            main_menu.Hide();
            mainpanel.Show();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            UpdateTrainings();
            MembershipDataGrid.Show();
            gunaButton1.Show();
            gunaButton1.Location = but_loc;
            panel5.Show();
            panel5.Location = location;
            mainpanel.Hide();
            buyabon.Hide();
            main_menu.Hide();
            groupBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainpanel.Hide();
            buyabon.Hide();
            main_menu.Show();
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            mainpanel.Hide();
            buyabon.Hide();
            main_menu.Show();
            gunaButton1.Hide();
            panel5.Hide();
        }

        Point but_loc = new Point(407, 525);
        Point close_loc = new Point(986, 20);

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 0);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 1);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 2);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 3);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            UpdateTrainingsDates();
        }

        private void gunaButton25_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(4);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton3_Click_1(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(0);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton14_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(1);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton15_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(2);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton16_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(3);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton22_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(5);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton20_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(6);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton17_Click(object sender, EventArgs e)
        {
            AboutMembership AboutMembership = new AboutMembership(7);
            DialogResult dialogResult = new DialogResult();
            dialogResult = AboutMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton24_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID,4);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton23_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 5);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton21_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 6);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }

        private void gunaButton18_Click(object sender, EventArgs e)
        {
            NewMembership newMembership = new NewMembership(ClientID, 7);
            DialogResult dialogResult = new DialogResult();
            dialogResult = newMembership.ShowDialog();
            this.Show();
        }
    }
}
