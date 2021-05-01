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
    public partial class NewClient : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitness-Club;Integrated Security=True";
        public NewClient()
        {
            InitializeComponent();
            gunaButton1.Hide();
            gunaButton5.Show();
            gunaLabel1.Text = "Добавление клиента";

        }
        int UserID;
        public NewClient(int UserID_,string sur, string name,string patr, string phone, string email, string login, string pass, DateTime birth, int rost, int ves)
        {
            InitializeComponent();
            gunaButton1.Show();
            gunaButton5.Hide();
            gunaTextBox2.Text = sur;
            gunaTextBox1.Text = name;
            gunaTextBox3.Text = patr;
            gunaTextBox4.Text = phone;
            gunaTextBox5.Text = email;
            gunaTextBox6.Text = login;
            gunaTextBox7.Text = pass;
            gunaTextBox8.Text = rost.ToString();
            gunaTextBox9.Text = ves.ToString();

            gunaDateTimePicker1.Value = birth;
            UserID = UserID_;
            gunaLabel1.Text = "Изменение клиента";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NewClient_Load(object sender, EventArgs e)
        {

        }

        private void gunaTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void gunaButton5_Click(object sender, EventArgs e)
        {
            if (IsDigitsOnly(gunaTextBox8.Text) && IsDigitsOnly(gunaTextBox9.Text))
            {
                try
                {

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query = $"insert into [User] values(N'{gunaTextBox2.Text}',N'{gunaTextBox1.Text}',N'{gunaTextBox3.Text}',N'{gunaTextBox4.Text}',N'{gunaTextBox5.Text}',N'{gunaTextBox6.Text}',N'{gunaTextBox7.Text}',N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    query = $"exec GetID N'{gunaTextBox6.Text}',N'{gunaTextBox7.Text}'";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    int UserID = 0;
                    while (reader.Read())
                    {
                        UserID = reader.GetInt32(0);
                    }
                    reader.Close();
                    query = $"insert into [Client] values({UserID},N'{gunaTextBox8.Text}',N'{gunaTextBox9.Text}')";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Новый пользователь добавлен!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"update [User] set Surname=N'{gunaTextBox2.Text}', Name=N'{gunaTextBox1.Text}', Patronymic=N'{gunaTextBox3.Text}', Phone=N'{gunaTextBox4.Text}', Date_birth=N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}', Email=N'{gunaTextBox5.Text}',Login=N'{gunaTextBox6.Text}',Password=N'{gunaTextBox7.Text}' where ID_user={UserID}";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                query = $"update [Client] set Height=N'{gunaTextBox8.Text}', Weight=N'{gunaTextBox9.Text}' where ID_user={UserID}";
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
    }
}
