namespace GrabJoke
{
    partial class txt_url
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_getdata = new System.Windows.Forms.Button();
            this.rt_txt = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_zan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_yues = new System.Windows.Forms.Label();
            this.lb_buzan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_date = new System.Windows.Forms.Label();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btn_getdata
            // 
            this.btn_getdata.Location = new System.Drawing.Point(2, 39);
            this.btn_getdata.Name = "btn_getdata";
            this.btn_getdata.Size = new System.Drawing.Size(75, 46);
            this.btn_getdata.TabIndex = 2;
            this.btn_getdata.Text = "开始抓取";
            this.btn_getdata.UseVisualStyleBackColor = true;
            this.btn_getdata.Click += new System.EventHandler(this.btn_getdata_Click);
            // 
            // rt_txt
            // 
            this.rt_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rt_txt.ForeColor = System.Drawing.Color.Blue;
            this.rt_txt.Location = new System.Drawing.Point(2, 91);
            this.rt_txt.Name = "rt_txt";
            this.rt_txt.ReadOnly = true;
            this.rt_txt.Size = new System.Drawing.Size(440, 593);
            this.rt_txt.TabIndex = 3;
            this.rt_txt.Text = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(133, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 12);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "暂停抓取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "继续抓取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(367, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "终止抓取";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(448, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(471, 281);
            this.treeView1.TabIndex = 8;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "内容标题：";
            // 
            // lb_zan
            // 
            this.lb_zan.AutoSize = true;
            this.lb_zan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_zan.ForeColor = System.Drawing.Color.Red;
            this.lb_zan.Location = new System.Drawing.Point(500, 318);
            this.lb_zan.Name = "lb_zan";
            this.lb_zan.Size = new System.Drawing.Size(16, 16);
            this.lb_zan.TabIndex = 15;
            this.lb_zan.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "点赞数：";
            // 
            // lb_yues
            // 
            this.lb_yues.AutoSize = true;
            this.lb_yues.Location = new System.Drawing.Point(563, 320);
            this.lb_yues.Name = "lb_yues";
            this.lb_yues.Size = new System.Drawing.Size(53, 12);
            this.lb_yues.TabIndex = 14;
            this.lb_yues.Text = "不赞数：";
            // 
            // lb_buzan
            // 
            this.lb_buzan.AutoSize = true;
            this.lb_buzan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_buzan.ForeColor = System.Drawing.Color.Red;
            this.lb_buzan.Location = new System.Drawing.Point(611, 317);
            this.lb_buzan.Name = "lb_buzan";
            this.lb_buzan.Size = new System.Drawing.Size(16, 16);
            this.lb_buzan.TabIndex = 15;
            this.lb_buzan.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(678, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "获取时间：";
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_date.ForeColor = System.Drawing.Color.Red;
            this.lb_date.Location = new System.Drawing.Point(741, 317);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(16, 16);
            this.lb_date.TabIndex = 15;
            this.lb_date.Text = "0";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(448, 346);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScrollBarsEnabled = false;
            this.webBrowser2.Size = new System.Drawing.Size(471, 338);
            this.webBrowser2.TabIndex = 16;
            // 
            // txt_url
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 682);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.lb_buzan);
            this.Controls.Add(this.lb_zan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_yues);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rt_txt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_getdata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "txt_url";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "笑话段子抓取";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.txt_url_FormClosing);
            this.Load += new System.EventHandler(this.txt_url_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_getdata;
        private System.Windows.Forms.RichTextBox rt_txt;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_zan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_yues;
        private System.Windows.Forms.Label lb_buzan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.WebBrowser webBrowser2;
    }
}

