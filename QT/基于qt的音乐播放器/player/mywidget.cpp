#include "mywidget.h"
#include "ui_mywidget.h"
#include "myplaylist.h"
#include "mylrc.h"
#include <QLabel>
#include <QToolBar>
#include <QVBoxLayout>
#include <QTime>
#include <QMessageBox>
#include <QFileInfo>
#include <QFileDialog>
#include <QDesktopServices>
#include <QTextCodec>
#include <QMenu>
#include <QCloseEvent>

MyWidget::MyWidget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::MyWidget)
{
    ui->setupUi(this);
    InitPlayer();
}

MyWidget::~MyWidget()
{
    delete ui;
}

//��ʼ��������
void MyWidget::InitPlayer()
{
    //���ô��ڻ�������
    setWindowTitle(tr("MyPlayer���ֲ�����"));
    setWindowIcon(QIcon(":/images/icon.png"));//����Դ�ļ�����ͼ��
    setMinimumSize(320, 160);
    setMaximumSize(320, 160);//�����С����Ϊһ���������ı䲥�������ڵĴ�С

    //����ý�����
    media_object = new Phonon::MediaObject(this);
    Phonon::AudioOutput *audio_output = new Phonon::AudioOutput(Phonon::MusicCategory, this);
    Phonon::createPath(media_object, audio_output);//��Դ�ͽ�����

    //����ý������tick�ź������²���ʱ�����ʾ
    connect(media_object, SIGNAL(tick(qint64)), this, SLOT(UpdateTime(qint64)));

    //����������ǩ
    top_label = new QLabel(tr("<a href=\"http://www.cnblogs.com/tornadomeet/\">http://www.cnblogs.com/tornadomeet/</a>"));
    top_label->setTextFormat(Qt::RichText);
    top_label->setOpenExternalLinks(true);//���е�������ⲿ����
    top_label->setAlignment(Qt::AlignCenter);

    //�������Ʋ��Ž��ȵĻ���
    Phonon::SeekSlider *seek_slider = new Phonon::SeekSlider(media_object, this);

    //������ʾʱ��ı�ǩ
    QToolBar *widget_bar = new QToolBar(this);
    time_label = new QLabel(tr("00:00/00:00"), this);
    time_label->setToolTip(tr("��ǰʱ��/��ʱ��"));
    time_label->setAlignment(Qt::AlignCenter);
    //QSizePolicy��������ˮƽ�ʹ�ֱ�޸Ĵ�С���Ե�һ������
    time_label->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Fixed);//ˮƽ�����ϳߴ����չ��ˮƽ�����ѹ̶�

    //�����б�������ͼ��
    QAction *PLAction = new QAction(tr("PL"), this);
    PLAction->setShortcut(QKeySequence("F4"));//���ÿ��������б�Ŀ�ݼ�ΪF4
    PLAction->setToolTip(tr("�����б�(F4)"));
    connect(PLAction, SIGNAL(triggered()), this, SLOT(SetPlayListShown()));//���Ӵ����ź�

    //��������ʾ��������ͼ��
    QAction *LRCAction = new QAction(tr("LRC"), this);
    LRCAction->setShortcut(QKeySequence("F2"));//���ÿ��������ʵĲ����б��ݼ�ΪF2
    LRCAction->setToolTip(tr("������(F2)"));
    connect(LRCAction, SIGNAL(triggered()), this, SLOT(SetLrcShown()));

    //������2��action��1��widget��ӵ���������Ĭ�ϵ���ӷ�ʽΪˮƽ�������
    widget_bar->addAction(PLAction);
    widget_bar->addSeparator();
    widget_bar->addWidget(time_label);
    widget_bar->addSeparator();
    widget_bar->addAction(LRCAction);
    widget_bar->addSeparator();

    //���ò��Ŷ���
    QToolBar *tool_bar = new QToolBar(this);//�ù��캯��û��д������
    play_action = new QAction(this);
    play_action->setIcon(QIcon(":/images/play.png"));
    play_action->setText(tr("����(F5)"));
    play_action->setShortcut(QKeySequence("F5"));//���ŵĿ�ݼ�λF5
    connect(play_action, SIGNAL(triggered()), this, SLOT(SetPaused()));

    //����ֹͣ����
    stop_action = new QAction(this);
    stop_action->setIcon(QIcon(":/images/stop.png"));
    stop_action->setText(tr("ֹͣ(F6)"));
    stop_action->setShortcut(QKeySequence("F6"));
    connect(stop_action, SIGNAL(triggered()), this, SLOT(stop()));

    //������һ�׶���
    skip_backward_action = new QAction(this);
    skip_backward_action->setIcon(QIcon(":/images/skipBackward.png"));
    skip_backward_action->setText(tr("��һ��(Ctrl+Left)"));
    skip_backward_action->setShortcut(QKeySequence("Ctrl+Left"));
    connect(skip_backward_action, SIGNAL(triggered()), this, SLOT(SkipBackward()));

    //������һ�׶���
    skip_forward_action = new QAction(this);
    skip_forward_action->setIcon(QIcon(":/images/skipForward.png"));
    skip_forward_action->setText(tr("��һ��(Ctrl+Right)"));
    skip_forward_action->setShortcut(QKeySequence("Ctrl+Right"));
    connect(skip_forward_action, SIGNAL(triggered()), this, SLOT(SkipForward()));

    //���ô��ļ�����
    QAction *open_action = new QAction(this);
    open_action->setIcon(QIcon(":/images/open.png"));
    open_action->setText(tr("�����ļ�(Ctrl+O)"));
    open_action->setShortcut(QKeySequence("Ctrl+O"));
    open_action->setEnabled(true);
    connect(open_action, SIGNAL(triggered()), this, SLOT(OpenFile()));

    //���ֿ��Ʋ���
    Phonon::VolumeSlider *volume_slider = new Phonon::VolumeSlider(audio_output, this);
    volume_slider->setSizePolicy(QSizePolicy::Maximum, QSizePolicy::Maximum);

    //�����ϲ�����ӵ�������
    tool_bar->addAction(play_action);
    tool_bar->addSeparator();
    tool_bar->addAction(stop_action);
    tool_bar->addSeparator();
    tool_bar->addAction(skip_backward_action);
    tool_bar->addSeparator();
    tool_bar->addAction(skip_forward_action);
    tool_bar->addSeparator();
    tool_bar->addWidget(volume_slider);
    tool_bar->addSeparator();
    tool_bar->addAction(open_action);

    //���������������
    QVBoxLayout *main_layout = new QVBoxLayout;
    main_layout->addWidget(top_label);
    main_layout->addWidget(seek_slider);
    main_layout->addWidget(widget_bar);
    main_layout->addWidget(tool_bar);
    setLayout(main_layout);


  //  //����ý�岿������Դ
   // media_object->setCurrentSource(Phonon::MediaSource("./music.mp3"));

    //ÿ��ý������״̬�����ı�ʱ���ͻ��Զ�����stateChanged()�ź�,������źź󣬾Ϳ�������Щ״̬������һЩ�йص�����
    connect(media_object, SIGNAL(stateChanged(Phonon::State, Phonon::State)),
            this, SLOT(StateChanged(Phonon::State, Phonon::State)));

    playlist = new MyPlaylist(this);
    //cellClicked()�ź��ǵ�����е�һ��cell��Ԫ������ʱ�����ġ�
    connect(playlist, SIGNAL(cellClicked(int,int)), this, SLOT(TableClicked(int)));
    connect(playlist, SIGNAL(play_list_clean()), this, SLOT(ClearSources()));

    meta_information_resolver = new Phonon::MediaObject(this);
    Phonon::AudioOutput *meta_information_audio_output =
            new Phonon::AudioOutput(Phonon::MusicCategory, this);
    Phonon::createPath(meta_information_resolver, meta_information_audio_output);
    connect(meta_information_resolver, SIGNAL(stateChanged(Phonon::State,Phonon::State)),
            this, SLOT(MetaStateChanged(Phonon::State,Phonon::State)));
    connect(media_object, SIGNAL(currentSourceChanged(Phonon::MediaSource)),
            this, SLOT(SourceChanged(Phonon::MediaSource)));
    connect(media_object, SIGNAL(aboutToFinish()), media_object, SLOT(AboutToFinish()));
    play_action->setEnabled(false);
    stop_action->setEnabled(false);
    skip_forward_action->setEnabled(false);
    skip_backward_action->setEnabled(false);
    top_label->setFocus();

    lrc = new MyLrc(this);

    // ����ϵͳ����ͼ��
   tray_icon = new QSystemTrayIcon(QIcon(":/images/icon.png"), this);
   tray_icon->setToolTip(tr("�������ֲ�����"));
   // �����˵�,ϵͳ����ͼ����һ����ֵĲ˵�
   QMenu *menu = new QMenu;
   QList<QAction *> actions;
   actions << play_action << stop_action << skip_backward_action << skip_forward_action;
   menu->addActions(actions);
   menu->addSeparator();
   menu->addAction(PLAction);
   menu->addAction(LRCAction);
   menu->addSeparator();
   menu->addAction(tr("�˳�"), qApp, SLOT(quit()));
   tray_icon->setContextMenu(menu);
   // ����ͼ�걻�������д���
   connect(tray_icon, SIGNAL(activated(QSystemTrayIcon::ActivationReason)),
           this, SLOT(TrayIconActivated(QSystemTrayIcon::ActivationReason)));
   // ��ʾ����ͼ��
   tray_icon->show();
}


