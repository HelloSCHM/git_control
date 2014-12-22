using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using libZPlay;

namespace MyPlayers
{
    public partial class Frm_Play : Form
    {
        private const Int32 WM_MOVE = 0x3;
        private const Int32 WM_SIZE = 0x5;
        private const Int32 WM_ACTIVATE = 0x6;

        private const Int32 WA_INACTIVE = 0;
        private const Int32 SIZE_MINIMIZED = 1;

        private ZPlay aMusicPlayers;
        private Frm_ShowLyrics aFrm_ShowLyrcs = null;
        private PlayState aPlayState = PlayState.Init;
        private PlayMode aPlayMode = PlayMode.Order;
        private Int32 aLastMusicID = -1;
        private Int32 aCurrentMusicID = -1;
        private Boolean aIsInitList = true;
        private Boolean aLeftButtonDownOnPlayTime = false;

        public Frm_Play()
        {
            InitializeComponent();
            //this.checkB_Lyrics.Tag = C_IrisSkin.CurrentSkinEngine.DisableTag;
            ////C_IrisSkin.AddForm(this);
        }

        private void InitInfo()
        {
            tBar_Volume.Value = C_PlayInfo.Volume > tBar_Volume.Maximum ? 60 : C_PlayInfo.Volume;

            aPlayMode = C_PlayInfo.Playmode;
            switch (aPlayMode)
            {
                case PlayMode.Single:
                    comB_PlayMode.SelectedIndex = 0;
                    break;
                case PlayMode.SingleCycle:
                    comB_PlayMode.SelectedIndex = 1;
                    break;
                case PlayMode.Order:
                    comB_PlayMode.SelectedIndex = 2;
                    break;
                case PlayMode.Cycle:
                    comB_PlayMode.SelectedIndex = 3;
                    break;
                case PlayMode.Random:
                    comB_PlayMode.SelectedIndex = 4;
                    break;
            }
        }

        private void InitBoList()
        {
            String iSqlStr="SELECT * FROM [PlaysList]";
            if (C_SqlOper.SeleData(iSqlStr, ref dTable_BfList) == false)
                return;

            InitFistList();
            InitMusicFileList();
            InitFistMusicFile();

            aIsInitList = false;
        }

        private void InitFistList()
        {
            if (list_BoList.Items.Count <= 0)
            {
                C_PlayInfo.BfListName = "";
                return;
            }

            if (C_PlayInfo.BfListName == "")
            {
                list_BoList.SelectedIndex = 0;
                C_PlayInfo.BfListName = ((DataRowView)list_BoList.SelectedItem)[1].ToString();
                return;
            }

            for (Int32 i = 0; i < list_BoList.Items.Count; i++)
            {
                if (list_BoList.Items[i].ToString() == C_PlayInfo.BfListName)
                {
                    list_BoList.SelectedIndex = i;
                    return;
                }
            }

            list_BoList.SelectedIndex = 0;
            C_PlayInfo.BfListName = ((DataRowView)list_BoList.SelectedItem)[1].ToString();
        }

        private void InitMusicFileList()
        {
            if (list_BoList.SelectedItem == null)
            {
                C_PlayInfo.MusicName = "";
                return;
            }

            Int32 iBoListID;

            iBoListID = (Int32)((DataRowView)list_BoList.SelectedItem)[0];
            String iSqlStr = "SELECT [FilePath] FROM [MusicFile] WHERE [ListID]=" + iBoListID.ToString();
            C_SqlOper.SeleData(iSqlStr, ref dTable_FileList);
            for (Int32 i=0;i<dTable_FileList.Rows.Count;i++)
            {
                if (File.Exists(dTable_FileList.Rows[i][2].ToString()) == false)
                {
                    dTable_FileList.Rows[i].RowError = "文件不存在";
                    dataGV_FileList.RowHeadersWidth = 41;
                }

                dTable_FileList.Rows[i][1] = Path.GetFileNameWithoutExtension(dTable_FileList.Rows[i][2].ToString());
            }
        }

