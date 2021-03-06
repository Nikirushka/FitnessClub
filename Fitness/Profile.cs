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
    public partial class Profile : Form
    {
        int s1 = 0;
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Profile()
        {
            InitializeComponent();
        }
        int UserID;
        public Profile(int uid)
        {
            InitializeComponent();
            UserID = uid;
            UpdateProfile();
            gunaLabel10.Text = "Рост";
            gunaLabel9.Text = "Вес";
            s1 = 0;
        }
        public Profile(int uid, int s)
        {
            InitializeComponent();
            UserID = uid;
            UpdateProfileCouch();
            gunaLabel10.Text = "Специализация";
            gunaLabel9.Text = "Стаж";
            s1 = s;
        }

        private void UpdateProfile()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"exec UserInfo {UserID}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gunaTextBox1.Text = reader.GetString(0);
                    gunaTextBox2.Text = reader.GetString(1);
                    gunaTextBox3.Text = reader.GetString(2);
                    gunaTextBox4.Text = reader.GetString(3);
                    gunaTextBox5.Text = reader.GetString(4);
                    gunaTextBox6.Text = reader.GetString(5);
                    gunaTextBox7.Text = reader.GetString(6);
                    gunaDateTimePicker1.Value = reader.GetDateTime(7);
                    gunaTextBox9.Text = reader.GetDouble(8).ToString();
                    gunaTextBox8.Text = reader.GetDouble(9).ToString();
                    gunaLabel11.Text = $"{ gunaTextBox1.Text} {gunaTextBox2.Text} {gunaTextBox3.Text}";
                    gunaLabel12.Text = $"Тел: {gunaTextBox4.Text}";
                    gunaLabel13.Text = $"Email: {gunaTextBox5.Text}";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProfileCouch()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"exec CouchProfileInfo {UserID}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gunaTextBox1.Text = reader.GetString(0);
                    gunaTextBox2.Text = reader.GetString(1);
                    gunaTextBox3.Text = reader.GetString(2);
                    gunaTextBox4.Text = reader.GetString(3);
                    gunaTextBox5.Text = reader.GetString(4);
                    gunaTextBox6.Text = reader.GetString(5);
                    gunaTextBox7.Text = reader.GetString(6);
                    gunaDateTimePicker1.Value = reader.GetDateTime(7);
                    gunaTextBox9.Text = reader.GetString(8);
                    gunaTextBox8.Text = reader.GetDouble(10).ToString();
                    gunaLabel11.Text = $"{ gunaTextBox1.Text} {gunaTextBox2.Text} {gunaTextBox3.Text}";
                    gunaLabel12.Text = $"Тел: {gunaTextBox4.Text}";
                    gunaLabel13.Text = $"Email: {gunaTextBox5.Text}";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {

            if (s1 == 0)
            {
                if (gunaTextBox1.Text == "" || gunaTextBox2.Text == "" || gunaTextBox3.Text == "" || gunaTextBox4.Text == "" || gunaTextBox5.Text == "" || gunaTextBox6.Text == "" || gunaTextBox7.Text == "" || gunaTextBox8.Text == "" || gunaTextBox9.Text == "" || Convert.ToInt32(gunaTextBox9.Text) > 300 || Convert.ToInt32(gunaTextBox8.Text) > 500)
                {
                    MessageBox.Show("Неправильный ввод, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        string query = $"UPDATE [User] SET Surname =N'{gunaTextBox1.Text}', Name =N'{gunaTextBox2.Text}', Patronymic =N'{gunaTextBox3.Text}', [Phone] =N'{gunaTextBox4.Text}', Email =N'{gunaTextBox5.Text}', Login =N'{gunaTextBox6.Text}', [Password]=N'{gunaTextBox7.Text}',[Date_birth]=N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}' WHERE [id_user]={UserID}";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        query = $"UPDATE [Client] SET Height =N'{gunaTextBox9.Text}', Weight =N'{gunaTextBox8.Text}' WHERE [id_user]={UserID}";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (gunaTextBox1.Text == "" || gunaTextBox2.Text == "" || gunaTextBox3.Text == "" || gunaTextBox4.Text == "" || gunaTextBox5.Text == "" || gunaTextBox6.Text == "" || gunaTextBox7.Text == "" || gunaTextBox8.Text == "" || gunaTextBox9.Text == "" || Convert.ToInt32(gunaTextBox8.Text) > 100 )
                {
                    MessageBox.Show("Неправильный ввод, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        string query = $"UPDATE [User] SET Surname =N'{gunaTextBox1.Text}', Name =N'{gunaTextBox2.Text}', Patronymic =N'{gunaTextBox3.Text}', [Phone] =N'{gunaTextBox4.Text}', Email =N'{gunaTextBox5.Text}', Login =N'{gunaTextBox6.Text}', [Password]=N'{gunaTextBox7.Text}',[Date_birth]=N'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}' WHERE [id_user]={UserID}";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        query = $"UPDATE [Couch] SET Specialization =N'{gunaTextBox9.Text}', Work_exp =N'{gunaTextBox8.Text}' WHERE [id_user]={UserID}";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    UpdateProfile();
                }
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            gunaDateTimePicker1.MaxDate = DateTime.Now;
            gunaDateTimePicker1.MinDate = new DateTime(1945, 1, 1);
        }
    }
}

