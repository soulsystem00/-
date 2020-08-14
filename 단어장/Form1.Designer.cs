namespace 단어장
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "hello",
            "안녕"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "asist",
            "도움"}, -1);
            this.txt_word = new System.Windows.Forms.Label();
            this.txt_mean = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.list_words = new System.Windows.Forms.ListView();
            this.단어 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.뜻 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_word
            // 
            this.txt_word.AutoSize = true;
            this.txt_word.Font = new System.Drawing.Font("굴림", 15F);
            this.txt_word.Location = new System.Drawing.Point(169, 47);
            this.txt_word.Name = "txt_word";
            this.txt_word.Size = new System.Drawing.Size(87, 25);
            this.txt_word.TabIndex = 0;
            this.txt_word.Text = "단어장";
            // 
            // txt_mean
            // 
            this.txt_mean.Location = new System.Drawing.Point(174, 98);
            this.txt_mean.Name = "txt_mean";
            this.txt_mean.Size = new System.Drawing.Size(100, 25);
            this.txt_mean.TabIndex = 1;
            this.txt_mean.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_mean_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "뜻";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(289, 98);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 3;
            this.btn_submit.Text = "제출";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // list_words
            // 
            this.list_words.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.단어,
            this.뜻});
            this.list_words.HideSelection = false;
            this.list_words.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.list_words.Location = new System.Drawing.Point(523, 65);
            this.list_words.Name = "list_words";
            this.list_words.Size = new System.Drawing.Size(205, 271);
            this.list_words.TabIndex = 4;
            this.list_words.UseCompatibleStateImageBehavior = false;
            this.list_words.View = System.Windows.Forms.View.Details;
            // 
            // 단어
            // 
            this.단어.Text = "단어";
            this.단어.Width = 90;
            // 
            // 뜻
            // 
            this.뜻.Text = "뜻";
            // 
            // txt_result
            // 
            this.txt_result.AutoSize = true;
            this.txt_result.Location = new System.Drawing.Point(171, 160);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(38, 15);
            this.txt_result.TabIndex = 5;
            this.txt_result.Text = "hello";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.list_words);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_mean);
            this.Controls.Add(this.txt_word);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_word;
        private System.Windows.Forms.TextBox txt_mean;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.ListView list_words;
        private System.Windows.Forms.ColumnHeader 단어;
        private System.Windows.Forms.ColumnHeader 뜻;
        private System.Windows.Forms.Label txt_result;
    }
}

