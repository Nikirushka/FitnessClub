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
    public partial class StatForAdmin : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public StatForAdmin()
        {
            InitializeComponent();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select count(*) from [User]";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   label2.Text = "Всего пользователей - "+reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Client";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label4.Text = "Клиентов - "+reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Couch";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label5.Text = "Тренеров - "+reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Admin";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label3.Text = "Администраторов - " + reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Subscription";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label6.Text = "Всего оформлено абонементов - " + reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Trainings";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label8.Text = "Всего проведено тренировок - " + reader.GetInt32(0);
                }
                reader.Close();
                query = $"select top 1 Subscription.ID_couch from Subscription group by Subscription.ID_couch order by count(Subscription.ID_couch) desc ";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                int idcouch=1;
                while (reader.Read())
                {
                    idcouch=reader.GetInt32(0);
                }
                reader.Close();
                query = $"select Specialization from Couch where Couch.ID_Couch={idcouch}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label7.Text = "Самая популярная категория - "+reader.GetString(0);
                }
                reader.Close();
                query = $"select Surname from Couch join [User] on [User].ID_user=Couch.ID_user where Couch.ID_Couch={idcouch}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label9.Text = "Самый популярный тренер - " + reader.GetString(0);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReferenceForAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
