#include "standarddialogs.h"
#include <QApplication>


int main( int argc, char **argv )
{
    QFont font("ZYSong18030",12);
    QApplication::setFont(font);
    	
    QApplication app( argc, argv );
    QTranslator translator(0);
    translator.load("standarddialogs_zh",".");
    app.installTranslator(&translator);
    app.setWindowIcon(QIcon("LOGO.ico"));
    
    StandardDialogs *standarddialogs = new StandardDialogs();
    standarddialogs->show();
    standarddialogs->resize( QSize( 800, 600 ));
    //move ((QApplication::desktop()->width() - standarddialogs.width())/2,(QApplication::desktop()->height() - standarddialogs.height())/2);
    return app.exec();
}
