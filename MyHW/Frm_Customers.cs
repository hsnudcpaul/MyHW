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
using SortOrder = System.Data.SqlClient.SortOrder;

namespace MyHW
{
    public partial class Frm_Customers : Form
    {
        public Frm_Customers()
        {
            InitializeComponent();

            LoadCountryToComboBox();
            listView1.View = View.Details;
            CreatListViewColums();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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

                            for (int i = 1; i < dataReader.FieldCount; i++)
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
                            lvi.ImageIndex = r.Next(0, ImageList1.Images.Count);
                            if (lvi.Index % 2 == 0)
                            {
                                lvi.BackColor = Color.DodgerBlue;
                            }
                            else
                            {
                                lvi.BackColor = Color.LightGoldenrodYellow;
                            }

                            for (int i = 1; i < dataReader.FieldCount; i++)
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

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO HW

            //1. All Country


            //================================
            //2. ContextMenuStrip2
            //選擇性作業
            //Groups
            //USA (100) 
            //UK (20)

            using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
            {

                listView1.Items.Clear();
                Random r = new Random();
                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from Customers";
                command.Connection = conn;
                //listView1.visible = false;
                conn.Open();
                SqlDataReader dataReader = command.ExecuteReader();


                listView1.Items.Clear();

                while (dataReader.Read())
                {
                    string s = $"{dataReader[0]} ";
                    ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());
                    lvi.ImageIndex = r.Next(0, ImageList1.Images.Count);

                    ListViewGroup group;
                    for (int i = 1; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                        {
                            lvi.SubItems.Add("空值");
                        }
                        else
                        {
                            lvi.SubItems.Add(dataReader[i].ToString());
                        }

                        if (lvi.Index % 2 == 0)
                        {
                            lvi.BackColor = Color.DodgerBlue;
                        }
                        else
                        {
                            lvi.BackColor = Color.LightGoldenrodYellow;
                        }

                    }

                    string country = dataReader[8].ToString();

                    if (listView1.Groups[country] == null)
                    {
                        group = listView1.Groups.Add(country, country);
                        lvi.Group = group;


                    }
                    else
                    {
                        group = listView1.Groups[country];
                        lvi.Group = group;
                    }

                    //group.Header = group.ToString() + "(" + group.Items.Count + ")";
                }
                for(int i=0; i < listView1.Groups.Count; i++)
                {
                    listView1.Groups[i].Header = $"{listView1.Groups[i].Header}({listView1.Groups[i].Items.Count})";
                }


            }

        }

        private void customerIDAscToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select * from Customers";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    treeView1.Nodes.Clear();

                    while (dataReader.Read())
                    {
                        string country = dataReader["Country"].ToString();
                        string city = dataReader["City"].ToString();
                        string customer = dataReader["CustomerID"].ToString();
                        TreeNode node;

                        if (treeView1.Nodes[country] == null)
                        {

                            TreeNode newNode = new TreeNode(country);
                            newNode.Name = country;
                            treeView1.Nodes.Add(newNode);
                            node = newNode;
                        }


                        else
                        {
                            node = treeView1.Nodes[country];
                        }
                       //node.Text = node.Name + "(" + node.Nodes.Count.ToString() + ")";

                        if (node.Nodes[city] == null)
                        {
                            TreeNode newNode = new TreeNode(city);
                            newNode.Name = city;
                            node.Nodes.Add(newNode);
                            node = newNode;

                        }
                        else
                        {
                            node = node.Nodes[city];
                        }

                        //node.Text = node.Name + "(" + (node.Nodes.Count + 1).ToString()+")";
                        if (node.Nodes[customer] == null)
                        {
                            TreeNode newnode = new TreeNode(customer);
                            newnode.Name = customer;
                            node.Nodes.Add(newnode);
                            node = newnode;
                        }
                        else
                        {
                            node = node.Nodes[customer];
                        }

                    }
                    for(int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        treeView1.Nodes[i].Text = $"{treeView1.Nodes[i].Text}({treeView1.Nodes[i].Nodes.Count})";
                        for(int a = 0; a < treeView1.Nodes[i].Nodes.Count; a++)
                        {
                            treeView1.Nodes[i].Nodes[a].Text = $"{treeView1.Nodes[i].Nodes[a].Text}({treeView1.Nodes[i].Nodes[a].Nodes.Count})";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }





        //group.Header = group.ToString() + "(" + group.Items.Count + ")";





        private void customerIDDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            listView1.Sort();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    string customerID = treeView1.SelectedNode.Text;
                    command.CommandText = $"select * from Customers where CustomerID='{customerID}'";
                    //MessageBox.Show($"{command.CommandText}");
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string s = $"{dataReader[0]} ";
                        ListViewItem lvi = listView1.Items.Add(s);
                        for (int i = 1; i < dataReader.FieldCount; i++)
                        {
 lvi.SubItems.Add(dataReader[i].ToString());
                        }
                       
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

