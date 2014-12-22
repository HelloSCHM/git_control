#include <QApplication>
//#include <QImage>
//#include <QPixmap>
//#include <QtGui>
//#include <QWidget>
//#include <QLabel>
//#include<qtextcodec.h>
//#include<QString>
//#include <QFileDialog>
#include<class_showtime.h>
//#include "class_openfile.h"

int main(int argc, char* argv[])
{
    //QApplication app(argc, argv);

    /*
     * #include<qtextcodec.h>
     * 中文补丁
    QTextCodec *codec = QTextCodec::codecForName("UTF-8");
    QTextCodec::setCodecForLocale(codec);
    QTextCodec::setCodecForCStrings(codec);
    QTextCodec::setCodecForTr(codec);*/
    //QWidget window;
    //window.setWindowTitle("图片浏览器");

    QFont font("ZYSong18030",12);
    QApplication::setFont(font);

    QApplication app( argc, argv );
    QTranslator translator(0);
    translator.load("standarddialogs_zh",".");
    app.installTranslator(&translator);

    Class_Showtime *showtime = new Class_Showtime();
    showtime->show();

/*

    QLabel *label = new QLabel(&window);
    label->setPixmap(QPixmap(QString::fromUtf8("E:/MrGood-LOGO_1.png")));


    window.showMaximized();
*/
 /*
    QLabel label1("good");

    QPixmap image1;
    image1.load("E:/MrGood-LOGO_1.png");//我f盘下有两个文件Pic1.bmp和Pic1.jpg,bmp文件可以正常显示。

    label1.setPixmap(image1);

    label1.show();
*/
    return app.exec();
}

