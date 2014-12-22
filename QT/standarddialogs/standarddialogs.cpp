#include "standarddialogs.h"
#include<qtextcodec.h>
/*
 * #include<qtextcodec.h>
 * 中文补丁*/


//QString filepath;
QString file_full, file_name, file_path;
double xpercent;
double ypercent;
QImage *img = new QImage;
QFileInfoList list;
QFileInfo fileInfo;
int pc;


StandardDialogs::StandardDialogs( QWidget *parent, Qt::WindowFlags  f )
    : QWidget( parent, f )
{
    QTextCodec *codec = QTextCodec::codecForName("UTF-8");
    QTextCodec::setCodecForLocale(codec);
    QTextCodec::setCodecForCStrings(codec);
    QTextCodec::setCodecForTr(codec);

    setWindowTitle(tr("图片浏览器"));

    Alayout = new QGridLayout( this );
    Dlayout = new QGridLayout();
    //Llayout = new QGridLayout();
    //Rlayout = new QGridLayout();
    Playout = new QGridLayout();

    fileTButton = new QToolButton();
    fileTButton->setText(tr("打开文件"));
    ChangeTButton = new QToolButton();
    ChangeTButton->setText("改变显示大小");
    //BigTButton = new QToolButton();
    //BigTButton->setText("放大");
    //SmallTButton = new QToolButton();
    //SmallTButton->setText("缩小");
    LeftTButton = new QToolButton();
    LeftTButton->setText("左旋转");
    RightTButton = new QToolButton();
    RightTButton->setText("右旋转");
    BackTButton = new QToolButton();
    BackTButton->setText("前一张");
    NextTButton = new QToolButton();
    NextTButton->setText("下一张");
    DelTButton = new QToolButton();
    DelTButton->setText("删除");
    SlideTButton = new QToolButton();
    SlideTButton->setText("幻灯片播映");

    toolbar = new QToolBar();
    toolbar->addWidget( fileTButton );
    toolbar->addWidget( ChangeTButton );
    //toolbar->addWidget( SmallTButton );
    //toolbar->addWidget( BigTButton );
    toolbar->addWidget( LeftTButton );
    toolbar->addWidget( RightTButton );
    toolbar->addWidget( BackTButton );
    toolbar->addWidget( NextTButton );
    toolbar->addWidget( DelTButton );
    toolbar->addWidget( SlideTButton );

    Dlayout->addWidget( toolbar, 0, 0 );

    label = new QLabel();
    label->setMinimumSize( this->width() * 0.8, this->height() * 0.8);
    Playout->addWidget( label, 0, 1);
    //Playout->addWidget( image, 0, 0);

    NextButton = new QPushButton();
    NextButton->setText("下一张");
    BackButton = new QPushButton();
    BackButton->setText("上一张");
    Playout->addWidget( BackButton, 0, 0);
    Playout->addWidget( NextButton, 0, 2);
    Dlayout->setSizeConstraint(QLayout::SetFixedSize);
    //Alayout->addLayout( Llayout, 0, 0);
    Alayout->addLayout( Playout, 0, 0);
    //Alayout->addLayout( Rlayout, 0, 2);
    Alayout->addLayout( Dlayout, 1, 0, 1, 1, 0);
    //Alayout->setSizeConstraint(QLayout::SetFixedSize);
    Alayout->setMargin(10);
    Alayout->setSpacing(10);
    this->setLayout(Alayout);
    //this->resize( QSize( 800, 600 ));
    //showMaximized();
/*
    QDir qDir;
    QString pathName;
    QString picName;
    //QPixmap *pixmap;
    pathName = qDir.currentPath();
    picName = pathName + "/LOGO.png";
    QMessageBox::information(this,"图片路径", picName);
    */

    connect(fileTButton, SIGNAL(clicked()), this, SLOT(slotOpenFileDlg()));
    connect(DelTButton, SIGNAL(clicked()), this, SLOT(slotDelFileDlg()));
    connect(ChangeTButton, SIGNAL(clicked()), this, SLOT(slotChangeFileDlg()));
    connect(LeftTButton, SIGNAL(clicked()), this, SLOT(slotLeftFileDlg()));
    connect(RightTButton, SIGNAL(clicked()), this, SLOT(slotRightFileDlg()));
    connect(BackTButton, SIGNAL(clicked()), this, SLOT(slotBackFileDlg()));
    connect(BackButton, SIGNAL(clicked()), this, SLOT(slotBackFileDlg()));
    connect(NextTButton, SIGNAL(clicked()), this, SLOT(slotNextFileDlg()));
    connect(NextButton, SIGNAL(clicked()), this, SLOT(slotNextFileDlg()));
    connect(SlideTButton, SIGNAL(clicked()), this, SLOT(slotSlideFileDlg()));

    //connect(BigTButton,SIGNAL(clicked()),this,SLOT(slotBigFileDlg()));
    //connect(SmallTButton,SIGNAL(clicked()),this,SLOT(slotSmallFileDlg()));


    QPixmap img("./LOGO.png");
    this->label->setPixmap(img);
}

