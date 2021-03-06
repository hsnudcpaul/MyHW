using MyHW.Properties;
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
    public partial class Frm_LogOn : Form
    {
        public Frm_LogOn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = $"InsertMember";
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 40).Value = password;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "RETURN_VALUE";
                    p1.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(p1);
                    conn.Open();
                    //command.Parameters.Add(p2);conn.Open();
                    command.ExecuteNonQuery(); //Insert用ExecuteNonQuery()
                    MessageBox.Show("Insert New Member Successfully " + p1.Value);


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Enter();
        }

        private void Frm0415HW_LogOn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Alt==true)
            {
               Canale();
            }
            if (e.KeyCode == Keys.O && e.Alt==true)
            {
                 Enter();
            }
            if (e.KeyCode == Keys.U && e.Alt==true)
            {
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.P && e.Alt==true)
            {
                textBox2.Focus();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Canale();
        }

        private void Frm0415HW_LogOn_Load(object sender, EventArgs e)
        {

        }
        void Enter()
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))

                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select *from MyMember where UserName=@username and Password=@password";
                    command.Connection = conn;
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 16).Value = username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 40).Value = password;

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("登入成功");
                        Frm_Customers frmCu = new Frm_Customers();
                        frmCu.Show();

                    }

                    else
                    {
                        MessageBox.Show("登入失敗");
                    }

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Canale()
        {
            this.Close();
        }
    }
}