        private void InitFistMusicFile()
        {
            if (dTable_FileList.Rows.Count <= 0)
                return;

            if (C_PlayInfo.MusicName == "")
                return;

            foreach (DataGridViewRow iRow in dataGV_FileList.Rows)
            {
                if (iRow.Cells[1].Value.ToString() == C_PlayInfo.MusicName)
                {
                    dataGV_FileList.CurrentCell = iRow.Cells[1];
                    iRow.Selected = true;
                    break;
                }
            }
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (oFDialog_OneFile.ShowDialog() == DialogResult.OK)
            {
                AddFileListAndPlay(oFDialog_OneFile.FileName, true);
            }
        }

        private void btn_OpenFolder_Click( object sender, EventArgs e )
        {
            if (fDialog_Folder.ShowDialog() == DialogResult.OK)
            {
                String[] iFileNames = Directory.GetFiles(fDialog_Folder.SelectedPath, "*.MP3"
                    , SearchOption.AllDirectories);
                EnumeratorFiles(iFileNames.GetEnumerator());

                iFileNames = Directory.GetFiles(fDialog_Folder.SelectedPath, "*.WMA"
                    , SearchOption.AllDirectories);
                EnumeratorFiles(iFileNames.GetEnumerator());

                iFileNames = Directory.GetFiles(fDialog_Folder.SelectedPath, "*.MID"
                    , SearchOption.AllDirectories);
                EnumeratorFiles(iFileNames.GetEnumerator());

                iFileNames = Directory.GetFiles(fDialog_Folder.SelectedPath, "*.WAV"
                    , SearchOption.AllDirectories);
                EnumeratorFiles(iFileNames.GetEnumerator());

                NextMusic();
            }
        }

        private void EnumeratorFiles( IEnumerator FileList )
        {
            while (FileList.MoveNext())
            {
                AddFileListAndPlay(FileList.Current.ToString(), false);
            }
        }

        private void btn_Play_Click( object sender, EventArgs e )
        {
            if (btn_Play.Tag.ToString() == "播放")
            {
                if (aPlayState == PlayState.Paused || aPlayState == PlayState.Stopped)
                {
                    DirectPlay();
                    return;
                }

                if (dataGV_FileList.CurrentRow == null)
                {
                    btn_OpenFile_Click(null, null);
                    return;
                }

                if (dataGV_FileList.CurrentRow.ErrorText != String.Empty)
                {
                    MessageBox.Show(dataGV_FileList.CurrentRow.ErrorText, "提示");
                    return;
                }

                if (NewMusicFileStream(dataGV_FileList.CurrentRow.Cells[2].Value.ToString()) == false)
                    return;
                this.InitPlay();
                aLastMusicID = aCurrentMusicID;
                aCurrentMusicID = dataGV_FileList.CurrentRow.Index;
            }
            else if (btn_Play.Tag.ToString() == "暂停")
            {
                this.Pause();
            }
        }

        private void btn_Stop_Click( object sender, EventArgs e )
        {
            this.Stop();
        }

        private void btn_Previous_Click( object sender, EventArgs e )
        {
            if (aLastMusicID == -1)
                return;

            if (aLastMusicID == aCurrentMusicID)
            {
                DirectPlay();
                return;
            }

            if (dataGV_FileList.Rows[aLastMusicID] == null)
            {
                NextMusic();
                return;
            }

            if (NewMusicFileStream(dataGV_FileList.Rows[aLastMusicID].Cells[2].Value.ToString()) == false)
            {
                NextMusic();
                return;
            }

            dataGV_FileList.CurrentCell = dataGV_FileList.Rows[aLastMusicID].Cells[0];
            dataGV_FileList.Rows[aLastMusicID].Selected = true;
            aCurrentMusicID = aLastMusicID;
            this.InitPlay();
        }

