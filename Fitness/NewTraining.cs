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
    public partial class NewTraining : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int UserID;
        public NewTraining()
        {
            InitializeComponent();
        }
        int abon;
        public NewTraining(int Client,int nom)
        {
            InitializeComponent();
            abon = nom;
            UserID = Client;
        }
        
        private void Cat()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                ////Открываем подключение
                ////string selectColumns = &quot;SELECT COLUMN_NAME FROM
                string select_num = $"select Specialization from Couch group by Specialization ";
                List<string> dd = new List<string>();
                cmd = new SqlCommand(select_num, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dd.Add(reader.GetString(0));
                }
                //list - название компонента ComboBox
                gunaComboBox2.DataSource = dd;
                reader.Close();
                ////list - название компонента ComboBox
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReferenceForAdmin_Load(object sender, EventArgs e)
        {
            Cat();
            if(abon==0)
            {
                label5.Text = "АБОНЕМЕНТ РАЗОВЫЙ\n 1 ПОСЕЩЕНИЕ\n14 РУБЛЕЙ\n КРУГЛОСУТОЧНО";
            }else if (abon==1)
            {
                label5.Text = "СЕМЕЙНЫЙ БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 149 РУБЛЕЙ";
            }
            else if (abon == 2)
            {
                label5.Text = "СТУДЕНЧЕКИЙ БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 59 РУБЛЕЙ";
            }
            else if (abon == 3)
            {
                label5.Text = "БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 74 РУБЛЕЙ";
            }
            else if (abon == 4)
            {
                label5.Text = "ы";
            }
            gunaDateTimePicker1.Value = DateTime.Now;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaComboBox2_TextChanged(object sender, EventArgs e)
        {
            gunaComboBox1.Enabled = true;
            try
            {
                connection = new SqlConnection(connectionString);
                ////Открываем подключение
                connection.Open();
                ////string selectColumns = &quot;SELECT COLUMN_NAME FROM
                string select_num = $"select Surname from Couch  join [user] on [user].id_user=Couch.ID_user where Specialization=N'{gunaComboBox2.Text}' ";
                List<string> dd = new List<string>();
                cmd = new SqlCommand(select_num, connection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dd.Add(reader.GetString(0));
                }
                //list - название компонента ComboBox
                gunaComboBox1.DataSource = dd;
                reader.Close();
                ////list - название компонента ComboBox
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int CouchID=0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query1 = $"exec GetCouch N'{gunaComboBox1.Text}'";
                cmd = new SqlCommand(query1, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   CouchID = reader.GetInt32(0);
                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'1','1',1,1,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            if (abon == 0)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'2','2',2,2,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            else if (abon == 1)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'3','3',3,3,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            else if (abon == 2)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'4','4',4,4,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            else if (abon == 3)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'5','5',5,5,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            else if (abon == 4)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},'6','6',6,6,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                // добавление новой доставки

                
                cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Успешно приобретён абонемент", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
