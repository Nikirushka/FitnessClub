using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public NewClient()
        {
            InitializeComponent();
            gunaButton1.Hide();
            gunaButton5.Show();
            gunaLabel1.Text = "Добавление клиента";

        }
        int UserID;
        public NewClient(int UserID_, string sur, string name, string patr, string phone, string email, string login, string pass, DateTime birth, int rost, int ves)
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
            gunaDateTimePicker1.MaxDate = DateTime.Today;

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
            if (gunaTextBox1.Text == "" || gunaTextBox2.Text == "" || gunaTextBox3.Text == "" || gunaTextBox4.Text == "" || gunaTextBox5.Text == "" || gunaTextBox6.Text == "" || gunaTextBox7.Text == "" || gunaTextBox8.Text == "" || gunaTextBox9.Text == "")
            {
                MessageBox.Show("Неправильный ввод, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
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

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (gunaTextBox1.Text == "" || gunaTextBox2.Text == "" || gunaTextBox3.Text == "" || gunaTextBox4.Text == "" || gunaTextBox5.Text == "" || gunaTextBox6.Text == "" || gunaTextBox7.Text == "" || gunaTextBox8.Text == "" || gunaTextBox9.Text == "")
            {
                MessageBox.Show("Неправильный ввод, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
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

        private void gunaTextBox2_Enter(object sender, EventArgs e)
        {
            gunaTextBox2.Text = "";
        }

        private void gunaTextBox1_Enter(object sender, EventArgs e)
        {
            gunaTextBox1.Text = "";
        }

        private void gunaTextBox3_Enter(object sender, EventArgs e)
        {
            gunaTextBox3.Text = "";
        }

        private void gunaTextBox4_Enter(object sender, EventArgs e)
        {
            gunaTextBox4.Text = "";
        }

        private void gunaTextBox5_Enter(object sender, EventArgs e)
        {
            gunaTextBox5.Text = "";
        }

        private void gunaTextBox6_Enter(object sender, EventArgs e)
        {
            gunaTextBox6.Text = "";
        }

        private void gunaTextBox7_Enter(object sender, EventArgs e)
        {
            gunaTextBox7.Text = "";
        }

        private void gunaTextBox8_Enter(object sender, EventArgs e)
        {
            gunaTextBox8.Text = "";
        }

        private void gunaTextBox9_Enter(object sender, EventArgs e)
        {
            gunaTextBox9.Text = "";
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox9_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void gunaTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if ((Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success) || e.KeyChar == 32 || e.KeyChar == 8 )
            {
                return;
            }
            else e.Handled = true;
        }

        private void gunaTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if ((Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                return;
            }
            else e.Handled = true;
        }

        private void gunaTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if ((Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                return;
            }
            else e.Handled = true;
        }

        private void gunaTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 32 || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void gunaTextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 32 || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void gunaTextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 32 || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }
    }
}