// ����ý��Դ�б����ݺ͵�ǰý��Դ��λ�����ı�������ͼ���״̬
void MyWidget::change_action_state()
{
    // ���ý��Դ�б�Ϊ��
    if (sources.count() == 0) {
        // ���û���ڲ��Ÿ������򲥷ź�ֹͣ��ť��������
        //����Ϊ���ܸ������ڲ���ʱ����˲����б�
        if (media_object->state() != Phonon::PlayingState &&
                media_object->state() != Phonon::PausedState) {
            play_action->setEnabled(false);
            stop_action->setEnabled(false);
        }
        skip_backward_action->setEnabled(false);
        skip_forward_action->setEnabled(false);
    }
    else { // ���ý��Դ�б�Ϊ��
        play_action->setEnabled(true);
        stop_action->setEnabled(true);
        // ���ý��Դ�б�ֻ��һ��
        if (sources.count() == 1) {
            skip_backward_action->setEnabled(false);
            skip_forward_action->setEnabled(false);
        } else { // ���ý��Դ�б��ж���
            skip_backward_action->setEnabled(true);
            skip_forward_action->setEnabled(true);
            int index = playlist->currentRow();
            // ��������б�ǰѡ�е���Ϊ��һ��
            if (index == 0)
                skip_backward_action->setEnabled(false);
            // ��������б�ǰѡ�е���Ϊ���һ��
            if (index + 1 == sources.count())
                skip_forward_action->setEnabled(false);
        }
    }
}


