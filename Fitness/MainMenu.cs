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
    public partial class MainMenu : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fitness-Club;Integrated Security=True";
        public MainMenu()
        {
            InitializeComponent();
        }
        int employee_id;

        public MainMenu(int id)
        {
            InitializeComponent();
            employee_id = id;
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

        private void MainMenu_Load(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            k();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            connect_staff();
            add_red_train.Hide();
            add_red_coach.Hide();
            add_red_sotr.Hide();
            add_red_client.Hide();
            add_sotr.Show();
            red_sotr.Show();
            del_sotr.Show();
            add_client.Hide();
            red_client.Hide();
            del_client.Hide();
            add_train.Hide();
            red_train.Hide();
            del_train.Hide();
            add_coach.Hide();
            red_coach.Hide();
            del_coach.Hide();
            add_sub.Hide();
            red_sub.Hide();
            del_sub.Hide();
        }
        public void connect_clients()
        {
            try
            {
                string query = $"select * from Info_Clients";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void connect_coaches()
        {
            try
            {
                string query = $"select * from Info_Coaches";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void connect_trainings()
        {
            try
            {
                string query = $"select * from Info_Trainings";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void connect_subs()
        {
            try
            {
                string query = $"select * from Info_Subs";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void connect_staff()
        {
            try
            {
                string query = $"select Staff.Name,Staff.Surname,Staff.Patronymic,Staff.Login,Staff.Password from staff";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    connection.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            connect_clients();
            add_sotr.Hide();
            red_sotr.Hide();
            del_sotr.Hide();
            add_coach.Hide();
            red_coach.Hide();
            del_coach.Hide();
            add_client.Show();
            red_client.Show();
            del_client.Show();
            add_train.Hide();
            red_train.Hide();
            del_train.Hide();
            add_sub.Hide();
            red_sub.Hide();
            del_sub.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            connect_coaches();
            add_sotr.Hide();
            red_sotr.Hide();
            del_sotr.Hide();
            add_client.Hide();
            red_client.Hide();
            del_client.Hide();
            add_coach.Show();
            red_coach.Show();
            del_coach.Show();
            add_train.Hide();
            red_train.Hide();
            del_train.Hide();
            add_sub.Hide();
            red_sub.Hide();
            del_sub.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label17.Show();
            label18.Show();
            label19.Show();
            connect_subs();
            add_sotr.Hide();
            red_sotr.Hide();
            del_sotr.Hide();
            add_client.Hide();
            red_client.Hide();
            del_client.Hide();
            add_coach.Hide();
            red_coach.Hide();
            del_coach.Hide();
            add_train.Hide();
            red_train.Hide();
            del_train.Hide();
            add_sub.Show();
            red_sub.Show();
            del_sub.Show();
            comboBox1.Show();
            comboBox2.Show();
            comboBox3.Show();
            button18.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            connect_trainings();
            add_sotr.Hide();
            red_sotr.Hide();
            del_sotr.Hide();
            add_client.Hide();
            red_client.Hide();
            del_client.Hide();
            add_coach.Hide();
            red_coach.Hide();
            del_coach.Hide();
            add_train.Show();
            red_train.Show();
            del_train.Show();
            add_sub.Hide();
            red_sub.Hide();
            del_sub.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button22.Hide();
            button21.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            button18.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            connect_staff();
            add_sotr.Show();
            red_sotr.Show();
            del_sotr.Show();
            add_client.Hide();
            red_client.Hide();
            del_client.Hide();
            add_coach.Hide();
            red_coach.Hide();
            del_coach.Hide();
            add_train.Hide();
            red_train.Hide();
            del_train.Hide();
            add_sub.Hide();
            red_sub.Hide();
            del_sub.Hide();
        }

        private void add_sotr_Click(object sender, EventArgs e)
        {
            add_red_sotr.Show();
            button5.Show();
            button7.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"insert into staff values(N'{textBox1.Text}',N'{textBox2.Text}',N'{textBox3.Text}',N'{textBox4.Text}',N'{textBox5.Text}')";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_sotr.Hide();
            connect_staff();
        }
        string choose_login;

        private void red_sotr_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            choose_login = (dataGridView1[3, index].Value.ToString());
            string text = $"select Staff.Name,Staff.Surname,Staff.Patronymic,Staff.Login,Staff.Password from staff where login=N'{choose_login}'";
            cmd = new SqlCommand(text, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetString(0).Trim();
                textBox2.Text = reader.GetString(1).Trim();
                textBox3.Text = reader.GetString(2).Trim();
                textBox4.Text = reader.GetString(3).Trim();
                textBox5.Text = reader.GetString(4).Trim();
            }
            reader.Close();
            connection.Close();
            add_red_sotr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string a;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"update staff set Name=N'{textBox1.Text}',Surname=N'{textBox2.Text}',Patronymic=N'{textBox3.Text}',Login=N'{textBox4.Text}',Password=N'{textBox5.Text}' where Login=N'{choose_login}'";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_sotr.Hide();
            connect_staff();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            add_red_sotr.Hide();
        }

        private void del_sotr_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                choose_login = (dataGridView1[3, index].Value.ToString());

                string delQuery = $"DELETE FROM staff WHERE login = N'{choose_login}'";

                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect_staff();
        }

        private void add_client_Click(object sender, EventArgs e)
        {
            add_red_client.Show();
            button11.Show();
            button9.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add_red_client.Hide();
        }

        private void red_client_Click(object sender, EventArgs e)
        {
            
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string choose_name = (dataGridView1[0, index].Value.ToString());
            string choose_surname = (dataGridView1[1, index].Value.ToString());
            string choose_patr = (dataGridView1[2, index].Value.ToString());
            string text = $"select * from Info_Clients where CName=N'{choose_name}' and Surname=N'{choose_surname}' and Patronymic=N'{choose_patr}'";
            cmd = new SqlCommand(text, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox10.Text = reader.GetString(0).Trim();
                textBox9.Text = reader.GetString(1).Trim();
                textBox8.Text = reader.GetString(2).Trim();
                textBox7.Text = reader.GetString(3).Trim();
                dateTimePicker1.Value = reader.GetDateTime(4);
            }
            reader.Close();
            connection.Close();
            button9.Show();
            button11.Hide();
            add_red_client.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetClientID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                query = $"update clients set Name=N'{textBox10.Text}',Surname=N'{textBox9.Text}',Patronymic=N'{textBox8.Text}',Phone=N'{textBox7.Text}',DateOfBirth=N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}' where ID_client={check}";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_sotr.Hide();
            connect_clients();
            add_red_client.Hide();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"insert into clients values(N'{textBox10.Text}',N'{textBox9.Text}',N'{textBox8.Text}',N'{textBox7.Text}',N'{dateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE(),{employee_id})";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_client.Hide();
            connect_clients();
        }

        private void del_client_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetClientID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                string delQuery = $"DELETE FROM clients WHERE ID_client = {check}";

                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect_clients();
            add_red_client.Hide();
        }

        private void add_coach_Click(object sender, EventArgs e)
        {
            add_red_coach.Show();
            button14.Show();
            button12.Hide();
        }

        private void red_coach_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string choose_name = (dataGridView1[0, index].Value.ToString());
            string choose_surname = (dataGridView1[1, index].Value.ToString());
            string choose_patr = (dataGridView1[2, index].Value.ToString());
            string text = $"select * from Info_Coaches where CName=N'{choose_name}' and Surname=N'{choose_surname}' and Patronymic=N'{choose_patr}'";
            cmd = new SqlCommand(text, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox14.Text = reader.GetString(0).Trim();
                textBox13.Text = reader.GetString(1).Trim();
                textBox12.Text = reader.GetString(2).Trim();
                textBox11.Text = reader.GetString(3).Trim();
                textBox6.Text = reader.GetString(4).Trim();
                textBox15.Text = reader.GetDouble(5).ToString();
            }
            reader.Close();
            connection.Close();
            add_red_coach.Show();
            button12.Show();
            button14.Hide();
        }

        private void del_coach_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetCoachID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                string delQuery = $"DELETE FROM coaches WHERE ID_coach = {check}";

                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect_coaches();
            add_red_coach.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"insert into coaches values(N'{textBox14.Text}',N'{textBox13.Text}',N'{textBox12.Text}',N'{textBox11.Text}',N'{textBox6.Text}',N'{textBox15.Text}',{employee_id})";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_coach.Hide();
            connect_coaches();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetCoachID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                query = $"update coaches set Name=N'{textBox14.Text}',Surname=N'{textBox13.Text}',Patronymic=N'{textBox12.Text}',Phone=N'{textBox11.Text}',Email=N'{textBox6.Text}',WorkExperience={textBox15.Text} where ID_coach={check}";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_coach.Hide();
            connect_coaches();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            add_red_coach.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            add_red_train.Hide();
        }

        private void add_train_Click(object sender, EventArgs e)
        {
            button17.Show();
            button15.Hide();
            add_red_train.Show();
            connect_trainings();
        }

        private void red_train_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            textBox21.Text = (dataGridView1[0, index].Value.ToString());
            textBox20.Text = (dataGridView1[1, index].Value.ToString());
            textBox16.Text = (dataGridView1[2, index].Value.ToString());
            
            button15.Show();
            button17.Hide();
            add_red_train.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetTrainingID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                query = $"update TrainingType  set TrainingDescription=N'{textBox21.Text}',NumberOfExercises=N'{textBox20.Text}',TrainingTime=N'{textBox16.Text}' where ID_training_type={check}";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_train.Hide();
            connect_trainings();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"insert into TrainingType values(N'{textBox21.Text}',N'{textBox20.Text}','{textBox16.Text}',{employee_id})";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_train.Hide();
            connect_trainings();

        }

        private void del_train_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string choose_name = (dataGridView1[0, index].Value.ToString());
                string choose_surname = (dataGridView1[1, index].Value.ToString());
                string choose_patr = (dataGridView1[2, index].Value.ToString());
                string query = $"exec GetTrainingID N'{choose_name}',N'{choose_surname}',N'{choose_patr}'";
                int check = 0;
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                reader.Close();
                string delQuery = $"DELETE FROM TrainingType WHERE ID_training_type = {check}";

                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            add_red_train.Hide();
            connect_trainings();
        }

        private void del_sub_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    index = cell.RowIndex;
                }
                string query = $"select * from Subscription";
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        adapter = new SqlDataAdapter(query, connection);

                        dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dataGridView1.DataSource = dataSet.Tables[0];
                        connection.Close();
                    }
                connection = new SqlConnection(connectionString);
                connection.Open();
                
                string choose_id = (dataGridView1[0, index].Value.ToString());
 
                string delQuery = $"DELETE FROM Subscription WHERE ID_subscription = {choose_id}";

                cmd = new SqlCommand(delQuery, connection);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connect_subs();
        }

        private void add_sub_Click(object sender, EventArgs e)
        {
            AddRedSub addRedSub = new AddRedSub(employee_id);
            addRedSub.Show();
            connect_subs();
        }

        private void red_sub_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            int index = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index = cell.RowIndex;
            }
            string a = (dataGridView1[6, index].Value.ToString());
            string b = (dataGridView1[1, index].Value.ToString());
            string c = (dataGridView1[2, index].Value.ToString());
            string d = (dataGridView1[4, index].Value.ToString());
            string ee = (dataGridView1[10, index].Value.ToString());
            string f = (dataGridView1[7, index].Value.ToString());
            int index1 = 0;
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                index1 = cell.RowIndex;
            }
            string query = $"select * from Subscription";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);

                dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            connection = new SqlConnection(connectionString);
            connection.Open();

            string choose_id = (dataGridView1[0, index1].Value.ToString());
            AddRedSub addRedSub = new AddRedSub(employee_id,a,b,c,d,ee,f,choose_id);
            addRedSub.Show();
            connect_subs();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = $"select * from Info_Subs where Coach_Surname=N'{comboBox1.Text}' and Client_Surname=N'{comboBox2.Text}' and TrainingDescription=N'{comboBox3.Text}'";
               dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(query, connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            label18.Show();
            comboBox2.Show();
            button22.Hide();
            button21.Show();
            dateTimePicker2.Show();
            dateTimePicker3.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label19.Show();
            comboBox1.Show();
            button21.Hide();
            button22.Show();
            dateTimePicker2.Show();
            dateTimePicker3.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"select count(Trainings) from Subscription join Coaches on Coaches.ID_coach=Subscription.ID_coach join Clients on Clients.ID_client = Subscription.ID_client where Subscription.Date between '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}' and '{dateTimePicker3.Value.ToString("yyyy-MM-dd")}' and Clients.Surname = N'{comboBox2.Text}'";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            int check=0;
                while (reader.Read())
                {
                    check=reader.GetInt32(0);
                }
            reader.Close();
                if(check==0) label23.Text = "Кол-во : 0";
                else
            {
                query = $"select sum(Trainings) from Subscription join Coaches on Coaches.ID_coach=Subscription.ID_coach join Clients on Clients.ID_client = Subscription.ID_client where Subscription.Date between '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}' and '{dateTimePicker3.Value.ToString("yyyy-MM-dd")}' and Clients.Surname = N'{comboBox2.Text}'";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                label23.Text = "Кол-во : "+check;
            }


            reader.Close();
            connection.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"select count(Trainings) from Subscription join Coaches on Coaches.ID_coach=Subscription.ID_coach join Clients on Clients.ID_client = Subscription.ID_client where Subscription.Date between '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}' and '{dateTimePicker3.Value.ToString("yyyy-MM-dd")}' and Coaches.Surname = N'{comboBox1.Text}'";
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            int check = 0;
            while (reader.Read())
            {
                check = reader.GetInt32(0);
            }
            reader.Close();
            if (check == 0) label23.Text = "Кол-во : 0";
            else
            {
                query = $"select sum(Trainings) from Subscription join Coaches on Coaches.ID_coach=Subscription.ID_coach join Clients on Clients.ID_client = Subscription.ID_client where Subscription.Date between '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}' and '{dateTimePicker3.Value.ToString("yyyy-MM-dd")}' and Coaches.Surname = N'{comboBox1.Text}'";
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.GetInt32(0);
                }
                label23.Text = "Кол-во : " + check;
            }
                reader.Close();
            connection.Close();
        }
    }
}
