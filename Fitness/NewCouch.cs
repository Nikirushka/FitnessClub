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
    public partial class NewCouch : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitness-Club;Integrated Security=True";
        public NewCouch()
        {
            InitializeComponent();
            gunaButton1.Hide();
            gunaButton5.Show();
            gunaLabel1.Text = "Добавление тренера";

        }
        int UserID;
        public NewCouch(int UserID_,string sur, string name,string patr, string phone, string email, string login, string pass, DateTime birth, string rost, int ves,int ll)
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
            gunaTextBox8.Text = rost;
            gunaTextBox10.Text = ves.ToString();
            gunaTextBox9.Text= ll.ToString();

            gunaDateTimePicker1.Value = birth;
            UserID = UserID_;
            gunaLabel1.Text = "Изменение тренера";
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
            if (IsDigitsOnly(gunaTextBox10.Text) && IsDigitsOnly(gunaTextBox9.Text))
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
                    query = $"insert into [Couch] values({UserID},N'{gunaTextBox8.Text}',N'{gunaTextBox9.Text}',N'{gunaTextBox9.Text}')";
                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                query = $"update [Couch] set Specialization=N'{gunaTextBox8.Text}', Salary=N'{gunaTextBox9.Text}', Work_exp=N'{gunaTextBox10.Text}' where ID_user={UserID}";
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
