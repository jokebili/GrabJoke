using Business.Model;
using Common.Util;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Data.SugarBase;

namespace GrabJoke
{
    public partial class txt_url : Form
    {
        Thread th;
        long lines = 0;
        ConcurrentQueue<JokeData> currendQueue = new ConcurrentQueue<JokeData>();

        ArrayList list = new ArrayList();
        delegate void ShowMessage(string message, string title, ArrayList list); 
        delegate void showMes(string message, string Title = "", ArrayList list = null);
        event showMes mesgg;

        public txt_url()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void txt_url_Load(object sender, EventArgs e)
        {
            this.linkLabel1.Text = "https://www.biedoul.com/index/1";
            this.linkLabel1.Links.Add(0, 0, "https://www.biedoul.com/index/1");
            this.toolTip1.SetToolTip(this.linkLabel1, "点击跳转到对应笑话网站！");
            lb_zan.Text = "";
            lb_buzan.Text = "";
            lb_date.Text = "";
        }

        private void LoadJokeData()
        {
            lb_zan.Text = "";
            lb_buzan.Text = "";
            lb_date.Text = "";
            treeView1.Nodes.Clear();//清空treeView
            mesgg += new showMes(showMessage);
            Thread t = new Thread(new ThreadStart(GetDateAll));
            t.IsBackground = true;
            t.Start();
        }

        public void showMessage(string Message, string Title, ArrayList list1)
        {
            if (!this.InvokeRequired)
            {
                ShowMessage mes = new ShowMessage(showMessage);
                this.Invoke(mes, new object[] { Message, Title, list1 });
            }
            if (list1 != null)
            {
                list = list1;
            }
            if (!string.IsNullOrEmpty(Title))
            {
                treeView1.Invoke(new ShowMessage(addtreeView), new object[] { Message, Title, list });
            }
        }

        public void addtreeView(string message, string Title, ArrayList list)
        {
            treeView1.Nodes.RemoveByKey(Title);
            treeView1.Nodes.Add(Title, Title);
        }

        private void txt_url_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        public void GetDateAll()
        {
            var getAll = Db.Queryable<JokeData>().ToList();
            foreach (var item in getAll)
            {
                list.Add(item);//放入list里
                mesgg("", item.Title, list);
            }
        }

        /// <summary>
        /// 点击跳转到网站链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;
            string target = e.Link.LinkData as string;
            if (target != null && target.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(target);
            }
        }

        /// <summary>
        /// 获取笑话数据
        /// </summary>
        private void GetJokeData()
        {
            try
            {
                Output(DateTime.Now + " → " + " 程序开始执行！", Color.Blue);
                HtmlWeb web = new HtmlWeb();
                web.OverrideEncoding = Encoding.GetEncoding("utf-8");
                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(linkLabel1.Text);
                HtmlNode strTemp = htmlDoc.DocumentNode.SelectSingleNode(@"/html/body/div[4]/div[1]/div[2]/a[6]");
                if (strTemp == null)
                {
                    Output(DateTime.Now + " → " + " 获取总页数失败！", Color.Red);
                    return;
                }

                string str = CommonHelper.GetTitleContent(strTemp.OuterHtml, "a", "href");
                if (string.IsNullOrEmpty(str))
                {
                    Output(DateTime.Now + " → " + " 获取总页数失败！", Color.Red);
                    return;
                }

                string result = Regex.Replace(str, @"[^0-9]+", "");
                long pageCount = long.Parse(result);
                Output(DateTime.Now + " → " + " 程序获取到总页数为：" + pageCount + "", Color.Blue);
                for (int i = 1; i <= pageCount; i++)
                {
                    try
                    {
                        rt_txt.AppendText(DateTime.Now + " → " + " 程序开始请求第" + i + "页数据！" + "\r\n");
                        string url = string.Format("https://www.biedoul.com/index/{0}", i);
                        web.OverrideEncoding = Encoding.GetEncoding("utf-8");
                        HtmlAgilityPack.HtmlDocument html = web.Load(url);
                        HtmlNodeCollection rtitle = html.DocumentNode.SelectNodes(@"//*[@class='xhlist']");//返回标题数据集合
                        if (rtitle == null)
                        {
                            Output(DateTime.Now + " → " + " 未请求到数据，在第" + i.ToString() + "页,程序将睡眠5秒钟跳过本页请求数据！", Color.Red);
                            Thread.Sleep(5000);
                            continue;
                        }
                        else
                        {
                            foreach (HtmlNode node in rtitle)
                            {
                                try
                                {
                                    string title = node.SelectSingleNode(@"span/dd/a/strong").InnerText;//请求获取标题
                                    string content = node.SelectSingleNode(@"dd").InnerHtml;//请求获取内容
                                    string zanCount = node.SelectSingleNode(@"div/div[2]/a[1]/p").InnerText;//请求获取点赞数
                                    string pointsCount = node.SelectSingleNode(@"div/div[2]/a[2]/p").InnerText;//请求获取减分数

                                    var model = new JokeData()
                                    {
                                        Contents = content,
                                        CreateBy = 1,
                                        CreateDate = DateTime.Now,
                                        PointsCount = long.Parse(pointsCount == "" ? "0" : pointsCount),
                                        Title = title,
                                        UpdateBy = 1,
                                        UpdateDate = DateTime.Now,
                                        ZanCount = long.Parse(zanCount == "" ? "0" : zanCount)
                                    };
                                    currendQueue.Enqueue(model);
                                    Output(DateTime.Now + " → " + " 成功获取标题为：【" + title + "】已保存队列", Color.BlueViolet);
                                }
                                catch (Exception ex)
                                {
                                    rt_txt.AppendText(DateTime.Now + " → " + ex.Message + "\r\n");
                                    continue;
                                }
                            }
                        }

                        RunConcurrentQueue(100);

                        Output(DateTime.Now + " → " + " 第" + i + "页数据请求保存完毕！", Color.Black);
                        Output(DateTime.Now + " → " + " 程序睡眠5秒钟，稍后开始请求下一页数据！", Color.Black);
                        Thread.Sleep(5000);
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        rt_txt.AppendText(DateTime.Now + " → " + ex.Message + "\r\n");
                        continue;
                    }
                }
                RunConcurrentQueue(1);
                Output(DateTime.Now + " → " + " 所有页数据请求完毕，开始执行队列将数据保存至数据库...请稍后！", Color.Red);
                Output(DateTime.Now + " → " + " 数据已保存完毕！", Color.Red);
                GC.Collect();
            }
            catch (Exception ex)
            {
                rt_txt.AppendText(DateTime.Now + " → " + ex.Message + "\r\n");
                return;
            }
        }

