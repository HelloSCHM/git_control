using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Un4seen.Bass;

namespace 音乐播放
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaElement MusicPlayer = new MediaElement();
        bool playstate = true;

        string filename; 
        string selectfilename;
        DoubleAnimation daV_Enter = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation daV_Exit = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(1)));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MusicPlayer.LoadedBehavior = MediaState.Manual;
            MusicPlayer.UnloadedBehavior = MediaState.Manual;
            //System.IntPtr win = new WindowInteropHelper(this).Handle;
            ////string handle = new WindowInteropHelper(this).Handle.ToInt32();
           // Img_Show.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_MusicSearch_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid_MusicSearch.Visibility = System.Windows.Visibility.Visible;
            Grid_MusicList.Visibility = System.Windows.Visibility.Hidden;
            Grid_MusicAbout.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_MusicList_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid_MusicList.Visibility = System.Windows.Visibility.Visible;
            Grid_MusicAbout.Visibility = System.Windows.Visibility.Hidden;
            Grid_MusicSearch.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btn_MusicAbout_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid_MusicAbout.Visibility = System.Windows.Visibility.Visible;
            Grid_MusicList.Visibility = System.Windows.Visibility.Hidden;
            Grid_MusicSearch.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Img_Show_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Img_Show.Visibility == System.Windows.Visibility.Hidden)
            {
                this.Img_Show.BeginAnimation(UIElement.OpacityProperty, daV_Enter);
                Img_Show.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.Img_Show.BeginAnimation(UIElement.OpacityProperty, daV_Exit);
                Img_Show.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Grid_Fail_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Img_Show.Visibility == System.Windows.Visibility.Hidden)
            {
                this.Img_Show.BeginAnimation(UIElement.OpacityProperty, daV_Enter);
                Img_Show.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.Img_Show.BeginAnimation(UIElement.OpacityProperty, daV_Exit);
                Img_Show.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void OpenFile_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenFileDialog ofd_Open = new OpenFileDialog();//定义打开文本框实体
            ofd_Open.Title = "打开文件";//对话框标题
            ofd_Open.Filter = "音乐（.mp3）|*.mp3|所有文件|*.*";//文件扩展名
            if ((bool)ofd_Open.ShowDialog().GetValueOrDefault())//打开
            {
                filename = ofd_Open.FileName;
                selectfilename = ofd_Open.SafeFileName;
                lsv_Music.Items.Add(selectfilename);
                //成功后的处理
            }
        }

        private void Image_Play_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (playstate)
            {
                try
                {
                    Slider_Player.Minimum = 0;
                    Txb_MusicName.Text = selectfilename;
                    //BitmapImage image = new BitmapImage(new Uri(@"/Images/Play.png", UriKind.Absolute));
                    //Image_Play.Source = image;
                    MusicPlayer.Source = new Uri(filename);
                    MusicPlayer.Play();
                    Txb_Time_1.Text = MusicPlayer.Position.ToString();
                    Txb_Time_3.Text = MusicPlayer.Position.Minutes.ToString();
                    Slider_Player.Maximum = MusicPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    playstate = false;
                }
                catch { MessageBox.Show("选择文件！"); }
            }
            else
            {
                //BitmapImage image = new BitmapImage(new Uri("/Images/Stop.png", UriKind.Absolute));
                //Image_Play.Source = image;
                MusicPlayer.Pause();
                playstate = true;
            }
        }

        private void Img_Min_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Img_Close_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        private void Slider_Player_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MusicPlayer.Pause();
            MusicPlayer.Position = TimeSpan.FromSeconds(Slider_Player.Value);
            MusicPlayer.Play();
        }
    }
}
