using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 단어장
{
    public partial class Form1 : Form
    {
        string answer;
        public Form1()
        {
            InitializeComponent();
            txt_result.Text = "input answer";
            randomtxt();
        }
        public void randomtxt()
        {
            Random random = new Random();

            int num2 = list_words.Items.Count;
            int num = random.Next(0,num2);
            string str = list_words.Items[num].Text;

            txt_word.Text = str;

            answer = list_words.Items[num].SubItems[1].Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(answer == txt_mean.Text)
            {
                randomtxt();
                txt_result.Text = "correct";
            }
            else
            {
                txt_result.Text = "wrong";
            }
                
        }

        private void txt_mean_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btn_submit_Click(sender, e);
            }
        }
    }
}
