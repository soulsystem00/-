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
using System.Collections.Specialized;

namespace 단어장
{
    public partial class Form1 : Form
    {
        string answer;

        List<int> list;
        bool testcheck;
        int minwidth = 500;
        int maxwidth = 1000;
        bool wrong_word_mean_visible = false;
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

            testcheck = true;
        }

        public void setlistview()
        {
            FileInfo fileInfo = new FileInfo("word.txt");
            if(fileInfo.Exists)
            {
                StreamReader streamReader = new StreamReader("word.txt");
                while (streamReader.Peek() >= 0)
                {
                    string str = streamReader.ReadLine();
                    string[] str1 = str.Split(' ');
                    ListViewItem listViewItem = new ListViewItem(str1);
                    list_words.Items.Add(listViewItem);
                    this.Width = minwidth;
                    btn_redution.Visible = false;
                    btn_extention.Visible = true;
                }
                streamReader.Close();
            }

            fileInfo = new FileInfo("Wword.txt");
            if(fileInfo.Exists)
            {
                StreamReader streamReader2 = new StreamReader("Wword.txt");
                while (streamReader2.Peek() >= 0)
                {
                    string str = streamReader2.ReadLine();
                    string[] str1 = str.Split(' ');
                    ListViewItem listViewItem = new ListViewItem(str1);
                    list_Wword.Items.Add(listViewItem);
                    this.Width = minwidth;
                    btn_redution.Visible = false;
                    btn_extention.Visible = true;
                }
                streamReader2.Close();
            }
            txt_Wword_cnt.Text = list_Wword.Items.Count.ToString();
            

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
                if(testcheck)
                {
                    string[] str = new string[] { txt_word.Text, answer };
                    ListViewItem listViewItem = new ListViewItem(str);
                    list_Wword.Items.Add(listViewItem);
                    txt_Wword_cnt.Text = list_Wword.Items.Count.ToString();
                    list_Wword.Items[list_Wword.Items.Count-1].EnsureVisible();
                }
                
            }
            txt_mean.Text = "";
            if(testcheck)
            {
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
            else
            {
                if (list.Count > 0)
                {
                    txt_word.Text = list_Wword.Items[list[0]].Text;
                    answer = list_Wword.Items[list[0]].SubItems[1].Text;
                    list.RemoveAt(0);
                }
                else
                {
                    txt_word.Text = "Clear";
                    answer = "Clear";
                }
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
            if(string.IsNullOrEmpty(txt_Sword.Text))
            {
                MessageBox.Show("단어를 입력해주세요.", "오류", MessageBoxButtons.OK);
            }
            else if(string.IsNullOrEmpty(txt_Smean.Text))
            {
                MessageBox.Show("뜻을 입력해주세요.", "오류", MessageBoxButtons.OK);
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { txt_Sword.Text, txt_Smean.Text }, -1);
                list_words.Items.Add(listViewItem);
                txt_Smean.Text = "";
                txt_Sword.Text = "";
                txt_Sword.Focus();
                txt_wordcnt.Text = list_words.Items.Count.ToString();
            }
            
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

            StreamWriter streamWriter2 = new StreamWriter("Wword.txt");

            for (int i = 0; i < list_Wword.Items.Count; i++)
            {
                string str = list_Wword.Items[i].Text + " " + list_Wword.Items[i].SubItems[1].Text;

                streamWriter2.WriteLine(str);
            }

            streamWriter2.Close();
        }

        private void btn_listdel_Click(object sender, EventArgs e)
        {
            if(list_words.Items.Count > 0 && list_words.SelectedItems.Count != 0)
            {
                list_words.SelectedItems[0].Remove();
                txt_wordcnt.Text = list_words.Items.Count.ToString();
            }
            
        }

        private void btn_extention_Click(object sender, EventArgs e)
        {
            for(int i = minwidth; i<= maxwidth; i+=7)
            {
                this.Width = i;
            }
            this.Width = maxwidth;
            btn_extention.Visible = false;
            btn_redution.Visible = true;
        }

        private void btn_redution_Click(object sender, EventArgs e)
        {
            for(int i =maxwidth;i>= minwidth; i-=7)
            {
                this.Width = i;
            }
            this.Width = minwidth;
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

        private void button1_Click(object sender, EventArgs e)
        {
            txt_cornum.Text = "0";
            txt_incornum.Text = "0";
            
            if (list.Count == 0)
            {
                testcheck = false;
                for (int i = 0; i < list_Wword.Items.Count; i++)
                {
                    list.Add(i);
                }
                txt_word.Text = list_Wword.Items[list[0]].Text;
                answer = list_Wword.Items[list[0]].SubItems[1].Text;
                list.RemoveAt(0);
                btn_redution_Click(sender, e);
            }
            else if((MessageBox.Show("테스트가 완료되지 않았습니다.\n틀린 단어 테스트를 시작하시겠습니까?", "틀린단어 테스트", MessageBoxButtons.YesNo).ToString() == "Yes"))
            {
                if(list_Wword.Items.Count <= 0)
                {
                    MessageBox.Show("테스트할 단어가 없습니다.", "틀린단어 테스트", MessageBoxButtons.OK);
                }
                else
                {
                    testcheck = false;
                    list.Clear();
                    for (int i = 0; i < list_Wword.Items.Count; i++)
                    {
                        list.Add(i);
                    }
                    txt_word.Text = list_Wword.Items[list[0]].Text;
                    answer = list_Wword.Items[list[0]].SubItems[1].Text;
                    list.RemoveAt(0);
                    btn_redution_Click(sender, e);
                }

            }
                
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            wrong_word_mean_visible = !wrong_word_mean_visible;
            if (wrong_word_mean_visible)
            {
                list_Wword.Columns[1].Width = 0;
                btn_mean_visible.Text = "단어 뜻 보이기";
                
            }   
            else
            {
                list_Wword.Columns[1].Width = 120;
                btn_mean_visible.Text = "단어 뜻 숨기기";
            }
                
        }

        private void btn_start_test_Click(object sender, EventArgs e)
        {
            list.Clear();
            txt_result.Text = "input answer";
            list.Add(0);
            randomtxt();
            txt_wordcnt.Text = list_words.Items.Count.ToString();
            txt_word.Text = list_words.Items[list[0]].Text;
            answer = list_words.Items[list[0]].SubItems[1].Text;
            list.RemoveAt(0);

            testcheck = true;
            list_Wword.Items.Clear();
            txt_cornum.Text = "0";
            txt_incornum.Text = "0";
            btn_redution_Click(sender, e);
        }

        private void btn_Wword_del_Click(object sender, EventArgs e)
        {
            if (list_Wword.Items.Count > 0 && list_Wword.SelectedItems.Count != 0)
            {
                list_Wword.SelectedItems[0].Remove();
                txt_Wword_cnt.Text = list_Wword.Items.Count.ToString();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
