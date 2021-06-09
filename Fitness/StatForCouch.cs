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
    public partial class StatForCouch : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public StatForCouch(int iduser)
        {
            InitializeComponent();
            try
            {
                int couchid=0;
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = $"select ID_couch from Couch where ID_User={iduser}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   couchid =reader.GetInt32(0);
                }
                reader.Close();
                connection = new SqlConnection(connectionString);
                connection.Open();
                 query = $"select count(*) from Subscription join Couch on Couch.ID_Couch=Subscription.ID_couch where Couch.ID_user={iduser}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   label2.Text = "Клиентов у вас - " + reader.GetInt32(0);
                }
                reader.Close();
                query = $"select count(*) from Client";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label4.Text = "Всего тренировок -  " + reader.GetInt32(0);
                }
                reader.Close();
                query = $"select Specialization from Couch where Couch.ID_Couch={couchid}";
                cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label5.Text = "Ваша категория - " + reader.GetString(0);
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
