
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Frm標準練習 : Form
    {
        public Frm標準練習()
        {
            InitializeComponent();
        }

        int max = 0, min = 0;

        int x, y, z;
        public ref int Maxscore(int[] score)
        {
            max = score.Max();
            return ref max;
        }
        public ref int Minscore(int[] score)
        {
            min = score.Min();
            return ref min;
        }
        public void isnum()
        {

            bool xisnum = int.TryParse(textBox1.Text, out x);
            bool yisnum = int.TryParse(textBox2.Text, out y);
            bool zisnum = int.TryParse(textBox3.Text, out z);
            if (xisnum && yisnum && zisnum)
            {

            }
            else
            {
                MessageBox.Show("請輸入整數數值");
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            string[] names = { "aaa", "ksdkfjsdk" };
            int max = 0;
            string b = "";
            for (int a = 0; a < names.Length; a++)
            {
                if (names[a].Length > max)
                {
                    max = names[a].Length;
                    b = names[a];
                }
                lblResult.Text =string.Join(",",names)+ "中\n名字最長的為: " + b;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 };

            lblResult.Text =string.Join(",",scores) + "\n最大數為: " + Maxscore(scores).ToString() + "\n最小數為: " + Minscore(scores).ToString();

            //int max =  scores.Max();
            //MessageBox.Show("Max = " + max);

            //Array.Sort(scores);
            //MessageBox.Show("Max =" + scores[scores.Length - 1]);

            //================================

            //Point[] points = new Point[3];
            //points[0].X = 3;
            //points[0].Y = 4;
            ////System.InvalidOperationException: '無法比較陣列中的兩個元素。'

            //Array.Sort(points);

            //=================================


        }

        int MyMinScore(int[] nums)
        {
            return 10;
        }

        private void btnOddandEven_Click(object sender, EventArgs e)
        {

            int sum;

            bool isnum = int.TryParse(txtInput.Text, out sum);
            if (isnum)
            {
                if (sum % 2 == 0)
                {
                    lblResult.Text = sum + " 是偶數";
                }
                else
                {
                    lblResult.Text = sum + " 是奇數";
                }
            }

            else
            {
                MessageBox.Show("請輸入正確數值");
                txtInput.Clear();
                txtInput.Focus();
            }

        }

        private void btnMix_Click(object sender, EventArgs e)
        {
            int a = 44, b = 100, c = 88;
            if (a > b && a > c)
            {
                lblResult.Text = "a = 44, b = 100, c = 88  , a; " + a + " 是最大的";
            }
            else if (b > a && b > c)
            {
                lblResult.Text = "a = 44, b = 100, c = 88  , b: " + b + " 是最大的";
            }
            else
            {
                lblResult.Text = "a = 44, b = 100, c = 88  , c: " + c + " 是最大的";
            }
        }

        private void btnNinetyNine_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            for (int i = 1; i < 10; i++) 
            {
                lblResult.Text += "\n";
                for (int j = 1; j < 10; j++)
                {
                    if (i * j < 10)
                    {
                        lblResult.Text += j + "*" + i + "=" + " " + i * j + " ";
                    }
                    else
                    {
                        lblResult.Text += j + "*" + i + "=" + i * j + " ";
                    }

                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblResult.Text = "結果";
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            lblResult.Text = Convert.ToString(100, 2);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            int[] nums = { 33, 4, 5, 11, 222, 34 };
            int y = 0, n = 0;
            foreach (int a in nums)
            {
                if (a % 2 == 0)
                {
                    y++;
                }
                else
                {
                    n++;
                }
            }
            lblResult.Text = string.Join(",",nums) + "\n偶數有:  " + y + "個" + "\n奇數有: " + n + "個"; ;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            String[] names = { "aaa", "bbb", "ccc", " Mary", "Tom", "zzzzzzzzzz", "cat", "select", "oreo", "CHARLEs" };
            int count = 0;
            for (int a = 0; a < names.Length; a++)
            {
                if (names[a].Contains("c") || names[a].Contains("C"))
                {
                    count++;
                }
                lblResult.Text =string.Join(",",names) + "\n名字裡含有C或c的共有" + count.ToString() + "個";
            }
        }

        private void btnWhile_Click(object sender, EventArgs e)
        {
            isnum();
            int w = x;
            int sum = w;
            while (w+z <= y)
            {
                w = w + z;
  
                    sum = sum + w;
            }
            lblResult.Text = x.ToString() + " 到 " + y.ToString() + " 相隔 " + (z - 1).ToString() + "\n加總為: " + sum.ToString();

        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            isnum();
            int i = x;
            int sum = 0;
            do
            {
                sum = sum + i;
                i += z;
            } while (i  <= y);
            lblResult.Text = x.ToString() + " 到 " + y.ToString() + " 相隔 " + (z - 1).ToString() + "\n加總為: " + sum.ToString();

        }

        private void button19_Click(object sender, EventArgs e)
        {
           lblResult.Text = string.Join(" ", getRandom().OrderBy(x=>x));
            
        }

        public List<int> getRandom()
        {
            List<int> randomList = new List<int>();

            Random rnd = new Random();
            while (randomList.Count < 6)
            {
                int r = rnd.Next(1, 49);

                while (randomList.Contains(r))
                    r = rnd.Next(1, 49);

                randomList.Add(r);

            }
            return randomList;
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            isnum();
            int sum = 0;
            for (int i = x; i < (y + 1); i += z)
            {

                sum = sum + i;

            }
            lblResult.Text = x.ToString() + " 到 " + y.ToString() + " 相隔 " + (z - 1).ToString() + "\n加總為: " + sum.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] nums = { 44, 66, 99, 100, 78, 99, 87, 55, 48, 32, 98 };
            lblResult.Text = string.Join(",", nums) + $"\n最大值為:{nums.Max()}";
        }
    }
}