        /// <summary>
        /// 处理队列数据
        /// </summary>
        /// <param name="count">数量</param>
        private void RunConcurrentQueue(int count)
        {
            if (currendQueue.Any() && currendQueue.Count >= count)
            {
                for (int i = 0; i < currendQueue.Count; i++)
                {
                    JokeData info = null;
                    currendQueue.TryDequeue(out info);
                    var update = Db.Updateable(info).UpdateColumns(s => new { s.Title, s.Contents, s.PointsCount, s.ZanCount, s.UpdateBy, s.UpdateDate }).WhereColumns(it => new { it.Title });
                    if (update.ExecuteCommand() <= 0)
                    {
                        Db.Insertable(info).ExecuteReturnBigIdentity();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (th == null || th.ThreadState == ThreadState.Aborted)
            {
                th = new Thread(GetJokeData);
                th.SetApartmentState(ApartmentState.STA);
                th.Name = "GetJoke";
                th.IsBackground = true;
                th.Start();
            }
        }

        /// <summary>
        /// 开始执行数据获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getdata_Click(object sender, EventArgs e)
        {
            Output(DateTime.Now + " → " + " 系统采用时间间隔执行，一天（24小时）执行一次，重复数据则更新，否则新增保存数据...执行期间请勿关闭程序！！！", Color.Blue);
            timer1.Interval = 1000 * 1 * 3600 * 24;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
            if (th == null || th.ThreadState == ThreadState.Aborted)
            {
                th = new Thread(GetJokeData);
                th.SetApartmentState(ApartmentState.STA);
                th.Name = "GetJoke";
                th.IsBackground = true;
                th.Start();
            }
        }

        /// <summary>
        /// 暂停执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Output(DateTime.Now + " → " + " 程序暂停中...请不要关闭程序！", Color.Yellow);
            if (th != null)
            {
                th.Suspend();
            }
        }

        /// <summary>
        /// 暂停恢复执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Output(DateTime.Now + " → " + " 程序暂停恢复,继续执行...！", Color.Green);
            if (th != null)
            {
                th.Resume();
            }
        }

        /// <summary>
        /// 终止执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Output(DateTime.Now + " → " + " 程序已终止执行！", Color.Red);
            if (th != null)
            {
                th.Abort();
            }
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="content"></param>
        /// <param name="color"></param>
        private void Output(string content, Color color)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                //超出一万行，清空
                this.lines++;
                if (this.lines > 10000)
                {
                    this.rt_txt.Text = string.Empty;
                    this.lines = 1;
                }

                content += Environment.NewLine;
                this.rt_txt.SelectionColor = color;//设置文本颜色
                this.rt_txt.AppendText(content);//输出文本，换行

                this.rt_txt.SelectionStart = this.rt_txt.Text.Length;//设置插入符位置为文本框末
                this.rt_txt.ScrollToCaret();//滚动条滚到到最新插入行
            }));
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //显示对应得信息
            foreach (JokeData rss in list)
            {
                if (rss.Title.Equals(e.Node.Text))
                {
                    lb_date.Text = rss.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                    lb_zan.Text = rss.ZanCount.ToString();
                    lb_buzan.Text = rss.PointsCount.ToString();
                    webBrowser2.DocumentText = rss.Contents;//因为Contents是html，所以应该使用这个来正常显示
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadJokeData();
        }
    }
}