// ����LRC��ʣ���stateChanged()������Phonon::PlayingState����aboutToFinish()�����е����˸ú���
void MyWidget::resolve_lrc(const QString &source_file_name)
{
    lrc_map.clear();
    if(source_file_name.isEmpty())
        return;
    QString file_name = source_file_name;
    QString lrc_file_name = file_name.remove(file_name.right(3)) + "lrc";//����Ƶ�ļ��ĺ�׺�ĳ�lrc��׺

    // �򿪸���ļ�
    QFile file(lrc_file_name);
    if (!file.open(QIODevice::ReadOnly)) {
        lrc->setText(QFileInfo(media_object->currentSource().fileName()).baseName()
                     + tr(" --- δ�ҵ�����ļ���"));
        return ;
    }
    // �����ַ�������
    QTextCodec::setCodecForCStrings(QTextCodec::codecForLocale());
    QString all_text = QString(file.readAll());
    file.close();
    // ����ʰ��зֽ�Ϊ����б�
    QStringList lines = all_text.split("\n");

    //�����ʱ���ǩ�ĸ�ʽ[00:05.54]
    //������ʽd{2}��ʾƥ��2������
    QRegExp rx("\\[\\d{2}:\\d{2}\\.\\d{2}\\]");
    foreach(QString oneline, lines) {
        QString temp = oneline;
        temp.replace(rx, "");//�ÿ��ַ����滻������ʽ����ƥ��ĵط�,�����ͻ���˸���ı�
        // Ȼ�����λ�ȡ��ǰ���е�����ʱ���ǩ�����ֱ������ı�����QMap��
        //indexIn()Ϊ���ص�һ��ƥ���λ�ã��������Ϊ-1�����ʾû��ƥ��ɹ�
        //���������pos����Ӧ�ö�Ӧ���Ǹ���ļ�
        int pos = rx.indexIn(oneline, 0);
        while (pos != -1) { //��ʾƥ��ɹ�
            QString cap = rx.cap(0);//���ص�0�����ʽƥ�������
            // ��ʱ���ǩת��Ϊʱ����ֵ���Ժ���Ϊ��λ
            QRegExp regexp;
            regexp.setPattern("\\d{2}(?=:)");
            regexp.indexIn(cap);
            int minute = regexp.cap(0).toInt();
            regexp.setPattern("\\d{2}(?=\\.)");
            regexp.indexIn(cap);
            int second = regexp.cap(0).toInt();
            regexp.setPattern("\\d{2}(?=\\])");
            regexp.indexIn(cap);
            int millisecond = regexp.cap(0).toInt();
            qint64 totalTime = minute * 60000 + second * 1000 + millisecond * 10;
            // ���뵽lrc_map��
            lrc_map.insert(totalTime, temp);
            pos += rx.matchedLength();
            pos = rx.indexIn(oneline, pos);//ƥ��ȫ��
        }
    }
    // ���lrc_mapΪ��
    if (lrc_map.isEmpty()) {
        lrc->setText(QFileInfo(media_object->currentSource().fileName()).baseName()
                     + tr(" --- ����ļ����ݴ���"));
        return;
    }
}


