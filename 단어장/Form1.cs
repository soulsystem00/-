using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace 단어장
{
    public partial class Form1 : Form
    {
        string answer;

        List<int> list;
        public Form1()
        {
            InitializeComponent();
            txt_result.Text = "input answer";
            list = new List<int> { 0 };
            setlistview();
            randomtxt();
            txt_wordcnt.Text = list_words.Items.Count.ToString();
            txt_word.Text = list_words.Items[list[0]].Text;
            answer = list_words.Items[list[0]].SubItems[1].Text;
            list.RemoveAt(0);
        }

        public void setlistview()
        {
            StreamReader streamReader = new StreamReader("word.txt");
            while(streamReader.Peek() >=0)
            {
                string str = streamReader.ReadLine();
                string[] str1 = str.Split(' ');
                ListViewItem listViewItem = new ListViewItem(str1);
                list_words.Items.Add(listViewItem);
                this.Width = 850;
                btn_redution.Visible = true;
                btn_extention.Visible = false;
            }
            streamReader.Close();

        }
        public void randomtxt()
        {
            Random random = new Random();

            int num2 = list_words.Items.Count;
            bool check = true;
            
            while(list.Count != num2)
            {
                int num = random.Next(0, num2);
                for(int i =0;i<list.Count;i++)
                {
                    if (list[i] == num)
                    {
                        check = false;
                        break;
                    }
                    else
                        check = true;
                }
                if(check)
                {
                    list.Add(num);
                }
            }
            /*string str = list_words.Items[num].Text;

            txt_word.Text = str;

            answer = list_words.Items[num].SubItems[1].Text;*/
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(answer == txt_mean.Text)
            {
                txt_result.Text = "correct";
                
                txt_cornum.Text = (Convert.ToInt32(txt_cornum.Text) + 1).ToString();
            }
            else
            {
                txt_result.Text = "wrong";
                txt_incornum.Text = (Convert.ToInt32(txt_incornum.Text) + 1).ToString();
                string[] str = new string[] { txt_word.Text, answer };
                ListViewItem listViewItem = new ListViewItem(str);
                list_Wword.Items.Add(listViewItem);
            }
            txt_mean.Text = "";
            if (list.Count > 0)
            {
                txt_word.Text = list_words.Items[list[0]].Text;
                answer = list_words.Items[list[0]].SubItems[1].Text;
                list.RemoveAt(0);
            }
            else
            {
                txt_word.Text = "Clear";
                answer = "Clear";
            }
        }

        private void txt_mean_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btn_submit_Click(sender, e);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { txt_Sword.Text, txt_Smean.Text },-1);
            list_words.Items.Add(listViewItem);
            txt_Smean.Text = "";
            txt_Sword.Text = "";
            txt_Sword.Focus();
            txt_wordcnt.Text = list_words.Items.Count.ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("word.txt");

            for (int i = 0; i < list_words.Items.Count; i++)
            {
                string str = list_words.Items[i].Text + " " + list_words.Items[i].SubItems[1].Text;

                streamWriter.WriteLine(str);
            }

            streamWriter.Close();
        }

        private void btn_listdel_Click(object sender, EventArgs e)
        {
            list_words.SelectedItems[0].Remove();
            txt_wordcnt.Text = list_words.Items.Count.ToString();
        }

        private void btn_extention_Click(object sender, EventArgs e)
        {
            for(int i =400;i<=850;i+=5)
            {
                this.Width = i;
            }
            this.Width = 850;
            btn_extention.Visible = false;
            btn_redution.Visible = true;
        }

        private void btn_redution_Click(object sender, EventArgs e)
        {
            for(int i =650;i>=400;i-=5)
            {
                this.Width = i;
            }
            this.Width = 400;
            btn_extention.Visible = true;
            btn_redution.Visible = false;
        }

        private void txt_Smean_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_save_Click(sender, e);
            }
        }
    }
}
