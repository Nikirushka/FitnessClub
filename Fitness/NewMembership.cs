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
        public NewMembership(int user,int nom)
        {
            InitializeComponent();
            abon = nom;
            UserID = user;
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
    }
}
