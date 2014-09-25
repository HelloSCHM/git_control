using Microsoft.Win32;
using System.Windows;
using System.Windows.Interop;
using Un4seen.Bass;

namespace 音乐播放
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        string filename;
        int stream;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //System.IntPtr win = new WindowInteropHelper(this).Handle;
            ////string handle = new WindowInteropHelper(this).Handle.ToInt32();
            //if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, win))
            //{
            //    MessageBox.Show("BASS初始化错误！" + Bass.BASS_ErrorGetCode().ToString());
            //}
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd_Open = new OpenFileDialog();//定义打开文本框实体
            ofd_Open.Title = "打开文件";//对话框标题
            ofd_Open.Filter = "音乐（.mp3）|*.mp3|所有文件|*.*";//文件扩展名
            if ((bool)ofd_Open.ShowDialog().GetValueOrDefault())//打开
            {
                filename = ofd_Open.FileName;
                //成功后的处理
            }
        }

        public void Player()
        {
            MessageBox.Show(filename);
            stream = Bass.BASS_StreamCreateFile(filename, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT);
            Bass.BASS_ChannelPlay(stream,true);
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            Player();
        }
    }
}
