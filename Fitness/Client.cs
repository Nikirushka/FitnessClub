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

    public partial class Client : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int UserID;
        public Client()
        {
            InitializeComponent();
        }
        public Client(int u)
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

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query = $"select [Name] from [User] where id= {UserID}";
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
            main_menu.Show();
            mainpanel.Hide();
            buyabon.Hide();
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
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            buyabon.Show();
            mainpanel.Hide();
            main_menu.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            buyabon.Hide();
        }

        private void gunaButton19_Click(object sender, EventArgs e)
        {
            openChildForm(new Profile(UserID));
            buyabon.Hide();
            main_menu.Hide();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            buyabon.Show();
            mainpanel.Hide();
            main_menu.Hide();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            openChildForm(new Profile(UserID));
            buyabon.Hide();
            main_menu.Hide();
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            openChildForm(new Profile(UserID));
            buyabon.Hide();
            main_menu.Hide();
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            openChildForm(new About);
            buyabon.Hide();
            main_menu.Hide();
        }

        private void main_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
