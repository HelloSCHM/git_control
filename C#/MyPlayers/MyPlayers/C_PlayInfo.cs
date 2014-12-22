using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyPlayers
{
    internal enum PlayState
    {
        Stopped,
        Paused,
        Running,
        Init
    };

    /// <summary>
    /// 播放模式
    /// </summary>
    public enum PlayMode
    {
        /// <summary>
        /// 单曲播放
        /// </summary>
        Single,
        /// <summary>
        /// 单曲循环
        /// </summary>
        SingleCycle,
        /// <summary>
        /// 顺序播放
        /// </summary>
        Order,
        /// <summary>
        /// 循环播放
        /// </summary>
        Cycle,
        /// <summary>
        /// 随机播放
        /// </summary>
        Random
    };

    [Serializable]
    public class C_PlayInfo
    {
        private static C_PlayInfo aPlayInfo;

        public string aBfListName = "";
        public string aMusicName = "";
        public PlayMode aPlaymode = PlayMode.Random;
        public int aVolume = 60;

        public static string BfListName
        {
            get { return aPlayInfo.aBfListName; }
            set { aPlayInfo.aBfListName = value; }
        }
        public static string MusicName
        {
            get { return aPlayInfo.aMusicName; }
            set { aPlayInfo.aMusicName = value; }
        }
        public static PlayMode Playmode
        {
            get { return aPlayInfo.aPlaymode; }
            set { aPlayInfo.aPlaymode = value; }
        }
        public static int Volume
        {
            get { return aPlayInfo.aVolume; }
            set { aPlayInfo.aVolume = value; }
        }

        private C_PlayInfo()
        {
        }

        static C_PlayInfo()
        {
            aPlayInfo = new C_PlayInfo();
        }

        /// <summary>
        /// 序列化对象
        /// </summary>
        public static void Serialiaze()
        {
            //创建一个文件流对象stream，指向文件MyFile.bin
            IFormatter formatter = new BinaryFormatter();
            string iFileName1 = Application.StartupPath + "\\PlayInfo.pinf";
            Stream stream = new FileStream(iFileName1, FileMode.Create, FileAccess.Write, FileShare.None);
            //通过formatter对象以二进制格式将obj对象序列化后到文件MyFile.bin中
            formatter.Serialize(stream, aPlayInfo);
            stream.Close();
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        public static void Deserialize()
        {
            string iFileName1 = Application.StartupPath + "\\PlayInfo.pinf";
            if (File.Exists(iFileName1) == false)
            {
                return;
            }
            Stream stream = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(iFileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
                aPlayInfo = (C_PlayInfo)formatter.Deserialize(stream);
            }
            catch
            { }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
    }
}
