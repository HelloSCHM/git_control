#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    struct PortSettings myComSetting = {BAUD9600, DATA_8, PAR_NONE, STOP_1, FLOW_OFF, 500};

    //定义一个结构体，用来存放串口各个参数

    myCom = new Win_QextSerialPort("com1", myComSetting, QextSerialBase::EventDriven);

    //定义串口对象，并传递参数，在构造函数里对其进行初始化

    myCom ->open(QIODevice::ReadWrite);

    //以可读写方式打开串口

    connect(myCom, SIGNAL(readyRead()), this, SLOT(readMyCom()));

    //信号和槽函数关联，当串口缓冲区有数据时，进行读串口操作
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::readMyCom() //读串口函数

{

    QByteArray temp = myCom->readAll();

    //读取串口缓冲区的所有数据给临时变量temp

    ui->textBrowser->insertPlainText(temp);

    //将串口的数据显示在窗口的文本浏览器中

}