void MyWidget::UpdateTime(qint64 time)
{
    qint64 total_time_value = media_object->totalTime();//ֱ�ӻ�ȡ����Ƶ�ļ�����ʱ����������λΪ����
    //��3�������ֱ������ʱ���֣��룻60000����Ϊ1���ӣ����Է��ӵڶ����������ȳ�6000,��3��������ֱ�ӳ�1s
    QTime total_time(0, (total_time_value/60000)%60, (total_time_value/1000)%60);
    QTime current_time(0, (time/60000)%60, (time/1000)%60);//��������time���������˵�ǰ��ʱ��
    QString str = current_time.toString("mm:ss") + "/" + total_time.toString("mm:ss");
    time_label->setText(str);

    // ��ȡ����ʱ���Ӧ�ĸ��
    if(!lrc_map.isEmpty()) {
        // ��ȡ��ǰʱ���ڸ���е�ǰ������ʱ���
        qint64 previous = 0;
        qint64 later = 0;
        //keys()��������lrc_map�б�
        foreach (qint64 value, lrc_map.keys()) {
            if (time >= value) {
                previous = value;
            } else {
                later = value;
                break;
            }
        }

        // �ﵽ���һ��,��later����Ϊ������ʱ���ֵ
        if (later == 0)
            later = total_time_value;

        // ��ȡ��ǰʱ������Ӧ�ĸ������
        QString current_lrc = lrc_map.value(previous);

//        // û������ʱ
//        if(current_lrc.length() < 2)
//            current_lrc = tr("�������ֲ�����");

        // ������µ�һ�и�ʣ���ô���¿�ʼ��ʾ�������
        if(current_lrc != lrc->text()) {
            lrc->setText(current_lrc);
            top_label->setText(current_lrc);
            qint64 interval_time = later - previous;
            lrc->start_lrc_mask(interval_time);
        }
    } else {  // ���û�и���ļ������ڶ�����ǩ����ʾ��������
        top_label->setText(QFileInfo(media_object->
                                    currentSource().fileName()).baseName());
    }
}


void MyWidget::SetPaused()
{
    if(media_object->state() == Phonon::PlayingState) {
        media_object->pause();
    }
    else
        media_object->play();
}


//������һ�׸���
void MyWidget::SkipBackward()
{
    lrc->stop_lrc_mask();
    int index = sources.indexOf(media_object->currentSource());
    media_object->setCurrentSource(sources.at(index - 1));
    media_object->play();
}

//������һ�׸���
void MyWidget::SkipForward()
{
    lrc->stop_lrc_mask();
    int index = sources.indexOf(media_object->currentSource());
    media_object->setCurrentSource(sources.at(index + 1));
    media_object->play();
}


void MyWidget::OpenFile()
{
    //����ͬʱ�򿪶����Ƶ�ļ�
    QStringList list = QFileDialog::getOpenFileNames(this, tr("�������ļ�"),
                                                     QDesktopServices::storageLocation(QDesktopServices::MusicLocation));
    if(list.isEmpty())
        return;
    //��ȡ��ǰý��Դ�б�Ĵ�С
    int index = sources.size();
    foreach(QString string, list) {
        Phonon::MediaSource source(string);
        sources.append(source);
    }
    if(!sources.isEmpty()) {
        //���ý��Դ�б�Ϊ�գ����¼���ĵ�һ��ý��Դ��Ϊ��ǰý��Դ
        meta_information_resolver->setCurrentSource(sources.at(index));
    }
}


