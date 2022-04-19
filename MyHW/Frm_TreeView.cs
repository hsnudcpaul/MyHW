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
    public partial class Frm_TreeView : Form
    {
        public Frm_TreeView()
        {
            InitializeComponent();
            listView1.View = View.Details;
            CreatListViewColums();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            LoadNodesToTreeview();
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

        private void LoadNodesToTreeview()
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
                            newNode.Tag = 1;
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
                            newNode.Tag = 2;
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
                            newnode.Tag = 3;
                            node = newnode;
                        }
                        else
                        {
                            node = node.Nodes[customer];
                        }

                    }
                    //for (int i = 0; i < treeView1.Nodes.Count; i++)
                    //{
                    //    treeView1.Nodes[i].Text = $"{treeView1.Nodes[i].Text}({treeView1.Nodes[i].Nodes.Count})";
                    //    for (int a = 0; a < treeView1.Nodes[i].Nodes.Count; a++)
                    //    {
                    //        treeView1.Nodes[i].Nodes[a].Text = $"{treeView1.Nodes[i].Nodes[a].Text}({treeView1.Nodes[i].Nodes[a].Nodes.Count})";
                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
            {
                SqlCommand command = new SqlCommand();
                if (((int)treeView1.SelectedNode.Tag) == 1)
                {

                    string country = treeView1.SelectedNode.Text;
                    command.CommandText = $"select * from Customers where Country='{country}'";
                    //MessageBox.Show($"{command.CommandText}");
                    command.Connection = conn;
                    conn.Open();
                    listView1.Items.Clear();
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
                    label1.Text = $"國家: {treeView1.SelectedNode.Text} 共 {listView1.Items.Count} 筆";
                }
                else if (((int)treeView1.SelectedNode.Tag) == 2)
                {

                    string city = treeView1.SelectedNode.Text;
                    command.CommandText = $"select * from Customers where City='{city}'";
                  
                    //MessageBox.Show($"{command.CommandText}");
                    command.Connection = conn;
                    conn.Open();
                    listView1.Items.Clear();
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
                    label1.Text = $"城市: {treeView1.SelectedNode.Text} 共 {listView1.Items.Count} 筆";
                }

                else
                {
                    string customerID = treeView1.SelectedNode.Text;
                    command.CommandText = $"select * from Customers where CustomerID='{customerID}'";
                    //MessageBox.Show($"{command.CommandText}");
                    command.Connection = conn;
                    conn.Open();
                    listView1.Items.Clear();
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
                    label1.Text = $"Customer: {treeView1.SelectedNode.Text} 共 {listView1.Items.Count} 筆";
                }
            }
        }
    }
}
                
            
