using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Collections;

namespace MyPlayers
{
    /// <summary>
    /// 从千千静听网站寻找并下载歌词
    /// <para>源代码来自博客园网友（http://www.cnblogs.com/5yplan/archive/2009/01/15/1376265.html）</para>
    /// <para>修改：LYM 2010-07-23</para>
    /// </summary>
    class C_DownloadLyrForQQ
    {
        public static readonly string SearchPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?sh?Artist={0}&Title={1}&Flags=0";
        public static readonly string DownloadPath = "http://ttlrcct2.qianqian.com/dll/lyricsvr.dll?dl?Id={0}&Code={1}";
        
        private bool needproxy = false;
        private WebProxy proxy;
        private ArrayList aLyrDownloadAdd = new ArrayList();

        public ArrayList LyrDownloadAdd
        {
            get
            {
                return aLyrDownloadAdd;
            }
        }

        public bool NeedProxy
        {
            get
            {
                return needproxy;
            }
            set
            {
                needproxy = value;
            }
        }

        public WebProxy Proxy
        {
            get
            {
                return proxy;
            }
            set
            {
                proxy = value;
            }
        }

        public event EventHandler InitializeProxy;
        public event EventHandler WebException;


        public C_DownloadLyrForQQ( bool needproxy )
        {
            this.needproxy = needproxy;
        }

        public string RequestALink(string link) {
            WebRequest request = WebRequest.Create(link);
            if (this.needproxy) {
                if (this.proxy == null) {
                    this.OnInitializeProxy();
                }
                request.Proxy = this.proxy;
            }
            
            StringBuilder sb = new StringBuilder();
            try {
                using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    sb.Append(sr.ReadToEnd());
                }
            } catch (WebException ex) {
                this.OnWebException(ex);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 寻找并下载第一个指定歌手和歌名的歌词
        /// </summary>
        /// <param name="singer">歌手</param>
        /// <param name="title">歌名</param>
        /// <returns></returns>
        public string FindLrcAndDownLoadOne(string singer, string title) {
            aLyrDownloadAdd.Clear();
            XmlDocument xml = SearchLrc(singer, title);
            string retStr = "没有找到该歌词";
            if (xml == null)
                return retStr;

            XmlNodeList list = xml.SelectNodes("/result/lrc");
            LyrDownLoadAddInfo iLyrInfo;
            if (list.Count > 0) {
                foreach(XmlNode iNode in list)
                {
                    if (iNode.Attributes == null || iNode.Attributes["id"] == null)
                        continue;
                    int iLyrID = -1;
                    if (int.TryParse(iNode.Attributes["id"].Value, out iLyrID))
                    {
                        iLyrInfo = new LyrDownLoadAddInfo();
                        iLyrInfo.MusicName = iNode.Attributes["title"].Value;
                        iLyrInfo.Singer = iNode.Attributes["artist"].Value;
                        iLyrInfo.ServerID = iLyrID;
                        aLyrDownloadAdd.Add(iLyrInfo);
                    }
                }
            } 
            else {
                return retStr;
            }

            if (this.aLyrDownloadAdd.Count > 0)
                return this.DownloadLrc(((LyrDownLoadAddInfo) this.aLyrDownloadAdd[0]));
            else
                return retStr;
        }

        /// <summary>
        /// 下载一个指定下载信息的歌词
        /// </summary>
        /// <param name="DownLoadInfo"></param>
        /// <returns></returns>
        public string DownloadLrc( LyrDownLoadAddInfo DownLoadInfo )
        {
            return RequestALink(string.Format(DownloadPath, DownLoadInfo.ServerID,
                        EncodeHelper.CreateQianQianCode(DownLoadInfo.Singer, DownLoadInfo.MusicName
                        , DownLoadInfo.ServerID)));
        }

        protected void OnInitializeProxy() {
            if (this.InitializeProxy != null) {
                this.InitializeProxy(this, new EventArgs());
            }
        }

        protected void OnWebException(WebException ex) {
            if (this.WebException != null) {
                this.WebException(ex, new EventArgs());
            } else {
                throw ex;
            }
        }

        public XmlDocument SearchLrc(string singer, string title) {
            singer = singer.ToLower().Replace(" ", "").Replace("'", "");
            title = title.ToLower().Replace(" ", "").Replace("'", "");
            string x = RequestALink(string.Format(SearchPath, 
                EncodeHelper.ToQianQianHexString(singer, Encoding.Unicode), 
                EncodeHelper.ToQianQianHexString(title, Encoding.Unicode)));
            XmlDocument xml = new XmlDocument();
            try {
                xml.LoadXml(x);
            } catch (Exception) {
            }
            return xml;
        }
    }

    class LyrDownLoadAddInfo
    {
        public string Singer = "";
        public string MusicName = "";
        public int ServerID = -1;
    }
}