void MyWidget::SetPlayListShown()
{
    if(playlist->isHidden()) {
        playlist->move(frameGeometry().bottomLeft());//��ʾ����������·�
        playlist->show();
    }
    else {
        playlist->hide();
    }
}


void MyWidget::SetLrcShown()
{
    if(lrc->isHidden())
        lrc->show();
    else
        lrc->hide();
}

void MyWidget::StateChanged(Phonon::State new_state, Phonon::State old_state)
{
    switch(new_state)
    {
        //����״̬ʱ����״̬ʱ�������������������ʾ��������������Ϣ�򣬷�����ʾ��ͨ������Ϣ��
        case Phonon::ErrorState:
            if(media_object->errorType() == Phonon::FatalError) {
                QMessageBox::warning(this, tr("��������"), media_object->errorString());//��ʾ����������
            }
            else {
                QMessageBox::warning(this, tr("����"), media_object->errorString());//��ʾ��ͨ����
            }
            break;
        //����״̬Ϊ����״̬ʱ,����һЩ״̬�Ŀؼ�
        case Phonon::PlayingState:
            stop_action->setEnabled(true);
            play_action->setIcon(QIcon(":/images/pause.png"));
            play_action->setText(tr("��ͣ(F5)"));
            //���ĵ�һ�еı�ǩ����Ϊ�����ļ����ļ�����ע��baseName����QFileInfo�ĺ���
            top_label->setText(QFileInfo(media_object->currentSource().fileName()).baseName());
            resolve_lrc(media_object->currentSource().fileName());
            break;
        case Phonon::StoppedState:
            stop_action->setEnabled(false);
            play_action->setIcon(QIcon(":/images/play.png"));
            //setText����ʵ�ֵĹ��ܸо���setToolTipһ��,ֻ���������ù��˵��ı������action��Ӧ���˵����������ʾ����
            play_action->setText(tr("����(F5)"));
            top_label->setText(tr("<a href=\"http://www.cnblogs.com/tornadomeet/\">http://www.cnblogs.com/tornadomeet/</a>"));
            time_label->setText(tr("00:00/00:00"));
            lrc->stop_lrc_mask();
            lrc->setText(tr("�������ֲ�����"));
            break;
        case Phonon::PausedState:
            stop_action->setEnabled(true);
            play_action->setIcon(QIcon(":/images/play.png"));
            play_action->setText(tr("����(F5)"));
            top_label->setText(QFileInfo(media_object->currentSource().fileName()).baseName() + tr(" ����ͣ!"));
            // ����ø����и���ļ�
            if (!lrc_map.isEmpty()) {
                lrc->stop_lrc_mask();
                lrc->setText(top_label->text());
            }
            break;
        case Phonon::BufferingState:
            break;
        default:
        ;
    }
}


//�òۺ����ǵ�ý��Դ�����ı�ʱ������currentSourceChanged()�ź�,�Ӷ�ִ�иòۺ���
//�ú�����ɵĹ�����ѡ�����ı��ý��Դ��һ��
void MyWidget::SourceChanged(const Phonon::MediaSource &source)
{
    int index = sources.indexOf(source);
    playlist->selectRow(index);
    change_action_state();
}


//��ý�岥�ſ����ʱ���ᷢ��aboutToFinish()�źţ��Ӷ������òۺ���
void MyWidget::AboutToFinish()
{
    int index = sources.indexOf(media_object->currentSource())+1;
    if(sources.size() > index) {
        media_object->enqueue(sources.at(index));//����һ�׸�����ӵ������б���
        media_object->seek(media_object->totalTime());//������ǰ���������
        lrc->stop_lrc_mask();
        resolve_lrc(sources.at(index).fileName());
    }
    else {
        media_object->stop();//����Ѿ��Ǵ���Ƶ�ļ������һ�׸��ˣ���ֱ��ֹͣ
    }

}


