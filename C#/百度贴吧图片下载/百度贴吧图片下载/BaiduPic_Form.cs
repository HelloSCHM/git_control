using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace 百度贴吧图片下载
{
    public partial class BaiduPic_Form : Form
    {

        public static string path = Directory.GetCurrentDirectory();
        public static string url;
        public static string nurl;
        public string strHtml;
        public string mainName;
        private delegate void SetPos(int ipos);
        int pos = 0;

        public BaiduPic_Form()
        {
            InitializeComponent();          
        }

        private void linklb_path_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linklb_path.Text);
        }

        private void Btn_File_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                path = fbd.SelectedPath;
        }

        private void Btn_Download_Click(object sender, EventArgs e)
        {
            //linklb_path.Text = txb_path.Text;
            pos = 10;

            showLsv();

            url = txb_path.Text;
            if (url.Contains("?see_lz=1&pn="))
                url = url;
            else
                url = url + "?see_lz=1&pn=";
            string strHTML;
            strHTML = getHtml(url);
            Regex r = new Regex(@"<h1 class=""core_title_txt  "" title=""(.*?)""");
            mainName = r.Match(strHTML).Groups[1].ToString();

            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.Start();

            for (int i = int.Parse(txb_start.Text); i <= int.Parse(txb_end.Text); i++ )
            {
                nurl = url + i.ToString();
                getUrl(nurl,i);
                lsb_show.Items.Add("第 " + i.ToString() + "  页");
                //pos = i / (int.Parse(txb_end.Text) - int.Parse(txb_start.Text) + 1) * 100;
                //MessageBox.Show(pos.ToString());
                //toolStripProgressBar.Value = pos;
            }

            
            lsb_show.Items.Add("共 " + (int.Parse(txb_end.Text) - int.Parse(txb_start.Text) + 1) + "  页");
            lsb_show.Items.Add("已完成~请到文件夹下查看~");
            lsb_show.SelectedIndex = lsb_show.Items.Count - 1;
            toolStripProgressBar.Value = 100;
        }

        public void showLsv()
        {
            lsb_show.Items.Add("开始从 ");
            lsb_show.Items.Add(txb_path.Text);
            lsb_show.Items.Add("获取图片");
            lsb_show.Items.Add("开始从 " + txb_start.Text + "  页");
            lsb_show.Items.Add("开始获取");
        }


        public string getHtml(string url)
        {
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHtml = sr.ReadToEnd();
            myStream.Close();
            //textBox2.Text = strHTML;
            return strHtml;
        }

        public void getUrl(string url,int pc)
        {
            string strHTML;
            strHTML = getHtml(url);

            //①正则表达式 = > 匹配字符串  

            //定义一个模式字符串,不仅仅是纯文本，还可以是正则表达式  
            string Pattern = @"(?<=<img class=""BDE_Image"".*src="").*?.jpg";

            MatchCollection Matches = Regex.Matches(
                strHTML,
                Pattern,
                //RegexOptions.IgnoreCase |         //忽略大小写  
                RegexOptions.ExplicitCapture    //提高检索效率  
                //RegexOptions.RightToLeft          //从左向右匹配字符串  
                );

            //lsb_show.Items.Add("从右向左匹配字符串：");

            foreach (Match NextMatch in Matches)
            {
                lsb_show.Items.Add(NextMatch.Value);
                lsb_show.SelectedIndex = lsb_show.Items.Count - 1;
                //bool scroll = false;
                //if (this.lsb_show.TopIndex == this.lsb_show.Items.Count - (int)(this.lsb_show.Height / this.lsb_show.ItemHeight)) scroll = true; this.lsb_show.Items.Add("new line"); if (scroll) this.lsb_show.TopIndex = this.lsb_show.Items.Count - (int)(this.lsb_show.Height / this.lsb_show.ItemHeight);
                getPic(NextMatch.Value, path + "\\" + mainName , "\\" + pc.ToString() + "_" + NextMatch.Index.ToString());
                //lsb_show.Items.Add("/n");
            }
            
            //Console.WriteLine();  
        }

        public void getPic(string url,string path,string name)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = path + name + ".jpg";
            //MessageBox.Show(filepath);
            WebClient mywebclient = new WebClient();
            mywebclient.DownloadFile(url, filepath);
        }

        public void addSub()
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.AddRange(new string[] {"名字","网络地址","保存地址"});

            lsb_show.Items.Add(item);
        }


        //private void SetTextMessage(int ipos)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        SetPos setpos = new SetPos(SetTextMessage);
        //        this.Invoke(setpos, new object[] { ipos });
        //    }
        //    else
        //    {
        //        this.toolStripStatusLabel1.Text = ipos.ToString() + "/100";
        //        this.toolStripProgressBar.Value = Convert.ToInt32(ipos);
        //    }
        //}

        //private void SleepT()
        //{
        //    for (int i = 0; i < 500; i++)
        //    {
        //        System.Threading.Thread.Sleep(100);//没什么意思，单纯的执行延时
        //        SetTextMessage(100 * i / 500);
        //    }
        //}
    }
}
