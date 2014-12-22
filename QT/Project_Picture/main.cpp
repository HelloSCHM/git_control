#include "class_picture.h"
#include <QApplication>


int main( int argc, char **argv )
{
    QFont font("ZYSong18030",10);
    QApplication::setFont(font);

    QApplication a( argc, argv );
    QTranslator translator(0);
    translator.load("drawer_zh",".");
    a.installTranslator(&translator);

    openAction = new QAction(tr("&Open"), this);
         openAction->setShortcut(QKeySequence::Open);
         openAction->setStatusTip(tr("Open a file."));

    return a.exec();
}