void MyWidget::MetaStateChanged(Phonon::State new_state, Phonon::State old_state)
{
    // ����״̬�����ý��Դ�б��г�ȥ����ӵ�ý��Դ
    if(new_state == Phonon::ErrorState) {
        QMessageBox::warning(this, tr("���ļ�ʱ����"), meta_information_resolver->errorString());
        //takeLast()Ϊɾ�����һ�в����䷵��
        while (!sources.isEmpty() &&
               !(sources.takeLast() == meta_information_resolver->currentSource()))
        {};//ֻ�������һ��
        return;
    }
    // ����Ȳ�����ֹͣ״̬Ҳ��������ͣ״̬����ֱ�ӷ���
    if(new_state != Phonon::StoppedState && new_state != Phonon::PausedState)
        return;
    // ���ý��Դ���ʹ�����ֱ�ӷ���
    if(meta_information_resolver->currentSource().type() == Phonon::MediaSource::Invalid)
        return;

    QMap<QString, QString> meta_data = meta_information_resolver->metaData();//��ȡý��Դ�е�Դ����

    //��ȡ�ļ�������Ϣ
    QString title = meta_data.value("TITLE");
    //���ý��Ԫ������û�б�����Ϣ����ȥ����Ƶ�ļ����ļ���Ϊ�ñ�����Ϣ
    if(title == "") {
        QString str = meta_information_resolver->currentSource().fileName();
        title = QFileInfo(str).baseName();
    }
    QTableWidgetItem *title_item = new QTableWidgetItem(title);
    title_item->setFlags(title_item->flags() ^ Qt::ItemIsEditable);

    //��ȡ��������Ϣ
    QTableWidgetItem *artist_item = new QTableWidgetItem(meta_data.value("ARTIST"));
    artist_item->setFlags(artist_item->flags() ^ Qt::ItemIsEditable);

    //��ȡ��ʱ����Ϣ
    qint64 total_time  = meta_information_resolver->totalTime();
    QTime time(0, (total_time/60000)%60, (total_time/10000)%60);
    QTableWidgetItem *time_item = new QTableWidgetItem(time.toString("mm:ss"));

    //���벥���б�
    int current_rows = playlist->rowCount();//�����б��е�����
    playlist->insertRow(current_rows);
    playlist->setItem(current_rows, 0, title_item);
    playlist->setItem(current_rows, 1, artist_item);
    playlist->setItem(current_rows, 2, time_item);

    //sourcesΪ�򿪵�������Ƶ�ļ��б�,playlistΪ���ֲ����б������
    int index = sources.indexOf(meta_information_resolver->currentSource())+1;
    if(sources.size() > index) //û�н�����
        meta_information_resolver->setCurrentSource(sources.at(index));
    else {
        //û�б�ѡ�е���
        if(playlist->selectedItems().isEmpty()) {
            // �������û�в��Ÿ��������õ�һ��ý��ԴΪý�����ĵ�ǰý��Դ
            //����Ϊ�������ڲ��Ÿ���ʱ����˲����б�Ȼ����������µ��б�
            if(media_object->state() != Phonon::PlayingState && media_object->state() != Phonon::PausedState)
                media_object->setCurrentSource(sources.at(0));
            else {
                //������ڲ��Ÿ�������ѡ�в����б�ĵ�һ����Ŀ,������ͼ��״̬
                playlist->selectRow(0);
                change_action_state();
            }
        }
        else {
            // ��������б�����ѡ�е��У���ôֱ�Ӹ���ͼ��״̬
            change_action_state();
        }
    }


}


void MyWidget::TableClicked(int row)
{
    bool was_palying = media_object->state() == Phonon::PlayingState;
    media_object->stop();//ֹͣ��ǰ���ŵĸ���
    media_object->clearQueue();//������Ŷ���

    //������͵Ĳ����б��кű�ý��Դ���б��кŻ�����ֱ�ӷ���
    if(row >= sources.size())
        return;
    media_object->setCurrentSource(sources.at(row));
    if(was_palying)//���ѡ��ǰ�ڲ��Ÿ�������ôѡ�к�Ҳ�������Ÿ���
        media_object->play();
}


void MyWidget::ClearSources()
{
    sources.clear();
    change_action_state();
}


//ϵͳ����ͼ�걻����
void MyWidget::TrayIconActivated(QSystemTrayIcon::ActivationReason activation_reason)
{
    if(activation_reason == QSystemTrayIcon::Trigger)
        show();
}


//�ر��¼�������
void MyWidget::closeEvent(QCloseEvent *event)
{
    if(isVisible()) {
        hide();//�����ر�ʱ�������û�йر�����������������ϵͳͼ����
        tray_icon->showMessage(tr("�������ֲ�����"), tr("���������»ص�������"));//�����ʾ�е������������ʾ
        event->ignore();//�����͹ر��ź�
    }
}
