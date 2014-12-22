using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyPlayers
{
    /// <summary>
    /// 一句歌词
    /// </summary>
    [Serializable]
    public class C_OneLyricsStr
    {
        private Int32 aStartTime = 0;

        private Int32 aEndTime = 0;

        private String aLyricsStr = "";

        /// <summary>
        /// 开始的时间
        /// </summary>
        public Int32 StartTime
        {
            get { return aStartTime; }
            set 
            {
                if ((value > aEndTime) && (aEndTime != 0))
                {
                    aStartTime = 0;
                    return;
                }
                aStartTime = value;
            }
        }

        /// <summary>
        /// 结束的时间
        /// </summary>
        public Int32 EndTime
        {
            get { return aEndTime; }
            set
            {
                if ((aStartTime != 0) && (value < aStartTime))
                {
                    aEndTime = 0;
                    return;
                }
                aEndTime = value;
            }
        }

        /// <summary>
        /// 歌词内容
        /// </summary>
        public String LyricsStr
        {
            get { return aLyricsStr; }
            set { aLyricsStr = value; }
        }

        /// <summary>
        /// 返回指定时间是否在该句歌词中
        /// </summary>
        /// <param name="Times"></param>
        /// <returns></returns>
        public Boolean GetInTimes(Int32 Times)
        {
            if ((Times >= aStartTime) && (Times <= aEndTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取指定时间下的进度增量
        /// </summary>
        /// <param name="StrHeight">歌词高度</param>
        /// <param name="Time">当前时间</param>
        /// <returns>进度增量</returns>
        public float GetHeightIncrease(float StrHeight, Int32 Time)
        {
            float iRet = StrHeight * (((float)(Time - aStartTime)) / (aEndTime - aStartTime));

            return iRet;
        }

        public Color GetBestInColor(Color Color1, Color Color2, Int32 Time)
        {
            Color iBestColor = Color.Black;
            float iProportion = ((float)(Time - aStartTime)) / (aEndTime - aStartTime);
            if (iProportion > 0.4f)
            {
                return Color1;
            }
            if ((iProportion < 0) || (iProportion > 1))
            {
                return Color1;
            }
            iBestColor = GetGradientColor(Color2, Color1, iProportion);
            return iBestColor;
        }

        public Color GetBestOutColor(Color Color1, Color Color2, Int32 Time)
        {
            float iProportion = ((float)(Time - aEndTime)) / 1000f;
            if ((iProportion <= 0) || (iProportion > 1))
            {
                return Color2;
            }
            return GetGradientColor(Color1, Color2, iProportion);
        }

        /// <summary>
        /// 取两色之间渐变色
        /// </summary>
        /// <param name="Color1">开始色</param>
        /// <param name="Color2">结束色</param>
        /// <param name="f">增量</param>
        /// <returns></returns>
        private Color GetGradientColor(Color Color1, Color Color2, float f)
        {
            Int32 iDiff_R = Color2.R - Color1.R;
            Int32 iDiff_G = Color2.G - Color1.G;
            Int32 iDiff_B = Color2.B - Color1.B;
            Int32 iNewColor_R = (int)(Color1.R + f * iDiff_R);
            Int32 iNewColor_G = (int)(Color1.G + f * iDiff_G);
            Int32 iNewColor_B = (int)(Color1.B + f * iDiff_B);
            Color iNewColor = Color.FromArgb(iNewColor_R, iNewColor_G, iNewColor_B);
            return iNewColor;
        }
    }
}
