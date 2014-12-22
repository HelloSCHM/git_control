using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MyPlayers
{
    public partial class LyrControl : Panel
    {
        private const Int32 aConfine = 60;

        private SortedList<Int32, C_OneLyricsStr> aLyricList = new SortedList<Int32, C_OneLyricsStr>();

        private StringBuilder aLyricTop = new StringBuilder();

        private StringBuilder aLyricCenter = new StringBuilder();

        private StringBuilder aLyricBottom = new StringBuilder();

        private Font aLyricStrFont = new Font("宋体", 10);

        private StringFormat aLyricStrFormat = new StringFormat();

        private SolidBrush aLyricNowBrush = new SolidBrush(Color.Blue);

        private SolidBrush aLyricStrBrush = new SolidBrush(Color.Black);

        private Int32 aCurrentLyricIndex = 0;

        private Int32 aCurrentTimes = 0;

        private LyrControlState aCurrentState = LyrControlState.Standby;

        private String aMsgStr = "";

        private Color aColor_Back = Color.FromArgb(28, 60, 125);

        private Color aColor_NowLyric = Color.FromArgb(255, 255, 255);

        private Color aColor_NormalLyric = Color.FromArgb(128, 176, 255);
        
        private Int32 aOffset = 0;

        /// <summary>
        /// 无歌词时显示在中间的一条信息。
        /// </summary>
        public String MsgStr
        {
            set { aMsgStr = value; }
        }

        public LyrControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            aLyricStrFormat.Alignment = StringAlignment.Center;
            this.BackColor = aColor_Back;
            this.Paint += new PaintEventHandler(LyrControl_Paint);
        }

        void LyrControl_Paint(object sender, PaintEventArgs e)
        {
            if ((aCurrentState == LyrControlState.Pause) || (aCurrentState == LyrControlState.Standby))
            {
                return;
            }

            Graphics iPaintGraphics = e.Graphics;
            Int32 iThisHalfHeight = e.ClipRectangle.Height / 2;

            if (aLyricList.Count <= 0)
            {
                iPaintGraphics.DrawString(aMsgStr, aLyricStrFont, aLyricStrBrush
                    , new RectangleF(0, iThisHalfHeight, e.ClipRectangle.Width, (e.ClipRectangle.Height - iThisHalfHeight))
                    , aLyricStrFormat);
                aCurrentState = LyrControlState.Pause;
                return;
            }

            C_OneLyricsStr iNowLyricStr = aLyricList.Values[aCurrentLyricIndex];
            SizeF iLyricStr_Size = iPaintGraphics.MeasureString((iNowLyricStr.LyricsStr == String.Empty ? "测试字符" : iNowLyricStr.LyricsStr), aLyricStrFont);
            float iIncreaseHeight = iNowLyricStr.GetHeightIncrease(iLyricStr_Size.Height, aCurrentTimes);

            float iNowRec_Y = iThisHalfHeight - ((Int32)((iLyricStr_Size.Height / 2) + iIncreaseHeight));
            RectangleF iNowLyricStr_Rec = new RectangleF(0, iNowRec_Y, e.ClipRectangle.Width, iLyricStr_Size.Height);
            aLyricNowBrush.Color = iNowLyricStr.GetBestInColor(aColor_NowLyric, aColor_NormalLyric, aCurrentTimes);
            iPaintGraphics.DrawString(iNowLyricStr.LyricsStr, aLyricStrFont, aLyricNowBrush, iNowLyricStr_Rec, aLyricStrFormat);

            float iTempTop_Y = iNowRec_Y - iLyricStr_Size.Height;
            for (int iTopIndex = aCurrentLyricIndex - 1; iTopIndex >= 0; iTopIndex--)
            {
                if ((iTempTop_Y + iLyricStr_Size.Height) < 0)
                {
                    break;
                }
                if (iTopIndex == (aCurrentLyricIndex - 1))
                {
                    aLyricStrBrush.Color = aLyricList.Values[iTopIndex].GetBestOutColor(aColor_NowLyric, aColor_NormalLyric, aCurrentTimes);
                }
                else
                {
                    aLyricStrBrush.Color = aColor_NormalLyric;
                }
                RectangleF iTopLyricStr_Rec = new RectangleF(0, iTempTop_Y, e.ClipRectangle.Width, iLyricStr_Size.Height);

                if (iTempTop_Y < aConfine)
                {
                    float iTempBottomConfine = iTempTop_Y / aConfine;
                    float iTempBottomConfine2 = (iTempTop_Y + iLyricStr_Size.Height) / aConfine;
                    Int32 iAlp = (Int32)(255 * (iTempBottomConfine < 0 ? 0 : iTempBottomConfine));
                    Int32 iAlp2 = (Int32)(255 * (iTempBottomConfine2 > 1 ? 1 : iTempBottomConfine2));

                    LinearGradientBrush iGradientBrush_Top = new LinearGradientBrush(iTopLyricStr_Rec
                        , Color.FromArgb(iAlp, aColor_NormalLyric), Color.FromArgb(iAlp2, aColor_NormalLyric), LinearGradientMode.Vertical);
                    iPaintGraphics.DrawString(aLyricList.Values[iTopIndex].LyricsStr, aLyricStrFont, iGradientBrush_Top, iTopLyricStr_Rec, aLyricStrFormat);
                    iGradientBrush_Top.Dispose();
                    iGradientBrush_Top = null;
                }
                else
                {
                    iPaintGraphics.DrawString(aLyricList.Values[iTopIndex].LyricsStr, aLyricStrFont, aLyricStrBrush, iTopLyricStr_Rec, aLyricStrFormat);
                }
                iTempTop_Y -= iLyricStr_Size.Height;
            }

            float iTempBottom_Y = iNowRec_Y + iLyricStr_Size.Height;
            aLyricStrBrush.Color = aColor_NormalLyric;
            float iTempConfine_B = (float)(this.Height - aConfine);
            for (int iBottomIndex = aCurrentLyricIndex + 1; iBottomIndex < aLyricList.Count; iBottomIndex++)
            {
                if (iTempBottom_Y > this.Height)
                {
                    break;
                }
                RectangleF iTopLyricStr_Rec = new RectangleF(0, iTempBottom_Y, e.ClipRectangle.Width, iLyricStr_Size.Height);
                if (iTempBottom_Y > iTempConfine_B)
                {
                    float iTempBottomConfine = (this.Height - iTempBottom_Y) / aConfine;
                    float iTempBottomConfine2 = (this.Height - (iTempBottom_Y + iLyricStr_Size.Height)) / aConfine;
                    Int32 iAlp = (Int32)(255 * iTempBottomConfine);
                    Int32 iAlp2 = (Int32)(255 * (iTempBottomConfine2 < 0 ? 0 : iTempBottomConfine2));

                    LinearGradientBrush iGradientBrush = new LinearGradientBrush(iTopLyricStr_Rec
                        , Color.FromArgb(iAlp, aColor_NormalLyric), Color.FromArgb(iAlp2, aColor_NormalLyric), LinearGradientMode.Vertical);
                    iPaintGraphics.DrawString(aLyricList.Values[iBottomIndex].LyricsStr, aLyricStrFont, iGradientBrush, iTopLyricStr_Rec, aLyricStrFormat);
                    iGradientBrush.Dispose();
                    iGradientBrush = null;
                }
                else
                {
                    iPaintGraphics.DrawString(aLyricList.Values[iBottomIndex].LyricsStr, aLyricStrFont, aLyricStrBrush, iTopLyricStr_Rec, aLyricStrFormat);
                }
                iTempBottom_Y += iLyricStr_Size.Height;
            }
        }

        /// <summary>
        /// 读取指定的歌词文件
        /// </summary>
        /// <param name="FileName"></param>
        public void ReadLyricForFile(string FileName)
        {
            StreamReader iFileRead = null;
            String iLenStr;
            String iLyricStr;
            aLyricList.Clear();
            try
            {
                iFileRead = new StreamReader(FileName, Encoding.Default);
                while (!iFileRead.EndOfStream)
                {
                    iLenStr = iFileRead.ReadLine();
                    if (iLenStr.Length <= 0)
                    {
                        continue;
                    }

                    iLyricStr = iLenStr.Substring(iLenStr.LastIndexOf("]") + 1, (iLenStr.Length - iLenStr.LastIndexOf("]") - 1));

                    String iLyrTime = iLenStr.Substring(iLenStr.IndexOf("["), (iLenStr.LastIndexOf("]") + 1));
                    if (iLyrTime == String.Empty)
                    {
                        continue;
                    }
                    if (iLyrTime.Contains("ti") || iLyrTime.Contains("ar") || iLyrTime.Contains("al") || iLyrTime.Contains("by"))
                    {
                        continue;
                    }
                    if (iLyrTime.Contains("offset"))
                    {
                        String iOffset = iLyrTime.Substring(iLyrTime.IndexOf(":") + 1, (iLyrTime.IndexOf("]") - (iLyrTime.IndexOf(":") + 1)));
                        aOffset = Int32.Parse(iOffset);
                        continue;
                    }

                    while (iLyrTime.Contains("["))
                    {
                        String iLyrOneTime = iLyrTime.Substring(iLenStr.IndexOf("[") + 1, 8);
                        iLyrTime = iLyrTime.Substring(iLyrTime.IndexOf("]") + 1);

                        Int32 iStartTims = TimesStrToMSec(iLyrOneTime);
                        C_OneLyricsStr iOneLyricStr = new C_OneLyricsStr();
                        iOneLyricStr.StartTime = iStartTims;
                        iOneLyricStr.LyricsStr = iLyricStr;
                        aLyricList.Add(iStartTims, iOneLyricStr);
                    }
                }

                SetLyricListEndTimes();
                aCurrentState = LyrControlState.Ready;
                InitLyricsShow();
            }
            catch
            {

            }
            finally
            {
                if (iFileRead != null)
                {
                    iFileRead.Close();
                    iFileRead.Dispose();
                }
            }


        }

        /// <summary>
        /// 清空歌词内容并显示指定信息
        /// </summary>
        /// <param name="MsgStr">信息内容</param>
        public void Clear(String MsgStr)
        {
            this.aMsgStr = MsgStr;
            this.aLyricList.Clear();
            aCurrentTimes = 0;
            aCurrentLyricIndex = 0;
            aCurrentState = LyrControlState.Ready;
            this.Invalidate();
        }

        /// <summary>
        /// 更新歌词列表中的每句结束时间
        /// </summary>
        private void SetLyricListEndTimes()
        {
            for (Int32 i = 0; i < aLyricList.Count; i++)
            {
                C_OneLyricsStr iOenLyricsStr = aLyricList.Values[i];
                if ((i + 1) >= aLyricList.Count)
                {
                    break;
                }
                C_OneLyricsStr iNextOenLyricsStr = aLyricList.Values[i + 1];
                iOenLyricsStr.EndTime = iNextOenLyricsStr.StartTime - 1;
            }
        }

        private void InitLyricsShow()
        {
            aCurrentLyricIndex = 0;
            this.Invalidate();
        }

        /// <summary>
        /// 把时间字符转换为毫秒
        /// </summary>
        /// <param name="TimesStr">时间字符</param>
        /// <returns></returns>
        private Int32 TimesStrToMSec(String TimesStr)
        {
            Int32 iMillisecond_Sum = 0;
            Int32 iIndex1 = TimesStr.IndexOf(":");
            Int32 iIndex2 = TimesStr.IndexOf(".");
            String iMinute_Str = TimesStr.Substring(0, iIndex1);
            String iSecond_Str = TimesStr.Substring(iIndex1 + 1, (iIndex2 - (iIndex1 + 1)));
            String iMillisecond_Str = TimesStr.Substring(iIndex2 + 1);
            Int32 iMinute = iMinute_Str == String.Empty ? 0 : Int32.Parse(iMinute_Str);
            Int32 iSecond = iSecond_Str == String.Empty ? 0 : Int32.Parse(iSecond_Str);
            Int32 iMillisecond = iMillisecond_Str == String.Empty ? 0 : Int32.Parse(iMillisecond_Str);

            iMillisecond_Sum = (iMinute * 60 + iSecond) * 1000 + iMillisecond;

            return iMillisecond_Sum;
        }

        public void SetCurrentLyric(String TimeStr)
        {
            Int32 iMillisecond = TimesStrToMSec(TimeStr);
            this.SetCurrentLyric(iMillisecond);
        }

        public void SetCurrentLyric(Int32 Time)
        {
            Int32 iNowIndex = 0;
            Int32 iTempTime = Time + aOffset;
            for (Int32 i = 0; i < aLyricList.Count; i++)
            {
                if (aLyricList.Values[i].GetInTimes(iTempTime))
                {
                    iNowIndex = i;
                    break;
                }
            }
            if (iNowIndex == 0)
            {
                return;
            }
            aCurrentLyricIndex = iNowIndex;
            aCurrentTimes = iTempTime;

            this.Invalidate();
        }

    }

    public enum LyrControlState
    {
        /// <summary>
        /// 待命
        /// </summary>
        Standby,
        /// <summary>
        /// 准备好
        /// </summary>
        Ready,
        /// <summary>
        /// 运行中
        /// </summary>
        Run,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause
    }

}
