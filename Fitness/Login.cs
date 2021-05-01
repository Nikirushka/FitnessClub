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
    public partial class Вход : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|FitnessClub.mdf';Integrated Security=True";
        public Вход()
        {
            InitializeComponent();
        }

        private void Вход_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginTB, PasswordTB;
                LoginTB = LoginTextBox.Text;
                PasswordTB = PasswordTextBox.Text;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"SELECT ID_user FROM [User] WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS)";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Неправильный логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    reader.Close();
                    return;
                }
                else
                {
                    reader.Close();
                    query = $"SELECT * FROM [User] WHERE (Login=N'{LoginTB}'COLLATE CYRILLIC_General_CS_AS) AND (Password= N'{PasswordTB}' COLLATE CYRILLIC_General_CS_AS) ";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        int UserID = 0;
                        reader.Close();
                        query = $"exec GetID N'{LoginTB}',N'{PasswordTB}'";
                        cmd = new SqlCommand(query, connection);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            UserID = reader.GetInt32(0);
                        }
                        reader.Close();
                        query = $"SELECT * FROM [Admin] WHERE [ID_user]='{UserID}'";
                        cmd = new SqlCommand(query, connection);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Close();
                            this.Hide();
                            Admin admin = new Admin(UserID);
                            DialogResult dialogResult = new DialogResult();
                            dialogResult = admin.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            reader.Close();
                            query = $"SELECT * FROM [Client] WHERE [ID_user]='{UserID}'";
                            cmd = new SqlCommand(query, connection);
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                reader.Close();
                                this.Hide();
                                Client client = new Client(UserID);
                                DialogResult dialogResult = new DialogResult();
                                dialogResult = client.ShowDialog();
                                this.Show();
                            }
                            else
                            {

                            }
                        }  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void LoginTextBox_Click(object sender, EventArgs e)
        {
            LoginTextBox.Text = "";
        }

        private void PasswordTextBox_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Text = "";
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewClient newClient = new NewClient();
            DialogResult dialogResult = new DialogResult();
            dialogResult = newClient.ShowDialog();
            this.Show();
        }
    }
}