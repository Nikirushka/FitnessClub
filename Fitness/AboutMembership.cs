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
    public partial class AboutMembership : Form
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd;
        DataSet dataSet;
        SqlDataAdapter adapter;

        string connectionString = @"Server=tcp:fitnessclub.database.windows.net,1433;Initial Catalog=fitnessclub;Persist Security Info=False;User ID=Vlad;Password=Chernick123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int abon;
        public AboutMembership(int membership)
        {
            InitializeComponent();
            abon = membership;
            
        }

        private void ReferenceForAdmin_Load(object sender, EventArgs e)
        {
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
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
