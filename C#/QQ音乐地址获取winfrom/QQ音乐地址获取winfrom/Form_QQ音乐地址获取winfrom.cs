using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QQ音乐地址获取winfrom
{
    public partial class Form_QQ音乐地址获取winfrom : Form
    {
        string Music_Uri;
        string strHTML = "";
        WebClient myWebClient = new WebClient();
        Stream myStream;
        StreamReader sr;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public Form_QQ音乐地址获取winfrom()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txb_Search.Text.Trim() == string.Empty)
            {
                MessageBox.Show("搜索歌曲为空！请输入");
            }
            else
            {
                Music_Uri = "http://soso.music.qq.com/fcgi-bin/multiple_music_search.fcg?mid=1&p=1&catZhida=1&lossless=0&t=100&searchid=29086519332305774&remoteplace=txt.yqqlist.top&utf8=1&w=" + txb_Search.Text + "%0A";
                txb_Uri_1.Text = Music_Uri;
                myStream = myWebClient.OpenRead(Music_Uri);
                sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
                strHTML = sr.ReadToEnd();
                myStream.Close();
                GetUri_1();
            }
        }

        public void GetUri_1()
        {
            try
            {
                Regex r = new Regex("(?<=mid=\")\\S+\\b");
                Match m = r.Match(strHTML);
                string substr = m.ToString();
                Music_Uri = "http://s.plcloud.music.qq.com/fcgi-bin/fcg_yqq_song_detail_info.fcg?songmid=" + substr;
                txb_Uri_2.Text = Music_Uri;
                myStream = myWebClient.OpenRead(Music_Uri);
                sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
                strHTML = sr.ReadToEnd();
                myStream.Close();
                GetUri_2();
            }
            catch
            { MessageBox.Show("不存在此信息！请重新执行"); }
        }
        public void GetUri_2()
        {
            try
            {
                Regex r = new Regex("(?<=songid=)\\S+(?=#)");
                Match m = r.Match(strHTML);
                string substr = m.ToString();
                Music_Uri = "http://tsmusic24.tc.qq.com/" + substr + ".mp3";
                txb_Uri_4.Text = "http://60.28.13.21/" + substr + ".mp3";
                txb_Uri_3.Text = Music_Uri;
                MessageBox.Show("音乐地址以获取，请点击播放！");
            }
            catch
            { MessageBox.Show("不存在此信息！请重新执行"); }
        }
        public void Play()
        {
            player.URL = Music_Uri;
            player.controls.play();
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }
    }
}