StandardDialogs::~StandardDialogs()
{
}


void StandardDialogs::slotOpenFileDlg()
{
    /*
    QString s = QFileDialog::getOpenFileName(
    this, "选择图片文件",
        "/",
        "图片文件 (*.png;*.jpg;*.gif);;全部文件 (*.*)");*/

    //QMessageBox::information(this,"图片路径", s);

    QFileInfo fi;

    file_full = QFileDialog::getOpenFileName(this, "选择图片文件",
                "/",
                "图片文件 (*.png;*.jpg;*.gif);;全部文件 (*.*)");

    fi = QFileInfo(file_full);
    file_name = fi.fileName();
    file_path = fi.absolutePath();

    QDir picdir(file_path);
    QStringList filters;
    QString filename;
    filters << "*.bmp" << "*.jpg" << "*.png" << "*.gif";
    picdir.setNameFilters(filters);
    list = picdir.entryInfoList();
    for (int i = 0; i < list.size(); ++i)
    {
        fileInfo = list.at(i);
        filename = qPrintable(QString("%1").arg(fileInfo.fileName()));
        if(filename == file_name)
        {
            pc = i;
            //QMessageBox::information( this,"提示", qPrintable(QString("%1").arg(pc)) );
        }
        //QMessageBox::information( this,"提示", filename );
    }

    img->load(file_full);
    QImage *imgScaled = new QImage;
    *imgScaled = img->scaled(label->width(), label->height(), Qt::KeepAspectRatio);
    label->setPixmap(QPixmap::fromImage(*imgScaled));
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
    setWindowTitle(QString("%1--%2--%3%4%5").arg("图片浏览器").arg(file_name).arg("有").arg(list.size()).arg("张图片"));
    //label->setPixmap(img);
    //filepath = s;
    //fileLineEdit->setText( s.toAscii() );
}

void StandardDialogs::slotDelFileDlg()
{
    switch (QMessageBox::question(this, "警告", tr("是否删除这张图片！"), QMessageBox::Ok | QMessageBox::Cancel))
    {
    case QMessageBox::Ok:
        QFile::remove(file_full);//刪除文件
        QMessageBox::information(this, "提示", "已删除~");
        break;
    default:
        break;
    }
}
void StandardDialogs::slotChangeFileDlg()
{
    bool ok;
    double dx = QInputDialog::getDouble(this, "长度缩放比例：", "请输入x的缩放比例单位：%", 100.00, 0, 1000.00, 1, &ok);
    if(ok)
        xpercent = dx / 100;

    double dy = QInputDialog::getDouble(this, "宽度缩放比例：", "请输入y的缩放比例单位：%", 100.00, 0, 1000.00, 1, &ok);
    if(ok)
        ypercent = dy / 100;

    QImage *imgScaled = new QImage;
    *imgScaled = img->scaled(label->width() * xpercent, label->height() * ypercent, Qt::KeepAspectRatio);
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
    label->setPixmap(QPixmap::fromImage(*imgScaled));
}

