using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WMPLib;

namespace 音乐播放补全
{
    public partial class Form_Music : Form
    {
        #region 定义
        WMPLib.WindowsMediaPlayer Music_Player = new WMPLib.WindowsMediaPlayer();
        string fileuri = Directory.GetCurrentDirectory() + "/temp/config.log";
        string Music_Uri;
        string filename;
        string selectfilename;
        string[] filecontent = new string[1000];
        string fileContent;
        int temp_size = 1;
        string line;
        bool playsate = true;
        #endregion

        #region 窗口加载
        public Form_Music()
        {
            InitializeComponent();
        }

        private void Form_Music_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/temp"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/temp");
            }

            lsv_Music.Items.Clear();
            load_Read();
        }

        public void load_Read()
        {
            try
            {
                FileInfo fr1 = new FileInfo(fileuri);
                FileStream fr2 = fr1.OpenRead();
                StreamReader sr = new StreamReader(fr2);
                string nextLine;
                int i = 0;
                while ((nextLine = sr.ReadLine()) != null)
                {
                    filecontent[i] = nextLine;
                    lsv_Music.Items.Add(add_List(nextLine));
                    i++;
                }
                temp_size = i + 1;
                sr.Close();
                fr2.Close();
            }
            catch { }
        }

        public string add_List(string line)
        {
            try
            {
                Regex r1 = new Regex("#");
                Match m1 = r1.Match(line);
                line = line.Substring(5, m1.Index-4).Replace(" #", "");
                //lsv_Music.Items.Add(line);
            }
            catch { }
            return line;
        }

        #endregion

        #region 文件读写
        public void WriteFile()
        {
            if (File.Exists(fileuri))
            {
                if (ReadFile(fileuri).Contains(filename) && ReadFile(fileuri).Contains(selectfilename))
                    return;
                //存在
            }
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/temp/config.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(temp_size + "-" + temp_size + "  " + selectfilename + " #   " + filename + "$ \r\n");
            temp_size++;

            sw.Close();
            fs.Close();
        }

        public string ReadFile(string fileuri)
        {
            try
            {
                FileInfo fr1 = new FileInfo(fileuri);
                FileStream fr2 = fr1.OpenRead();
                StreamReader sr = new StreamReader(fr2);
                fileContent = sr.ReadToEnd();
                sr.Close();
                fr2.Close();
            }
            catch
            { }
            return fileContent;
        }

        public string[] ReadLine(string fileuri)
        {
            try
            {
                FileInfo fr1 = new FileInfo(fileuri);
                FileStream fr2 = fr1.OpenRead();
                StreamReader sr = new StreamReader(fr2);
                string nextLine;
                int i = 0;
                while ((nextLine = sr.ReadLine()) != null)
                {
                    filecontent[i] = nextLine;
                    i++;
                }
                temp_size = i + 1;
                sr.Close();
                fr2.Close();
            }
            catch { }
            return filecontent;
        }
        #endregion

        #region 按钮操作
        private void btn_Openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd_Open = new OpenFileDialog();//定义打开文本框实体
            ofd_Open.Title = "打开文件";//对话框标题
            ofd_Open.Filter = "音乐（.mp3）|*.mp3|所有文件|*.*";//文件扩展名
            if (ofd_Open.ShowDialog() == DialogResult.OK)//打开
            {
                filename = ofd_Open.FileName;
                selectfilename = ofd_Open.SafeFileName.Replace(".mp3", "").Replace(".MP3", "");
                if (!lsv_Music.Items.Cast<ListViewItem>().Any(i => i.Text == selectfilename))
                {
                    lsv_Music.Items.Add(selectfilename);
                    //ListViewItem item = lsv_Music.Items.Add(lsv_size.ToString());
                    //item.SubItems.Add(selectfilename);
                    //lsv_size++;
                }
                else
                    return;
                WriteFile();
                //成功后的处理
            }
        }

        #endregion

        private void lsv_Music_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            getMusicuri();
            play();
        }

        public void getMusicuri()
        {
            lb_MusicName.Text = lsv_Music.SelectedItems[0].Text;
            int i = 0;
            try
            {
                //ReadFile(fileuri);
                for (i = 0; i < ReadLine(fileuri).Length; i++)
                {
                    if (filecontent[i].Contains(lsv_Music.SelectedItems[0].Text))
                    {
                        line = filecontent[i];
                        break;
                    }
                }
            }
            catch { }
            Regex r1 = new Regex("#");
            Regex r2 = new Regex("$");
            Match m1 = r1.Match(filecontent[i]);
            Match m2 = r2.Match(filecontent[i]);
            Music_Uri = filecontent[i].Substring(m1.Index, m2.Index - m1.Index).Replace("$", "").Replace("# ", "");
        }

        public void play()
        {
            btn_Play.Text = "暂停";
            Music_Player.URL = Music_Uri;
            Music_Player.controls.play();
            playsate = true;
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            if(playsate)
            {
                btn_Play.Text = "暂停";
                Music_Player.controls.pause();
                playsate = false;
            }
            else
            {
                btn_Play.Text = "播放";
                Music_Player.controls.play();
                lb_Time_1.Text = Music_Player.controls.currentPositionString;
                playsate = true;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Music_Player.controls.previous();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Music_Player.controls.next();
        }
    }
}