        private void btn_Next_Click( object sender, EventArgs e )
        {
            if ((aPlayMode == PlayMode.Single)||(aPlayMode == PlayMode.SingleCycle))
            {
                aLastMusicID = aCurrentMusicID;

                Int32 iMusicID = aCurrentMusicID + 1;
                if (iMusicID >= dTable_FileList.Rows.Count)
                {
                    this.Stop();
                    iMusicID = aCurrentMusicID;
                }
                else
                {
                    dataGV_FileList.CurrentCell = dataGV_FileList.Rows[iMusicID].Cells[1];
                    dataGV_FileList.Rows[iMusicID].Selected = true;
                    NewMusicFileStream(dataGV_FileList.Rows[iMusicID].Cells[2].Value.ToString());

                    this.InitPlay();
                }

                aCurrentMusicID = iMusicID;
            }
            NextMusic();
        }

        private void dataGV_FileList_DoubleClick( object sender, EventArgs e )
        {
            if (dataGV_FileList.CurrentRow == null)
                return;
            if (dataGV_FileList.CurrentRow.Index == aCurrentMusicID)
            {
                this.Stop();
                this.DirectPlay();
                return;
            }

            if (NewMusicFileStream(dataGV_FileList.CurrentRow.Cells[2].Value.ToString()) == false)
                return;

            aLastMusicID = aCurrentMusicID;
            aCurrentMusicID = dataGV_FileList.CurrentRow.Index;
            this.InitPlay();
        }

        private void timer_PlayTime_Tick(object sender, EventArgs e)
        {
            if (aMusicPlayers != null)
            {
                TStreamTime iMusicTime = new TStreamTime();
                aMusicPlayers.GetPosition(ref iMusicTime);

                if (((iMusicTime.hms.minute == 0) && (iMusicTime.hms.second == 0) && (iMusicTime.hms.millisecond == 0))
                    || (iMusicTime.sec >= tBar_PlayTime.Maximum))
                {
                    timer_PlayTime.Stop();
                    timer_FFT.Stop();
                    NextMusic();
                }
                else if (iMusicTime.sec <= tBar_PlayTime.Maximum)
                {
                    if (!aLeftButtonDownOnPlayTime)
                    {
                        tBar_PlayTime.Value = (Int32)iMusicTime.sec;
                    }
                }

                lab_PlayTime.Text = String.Format("{0:D2}:{1:D2}", iMusicTime.hms.minute, iMusicTime.hms.second);
                
                if (checkB_Lyrics.Checked)
                {
                    //aFrmLyrics.SetCurrentLyric(lab_PlayTime.Text);
                    aFrm_ShowLyrcs.SetCurrentLyric((Int32)iMusicTime.ms);
                }
            }
        }

        private void tBar_Volume_ValueChanged(object sender, EventArgs e)
        {
            lab_VolumeText.Text = String.Format("音量：{0}%", tBar_Volume.Value);
            if (aMusicPlayers == null)
            {
                return;
            }

            aMusicPlayers.SetPlayerVolume(tBar_Volume.Value, tBar_Volume.Value);
            C_PlayInfo.Volume = tBar_Volume.Value;
        }

        private void comB_PlayMode_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch (comB_PlayMode.SelectedIndex)
            {
                case 0:
                    aPlayMode = PlayMode.Single;
                    break;
                case 1:
                    aPlayMode = PlayMode.SingleCycle;
                    break;
                case 2:
                    aPlayMode = PlayMode.Order;
                    break;
                case 3:
                    aPlayMode = PlayMode.Cycle;
                    break;
                case 4:
                    aPlayMode = PlayMode.Random;
                    break;
            }
            C_PlayInfo.Playmode = aPlayMode;
        }

        private void lab_Volume_Click( object sender, EventArgs e )
        {
            if (lab_Volume.ImageIndex == 0)
            {
                lab_Volume.ImageIndex = 1;
                tBar_Volume.Value = tBar_Volume.Minimum;
            }
            else
            {
                lab_Volume.ImageIndex = 0;
                tBar_Volume.Value = 60;
            }
        }

        private void btn_Clear_Click( object sender, EventArgs e )
        {
            dTable_FileList.Clear();
            dTable_FileList.AcceptChanges();
        }

        private void btn_Del_Click( object sender, EventArgs e )
        {
            if (dataGV_FileList.CurrentRow == null)
                return;

            dataGV_FileList.Rows.Remove(dataGV_FileList.CurrentRow);
        }

