using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using libZPlay;

namespace MyPlayers
{
    public partial class Frm_ShowLyrics : Form
    {
        C_DownloadLyrForQQ aDownloadLyr = null;

        public Frm_ShowLyrics()
        {
            InitializeComponent();
            //this.lyrControl1.Tag = C_IrisSkin.CurrentSkinEngine.DisableTag;
            //C_IrisSkin.AddForm(this);
            aDownloadLyr = new C_DownloadLyrForQQ(false);
        }

        public void ReadLyricFile(string FileName, TID3InfoEx Mp3Info, bool OnLineSearch)
        {
            string iFilePath = Application.StartupPath + "\\LRC\\" + FileName + ".lrc";
            this.lyrControl1.Clear("正在寻找歌词……");
            if (File.Exists(iFilePath))
            {
                lyrControl1.ReadLyricForFile(iFilePath);
                return;
            }
            if (aDownloadLyr != null)
            {
                if (Mp3Info.Artist == "" && Mp3Info.Title == "")
                {
                    return;
                }
                try
                {

                    string iLyrStr = aDownloadLyr.FindLrcAndDownLoadOne(Mp3Info.Artist, Mp3Info.Title);
                    if (iLyrStr == "没有找到该歌词")
                    {
                        this.lyrControl1.Clear(Mp3Info.Artist + " - " + Mp3Info.Title);
                        return;
                    }
                    using (StreamWriter iLyrFile = new StreamWriter(iFilePath, false, Encoding.Default))
                    {
                        iLyrFile.Write(iLyrStr);
                    }
                    Thread.Sleep(100);
                    lyrControl1.ReadLyricForFile(iFilePath);
                }
                catch
                {
                    return;
                }

            }

        }

        public void SetCurrentLyric(string TimeStr)
        {
            lyrControl1.SetCurrentLyric(TimeStr);
        }

        public void SetCurrentLyric(Int32 Time)
        {
            lyrControl1.SetCurrentLyric(Time);
        }
    }
}
