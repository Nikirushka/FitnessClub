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
    public partial class AddRedSub : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitness-Club;Integrated Security=True";
        public AddRedSub()
        {
            InitializeComponent();
        }
        int id_employee;
        public AddRedSub(int id)
        {
            InitializeComponent();
            id_employee = id;
            k();
        }
        string idddd;
        public AddRedSub(int id,string a1, string b1, string c1, string d1, string e1, string f1,string iddd)
        {
            InitializeComponent();
            id_employee = id;
            comboBox1.Text = a1;
            comboBox2.Text = b1;
            comboBox3.Text = c1;
            textBox1.Text = d1;
            dateTimePicker1.Text = e1;
            textBox3.Text = f1;
            idddd = iddd;
        }
        private void AddRedSub_Load(object sender, EventArgs e)
        {
            
        }
        private void k()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string select_num = $"select Surname from Coaches";
                List<string> dd = new List<string>();
                cmd = new SqlCommand(select_num, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dd.Add(reader.GetString(0));
                }
                comboBox1.DataSource = dd;
                reader.Close();

                select_num = $"select Surname from Clients";
                List<string> d2 = new List<string>();
                cmd = new SqlCommand(select_num, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d2.Add(reader.GetString(0));
                }
                comboBox2.DataSource = d2;
                reader.Close();

                select_num = $"select TrainingDescription from TrainingType";
                List<string> d3 = new List<string>();
                cmd = new SqlCommand(select_num, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    d3.Add(reader.GetString(0));
                }
                comboBox3.DataSource = d3;
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_sub_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select ID_coach from Coaches where Surname=N'{comboBox1.Text}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                 query = $"select ID_client from clients where Surname=N'{comboBox2.Text}'";
                int check1 = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check1 = reader.GetInt32(0);
                }
                reader.Close();
                query = $"select ID_training_type from TrainingType where TrainingDescription=N'{comboBox3.Text}'";
                int check2 = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check2 = reader.GetInt32(0);
                }
                reader.Close();
                query = $"insert into Subscription values(N'{check}',N'{check1}','{check2}','{textBox1.Text}','','{textBox3.Text}','{dateTimePicker1.Value.ToString("yyyy-MM-dd")}','{id_employee}')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select ID_coach from Coaches where Surname=N'{comboBox1.Text}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                query = $"select ID_client from clients where Surname=N'{comboBox2.Text}'";
                int check1 = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check1 = reader.GetInt32(0);
                }
                reader.Close();
                query = $"select ID_training_type from TrainingType where TrainingDescription=N'{comboBox3.Text}'";
                int check2 = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check2 = reader.GetInt32(0);
                }
                reader.Close();
                query = $"update Subscription set ID_Coach={check}, id_client={check1}, id_training_type={check2}, cost={textBox3.Text}, date=N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', trainings=N'{textBox1.Text}' where ID_subscription={idddd}";
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

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            k();
        }
    }
}