        private void MenuItem_Show_Click( object sender, EventArgs e )
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MenuItem_Exit_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void nIcon_Main_MouseClick( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void timer_Init_Tick( object sender, EventArgs e )
        {
            timer_Init.Stop();

            C_PlayInfo.Deserialize();
            InitBoList();
            InitInfo();
            SetState();

            aMusicPlayers = new ZPlay();
            aMusicPlayers.SetPlayerVolume(tBar_Volume.Value, tBar_Volume.Value);
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpGraphType, 0);
            Int32 iFFTpoints = System.Convert.ToInt32(Math.Pow(2, (7 + 2)));
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpFFTPoints, iFFTpoints);
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpWindow, (Int32)(11 + 1));
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpFrequencyScaleVisible, 0);
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpDecibelScaleVisible, 0);
            aMusicPlayers.SetFFTGraphParam(TFFTGraphParamID.gpHorizontalScale, (Int32)TFFTGraphHorizontalScale.gsLinear);
            pic_FFT.Refresh();
        }

        private void Frm_DShowPlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            if (aFrm_ShowLyrcs != null)
            {
                aFrm_ShowLyrcs.Hide();
            }
            Application.DoEvents();
            if ((aMusicPlayers != null) && (aPlayState == PlayState.Running))
            {
                int iVolumeleft = 0;
                int iVolumeright = 0;
                TStreamTime istartpos = new TStreamTime();
                TStreamTime iendpos = new TStreamTime();

                aMusicPlayers.GetPlayerVolume(ref iVolumeleft, ref iVolumeright);
                aMusicPlayers.GetPosition(ref istartpos);
                iendpos.sec = System.Convert.ToUInt32(istartpos.sec + 1);
                aMusicPlayers.SlideVolume(TTimeFormat.tfSecond, ref istartpos, iVolumeleft, iVolumeright, TTimeFormat.tfSecond, ref iendpos, 0, 0);
                System.Threading.Thread.Sleep(1500);
            }
            if (aFrm_ShowLyrcs != null)
            {
                aFrm_ShowLyrcs.Close();
                aFrm_ShowLyrcs.Dispose();
            }
            CloseInterfaces();
            C_PlayInfo.Serialiaze();
        }

        private void InitPlay()
        {
            if (aMusicPlayers == null)
            {
                return;
            }
            Boolean iRet = aMusicPlayers.StartPlayback();
            if (!iRet)
            {
                MessageBox.Show("播放出错！\n" + aMusicPlayers.GetError(), "提示");
                return;
            }

            this.aPlayState = PlayState.Running;
            SetState();
            timer_PlayTime.Start();
            timer_FFT.Start();
        }

        private void DirectPlay()
        {
            if (aMusicPlayers == null)
            {
                return;
            }

            Boolean iRet = aMusicPlayers.StartPlayback();
            if (!iRet)
            {
                MessageBox.Show("播放歌曲出错！\n" + aMusicPlayers.GetError(), "提示");
                return;
            }

            this.aPlayState = PlayState.Running;
            timer_PlayTime.Start();
            timer_FFT.Start();
            SetState();
        }

        private void Pause()
        {
            if (aMusicPlayers == null)
            {
                return;
            }
            aMusicPlayers.PausePlayback();

            this.aPlayState = PlayState.Paused;
            timer_PlayTime.Stop();
            timer_FFT.Stop();
            SetState();
        }

        private void Stop()
        {
            if (aMusicPlayers == null)
            {
                return;
            }

            aMusicPlayers.StopPlayback();

            aPlayState = PlayState.Stopped;
            tBar_PlayTime.Value = 0;
            lab_PlayTime.Text = "00:00";
            timer_PlayTime.Stop();
            timer_FFT.Stop();
            SetState();
        }

        private void NextMusic()
        {
            try
            {
                if (dTable_FileList.Rows.Count <= 0)
                    return;

                aLastMusicID = aCurrentMusicID;

                Int32 iMusicID = 0;
                switch (aPlayMode)
                {
                    case PlayMode.Single:
                        iMusicID = aCurrentMusicID;
                        this.Stop();
                        break;
                    case PlayMode.SingleCycle:
                        this.Stop();
                        this.DirectPlay();
                        iMusicID = aCurrentMusicID;
                        break;
                    case PlayMode.Order:
                        iMusicID = aCurrentMusicID + 1;
                        if (iMusicID >= dTable_FileList.Rows.Count)
                        {
                            this.Stop();
                            iMusicID = aCurrentMusicID;
                        }
                        else
                        {
                            dataGV_FileList.CurrentCell = dataGV_FileList.Rows[iMusicID].Cells[1];
                            dataGV_FileList.Rows[iMusicID].Selected = true;
                            NewMusicFileStream(dataGV_FileList.Rows[iMusicID].Cells[2].Value.ToString());

                            this.InitPlay();
                        }
                        break;
                    case PlayMode.Random:
                        Random iMusicID_Rand = new Random();
                        iMusicID = iMusicID_Rand.Next(0, dTable_FileList.Rows.Count);
                        dataGV_FileList.CurrentCell = dataGV_FileList.Rows[iMusicID].Cells[1];
                        dataGV_FileList.Rows[iMusicID].Selected = true;
                        if (NewMusicFileStream(dataGV_FileList.Rows[iMusicID].Cells[2].Value.ToString()) == false)
                        {
                            NextMusic();
                            return;
                        }

                        this.InitPlay();
                        break;
                    case PlayMode.Cycle:
                        iMusicID = aCurrentMusicID + 1;
                        if (iMusicID >= dTable_FileList.Rows.Count)
                            iMusicID = 0;

                        dataGV_FileList.CurrentCell = dataGV_FileList.Rows[iMusicID].Cells[1];
                        dataGV_FileList.Rows[iMusicID].Selected = true;
                        NewMusicFileStream(dataGV_FileList.Rows[iMusicID].Cells[2].Value.ToString());

                        this.InitPlay();

                        break;
                }
                aCurrentMusicID = iMusicID;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "提示");
                NextMusic();
            }
        }

        private void AddFileListAndPlay( String FileNames, Boolean Play )
        {
            if (File.Exists(FileNames) == false)
                return;

            DataRow iFileRow = dTable_FileList.NewRow();
            iFileRow[1] = Path.GetFileNameWithoutExtension(FileNames);
            iFileRow[2] = FileNames;

            dTable_FileList.Rows.Add(iFileRow);
            if (Play)
            {
                if (NewMusicFileStream(FileNames) == false)
                    return;
                this.InitPlay();
            }
        }

        private Boolean NewMusicFileStream( String FileNames )
        {
            if (!File.Exists(FileNames))
            {
                return false;
            }
            if (aMusicPlayers == null)
            {
                aMusicPlayers = new ZPlay();
            }

            Boolean iRet = aMusicPlayers.Close();
            if (!iRet)
            {
                MessageBox.Show("关闭文件出错！\n" + aMusicPlayers.GetError(), "提示");
                return false;
            }
            TStreamFormat iMusicFileFormat = aMusicPlayers.GetFileFormat(FileNames);
            iRet = aMusicPlayers.OpenFile(FileNames, TStreamFormat.sfAutodetect);
            if (!iRet)
            {
                MessageBox.Show("打开文件出错！\n" + aMusicPlayers.GetError(), "提示");
                return false;
            }

            TStreamInfo iMusicInfo = new TStreamInfo();
            aMusicPlayers.GetStreamInfo(ref iMusicInfo);

            lab_AllTime.Text = String.Format("{0:D2}:{1:D2}", iMusicInfo.Length.hms.minute, iMusicInfo.Length.hms.second);
            lab_PlayTime.Text = "00:00";
            tBar_PlayTime.Maximum = (Int32)iMusicInfo.Length.sec;
            tBar_PlayTime.Value = 0;

            C_PlayInfo.MusicName = Path.GetFileNameWithoutExtension(FileNames);
            TID3InfoEx iMusicID3Info = new TID3InfoEx();
            iRet = aMusicPlayers.LoadID3Ex(ref iMusicID3Info, true);
            if (iRet)
            {
                lab_MusicName.Text = iMusicID3Info.Title + " — " + iMusicID3Info.Artist;
            }
            else
            {
                lab_MusicName.Text = C_PlayInfo.MusicName;
            }

            if (checkB_Lyrics.Checked)
            {
                BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        aFrm_ShowLyrcs.ReadLyricFile(C_PlayInfo.MusicName, iMusicID3Info, true);
                    }
                    ));
            }

            return true;
        }

        private void CloseInterfaces()
        {
            try
            {
                if (aMusicPlayers != null)
                {
                    aMusicPlayers.Close();
                }
            }
            catch
            {
            }
        }

        private void SetState()
        {
            if (aMusicPlayers == null)
            {
                lab_State.Text = String.Format("状态：{0}", "停止");
                btn_Play.Tag = "播放";
                btn_Play.ImageIndex = 2;
                btn_Stop.Enabled = false;
            }
            else
            {
                switch (aPlayState)
                {
                    case PlayState.Init:

                        lab_State.Text = String.Format("状态：{0}", "准备");
                        btn_Play.Tag = "播放";
                        btn_Play.ImageIndex = 2;
                        btn_Stop.Enabled = false;
                        break;
                    case PlayState.Paused:
                        lab_State.Text = String.Format("状态：{0}", "暂停");
                        btn_Play.Tag = "播放";
                        btn_Play.ImageIndex = 2;
                        btn_Stop.Enabled = false;
                        break;
                    case PlayState.Running:
                        lab_State.Text = String.Format("状态：{0}", "播放");
                        btn_Play.Tag = "暂停";
                        btn_Play.ImageIndex = 1;
                        btn_Stop.Enabled = true;
                        break;
                    case PlayState.Stopped:
                        lab_State.Text = String.Format("状态：{0}", "停止");
                        btn_Play.Tag = "播放";
                        btn_Play.ImageIndex = 2;
                        btn_Stop.Enabled = false;
                        break;
                }
            }
        }

        private void list_BoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aIsInitList)
                return;

            InitMusicFileList();
            C_PlayInfo.BfListName = ((DataRowView)list_BoList.SelectedItem)[1].ToString();
        }

        private void MenuItem_NewBfList_Click(object sender, EventArgs e)
        {
            Frm_BfListName iFrm_Name = new Frm_BfListName();
            if (iFrm_Name.ShowDialog() == DialogResult.OK)
            {
                String iSqlStr = "INSERT INTO [PlaysList]([ListName]) VALUES('" + iFrm_Name.txt_Name.Text + "')";
                if (C_SqlOper.OperData(iSqlStr))
                {
                    iSqlStr = "SELECT [ID] FROM [PlaysList] WHERE [ListName]='" + iFrm_Name.txt_Name.Text + "'";
                    object iListID = C_SqlOper.SeleDataObj(iSqlStr);
                    DataRow iBfList = dTable_BfList.NewRow();
                    iBfList[0] = iListID;
                    iBfList[1] = iFrm_Name.txt_Name.Text;
                    dTable_BfList.Rows.Add(iBfList);
                }
            }

            iFrm_Name.Close();
        }

        private void MenuItem_Sava_Click(object sender, EventArgs e)
        {
            if (list_BoList.SelectedItem == null)
            {
                MessageBox.Show("请选择需要保存的播放列表！", "提示");
                list_BoList.Focus();
                return;
            }

            SavaMusicFileList();
        }

        private void SavaMusicFileList()
        {
            DelMusicFileList();
            String iListID = ((DataRowView)list_BoList.SelectedValue)[0].ToString();

            StringBuilder iSqlStrInsert = new StringBuilder();
            foreach (DataRow iRow in dTable_FileList.Rows)
            {
                iSqlStrInsert.Remove(0, iSqlStrInsert.Length);
                iSqlStrInsert.Append("INSERT INTO [MusicFile]([ListID],[FilePath]) VALUES(" + iListID + ",'" + iRow[2].ToString() + "')");
                C_SqlOper.OperData(iSqlStrInsert.ToString());
            }
        }

        private void MenuItem_Del_Click(object sender, EventArgs e)
        {
            if (list_BoList.SelectedItem == null)
            {
                MessageBox.Show("请选择需要删除的播放列表！", "提示");
                list_BoList.Focus();
                return;
            }

            DelMusicFileList();
        }

        private void DelMusicFileList()
        {
            String iListID = ((DataRowView)list_BoList.SelectedValue)[0].ToString();
            String iSqlStr = "DELETE FROM [MusicFile] WHERE [ListID]=" + iListID;
            C_SqlOper.OperData(iSqlStr);
        }

        private void MenuItem_About_Click( object sender, EventArgs e )
        {
            Frm_About iFrm_About = new Frm_About();
            iFrm_About.ShowDialog();
            iFrm_About.Close();
        }

        private void pic_FFT_Paint(object sender, PaintEventArgs e)
        {
            if (aMusicPlayers == null)
            {
                return;
            }

            IntPtr MyDeviceContext = default(IntPtr);
            MyDeviceContext = e.Graphics.GetHdc();
            Boolean iRet = aMusicPlayers.DrawFFTGraphOnHDC(MyDeviceContext, 0, 0, pic_FFT.Width, pic_FFT.Height);
            if (!iRet)
            {
                MessageBox.Show(aMusicPlayers.GetError());
            }
            e.Graphics.ReleaseHdc(MyDeviceContext);
        }

        private void timer_FFT_Tick(object sender, EventArgs e)
        {
            pic_FFT.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case WM_MOVE:
                        {
                            if (checkB_Lyrics.Checked && (aFrm_ShowLyrcs != null))
                            {
                                aFrm_ShowLyrcs.Left = this.Left + this.Width;
                                aFrm_ShowLyrcs.Top = this.Top;
                                return;
                            }
                            break;
                        }
                    case WM_ACTIVATE:
                        {
                            if (((Int32)m.WParam) != WA_INACTIVE)
                            {
                                if (checkB_Lyrics.Checked && (aFrm_ShowLyrcs != null))
                                {
                                    aFrm_ShowLyrcs.Left = this.Left + this.Width;
                                    aFrm_ShowLyrcs.Top = this.Top;
                                    aFrm_ShowLyrcs.Show();
                                    aFrm_ShowLyrcs.Focus();
                                    this.Focus();
                                }
                            }
                            break;
                        }
                    case WM_SIZE:
                        {
                            if (((Int32)m.WParam) == SIZE_MINIMIZED)
                            {
                                this.Hide();
                            }
                            break;
                        }
                }

                base.WndProc(ref m);
            }
            catch
            {
            }
        }

        private void tBar_PlayTime_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                aLeftButtonDownOnPlayTime = true;
            }
        }

        private void tBar_PlayTime_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                aLeftButtonDownOnPlayTime = false;
                if (aMusicPlayers == null)
                {
                    return;
                }

                TStreamTime iMusicPosition = new TStreamTime();
                iMusicPosition.sec = (UInt32)tBar_PlayTime.Value;
                aMusicPlayers.Seek(TTimeFormat.tfSecond, ref iMusicPosition, TSeekMethod.smFromBeginning);
            }
        }

        private void checkB_Lyrics_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB_Lyrics.Checked)
            {
                if (aFrm_ShowLyrcs == null)
                {
                    aFrm_ShowLyrcs = new Frm_ShowLyrics();
                }
                if ((aPlayState == PlayState.Paused) || (aPlayState == PlayState.Running))
                {
                    aFrm_ShowLyrcs.ReadLyricFile(C_PlayInfo.MusicName, new TID3InfoEx(), false);
                }
                aFrm_ShowLyrcs.Left = this.Left + this.Width;
                aFrm_ShowLyrcs.Top = this.Top;
                aFrm_ShowLyrcs.Height = this.Height;
                aFrm_ShowLyrcs.Show();
                this.Focus();
            }
            else
            {
                if (aFrm_ShowLyrcs != null)
                {
                    aFrm_ShowLyrcs.Close();
                    aFrm_ShowLyrcs.Dispose();
                    aFrm_ShowLyrcs = null;
                }
            }
        }
    }
}
