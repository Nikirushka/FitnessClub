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
    public partial class NewMembership : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        int UserID;
        public NewMembership()
        {
            InitializeComponent();
        }
        int abon;
        public NewMembership(int Client,int nom)
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
            if (abon == 0)
            {
                label5.Text = "АБОНЕМЕНТ РАЗОВЫЙ\n 1 ПОСЕЩЕНИЕ\n14 РУБЛЕЙ\n КРУГЛОСУТОЧНО";
            }
            else if (abon == 1)
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
                label5.Text = "3 МЕСЯЦА БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 200 РУБЛЕЙ";
            }
            else if (abon == 5)
            {
                label5.Text = "6 МЕСЯЦЕВ БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 375 РУБЛЕЙ";
            }
            else if (abon == 6)
            {
                label5.Text = "12 МЕСЯЦЕВ БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 750 РУБЛЕЙ";
            }
            else if (abon == 7)
            {
                label5.Text = "24 МЕСЯЦА БЕЗЛИМИТ\n НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ\n 1400 РУБЛЕЙ";
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
            string query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'АБОНЕМЕНТ РАЗОВЫЙ',N'1 ПОСЕЩЕНИЕ',14,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +30, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}')";
            if (abon == 0)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'АБОНЕМЕНТ РАЗОВЫЙ',N'1 ПОСЕЩЕНИЕ',14,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}','{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',GETDATE())";
            }
            else if (abon == 1)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'СЕМЕЙНЫЙ БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',149,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +30, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 2)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'СТУДЕНЧЕКИЙ БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',59,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +30, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 3)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',74,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +30, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 4)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'3 МЕСЯЦА БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',200,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +90, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 5)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'6 МЕСЯЦЕВ БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',375,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, 180, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 6)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'12 МЕСЯЦЕВ БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',750,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +365, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
            }
            else if (abon == 7)
            {
                query = $"INSERT INTO [Subscription] VALUES ({CouchID},{UserID},N'24 МЕСЯЦА БЕЗЛИМИТ',N'НЕОГРАНИЧЕННОЕ КОЛ-ВО ПОСЕЩЕНИЙ',1400,'{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}',DATEADD(DAY, +730, '{gunaDateTimePicker1.Value.ToString("yyyy-MM-dd")}'),GETDATE())";
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
