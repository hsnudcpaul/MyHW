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

namespace MyHW
{
    public partial class Frm0411HW : Form
    {
        public Frm0411HW()
        {
            InitializeComponent();
       
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Categories ", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add($"{reader["CategoryName"]}");
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"{"ProductID",-15}{ "ProductName",-40}{"CategoryID",-15}{"CategoryName",-30}");
            string s = (comboBox1.SelectedIndex + 1).ToString();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Products as p join Categories as g on p.CategoryID=g.CategoryID where p.CategoryID=" + s, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string r = $"{reader["ProductID"],-15}{reader["ProductName"],-40}  {reader["CategoryID"],-15}{reader["CategoryName"],-30}";         /*正數為靠右對齊負數為靠左*/
                listBox1.Items.Add(r);
            }
            conn.Close();
        }
    }
}