void StandardDialogs::slotLeftFileDlg()
{
    bool ok;
    double dl = QInputDialog::getDouble(this, "向左旋转：", "向左旋转度数：度", 90.00, 0, 360.00, 1, &ok);
    if(ok)
        dl = dl;



    QImage *imgRatate = new QImage;
    QMatrix matrix;
    matrix.rotate(dl);
    *imgRatate = img->transformed(matrix);
    *imgRatate = imgRatate->scaled(label->height(), label->width(), Qt::KeepAspectRatio);
    label->setPixmap(QPixmap::fromImage(*imgRatate));
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
}

void StandardDialogs::slotRightFileDlg()
{
    bool ok;
    double dr = QInputDialog::getDouble(this, "向右旋转：", "向右旋转度数：度", 90.00, 0, 360.00, 1, &ok);
    if(ok)
        dr = 360 - dr;
    QImage *imgRatate = new QImage;
    QMatrix matrix;
    matrix.rotate(dr);
    *imgRatate = img->transformed(matrix);
    *imgRatate = imgRatate->scaled(label->height(), label->width(), Qt::KeepAspectRatio);
    label->setPixmap(QPixmap::fromImage(*imgRatate));
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
}

void StandardDialogs::slotBackFileDlg()
{
    if(pc == 0)
        pc = list.size() - 1;
    else
        pc = pc - 1;
    fileInfo = list.at(pc);
    QString img_path = QString("%1/%2").arg(file_path).arg(fileInfo.fileName());
    //QMessageBox::information( this,"提示", img_path );
    img->load(img_path);
    QImage *imgScaled = new QImage;
    *imgScaled = img->scaled(label->width(), label->height(), Qt::KeepAspectRatio);
    label->setPixmap(QPixmap::fromImage(*imgScaled));
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
    setWindowTitle(QString("%1--%2--%3%4%5").arg("图片浏览器").arg(fileInfo.fileName()).arg("有").arg(list.size()).arg("张图片"));

}

void StandardDialogs::slotNextFileDlg()
{
    if(pc == list.size() - 1)
        pc = 0;
    else
        pc = pc + 1;
    fileInfo = list.at(pc);
    QString img_path = QString("%1/%2").arg(file_path).arg(fileInfo.fileName());
    //QMessageBox::information( this,"提示", img_path );
    img->load(img_path);
    QImage *imgScaled = new QImage;
    *imgScaled = img->scaled(label->width(), label->height(), Qt::KeepAspectRatio);
    label->setPixmap(QPixmap::fromImage(*imgScaled));
    label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
    setWindowTitle(QString("%1--%2--%3%4%5").arg("图片浏览器").arg(fileInfo.fileName()).arg("有").arg(list.size()).arg("张图片"));


}

void StandardDialogs::slotSlideFileDlg()
{
    QElapsedTimer t;
    while(1)
    {

        for (int i = 0; i < list.size(); ++i)
        {
            fileInfo = list.at(i);
            QString img_path = QString("%1/%2").arg(file_path).arg(fileInfo.fileName());
            //QMessageBox::information( this,"提示", img_path );
            img->load(img_path);
            QImage *imgScaled = new QImage;
            *imgScaled = img->scaled(label->width(), label->height(), Qt::KeepAspectRatio);
            label->setPixmap(QPixmap::fromImage(*imgScaled));
            label->setAlignment(Qt::AlignCenter | Qt::AlignVCenter);
            setWindowTitle(QString("%1--%2--%3%4%5--%6%7%8").arg("图片浏览器")
                           .arg(fileInfo.fileName()).arg("有").arg(list.size()).arg("张图片")
                           .arg("第").arg(i).arg("张图片"));
            t.start();
            while(t.elapsed() < 2000)
                QCoreApplication::processEvents();
        }
    }
}

