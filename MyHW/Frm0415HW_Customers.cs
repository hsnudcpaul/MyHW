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
    public partial class Frm0415HW_Customers : Form
    {
        public Frm0415HW_Customers()
        {
            InitializeComponent();

        }

        private void LoadCountryToComboBox()
        {
            comboBox1.Items.Add("All Country");
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("Select distinct Country from Customers", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (dataReader.Read()) 
                    {
                        string s = $"{dataReader["Country"]} ";         
                        comboBox1.Items.Add("All Country");
                        comboBox1.Items.Add(s);


                    }

                    comboBox1.Text = "請選擇";
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreatListViewColums()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("Select * from Customers", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable table = dataReader.GetSchemaTable();
                    

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listView1.Columns.Add(table.Rows[i][0].ToString());
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    if (comboBox1.SelectedItem == "All Country")
                    {
                        command.CommandText = "select * from Customers";
                        command.Connection = conn;
                        SqlDataReader dataReader = command.ExecuteReader();

                        listView1.Items.Clear();
                        Random r = new Random();  
                        while (dataReader.Read())
                        {
                            string s = $"{dataReader[0]} ";
                            ListViewItem lvi = listView1.Items.Add(s);
                            lvi.ImageIndex = r.Next(0, ImageList1.Images.Count);
                            if (lvi.Index % 2 == 0)
                            {
                                lvi.BackColor = Color.DodgerBlue;
                            }
                            else
                            {
                                lvi.BackColor = Color.LightGoldenrodYellow;
                            }

                            for (int i = 1 ; i < dataReader.FieldCount; i++)
                            {
                                if (dataReader.IsDBNull(i))
                                {
                                    lvi.SubItems.Add("空值");
                                }
                                else
                                {
                                    lvi.SubItems.Add(dataReader[i].ToString());
                                }

                            }


                        }
                    }
                    else
                    {
                        command.CommandText = $"select * from Customers where Country ='{comboBox1.Text}'";
                        command.Connection = conn;
                        SqlDataReader dataReader = command.ExecuteReader();

                        listView1.Items.Clear();
                        Random r = new Random();  
                        while (dataReader.Read())
                        {
                            string s = $"{dataReader[0]} ";
                            ListViewItem lvi = listView1.Items.Add(s);
                            lvi.ImageIndex = r.Next(0,ImageList1.Images.Count);
                            if (lvi.Index % 2 == 0)
                            {
                                lvi.BackColor = Color.DodgerBlue;
                            }
                            else
                            {
                                lvi.BackColor = Color.LightGoldenrodYellow;
                            }

                            for (int i = 1 ; i < dataReader.FieldCount; i++)
                            {
                                if (dataReader.IsDBNull(i))
                                {
                                    lvi.SubItems.Add("空值");
                                }
                                else
                                {
                                    lvi.SubItems.Add(dataReader[i].ToString());
                                }
                            }


                        }


                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }
    }
}
