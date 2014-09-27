using libZPlay;
using System;
using System.Windows.Forms;
using Un4seen.Bass;

namespace 音乐播放winfrom
{
    public partial class Form1 : Form
    {
        string filename;
        int stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, this.Handle))
            //{
            //    MessageBox.Show("BASS初始化错误！" + Bass.BASS_ErrorGetCode().ToString());
            //}
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd_Open = new OpenFileDialog();//定义打开文本框实体
            ofd_Open.Title = "打开文件";//对话框标题
            ofd_Open.Filter = "音乐（.mp3）|*.mp3|所有文件|*.*";//文件扩展名
            if (ofd_Open.ShowDialog() == DialogResult.OK)
            {
                filename = ofd_Open.FileName;
            }

            MessageBox.Show("Playing test.mp3. Press Q to quit.\n");
            // create ZPlay class
            ZPlay player = new ZPlay();
            // open file
            if (player.OpenFile("ワカバ-明日、僕は君に会いに行く。.mp3", TStreamFormat.sfAutodetect) == false)
            {
                MessageBox.Show(player.GetError());
                return;
            }

            // get song length
            TStreamInfo info = new TStreamInfo();
            player.GetStreamInfo(ref info);
            //MessageBox.Show("Length: {0:G}:{1:G}:{2:G}:{3:G}", info.Length.hms.hour,info.Length.hms.minute,info.Length.hms.second,info.Length.hms.millisecond);

            // start playing
            player.StartPlayback();

            TStreamStatus status = new TStreamStatus();
            TStreamTime time = new TStreamTime();
            status.fPlay = true;
            ConsoleKeyInfo cki;

            while (status.fPlay)
            {
                player.GetPosition(ref time);
                Console.Write("Pos: {0:G}:{1:G}:{2:G}:{3:G}\r", time.hms.hour,
                time.hms.minute,
                time.hms.second,
                time.hms.millisecond);
                player.GetStatus(ref status);
                System.Threading.Thread.Sleep(50);
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Q)
                        player.StopPlayback();
                }
            }
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            MessageBox.Show(filename);
            stream = Bass.BASS_StreamCreateFile(filename, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            Bass.BASS_ChannelPlay(stream, true);
        }
    }
}
