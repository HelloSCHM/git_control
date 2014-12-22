#include "class_showtime.h"

Class_Showtime::Class_Showtime( QWidget *parent, Qt::WindowFlags  f )
    :QDialog( parent, f )
{
    setWindowTitle("图片浏览器");
    layout = new QGridLayout( this );

    filePushButton = new QPushButton();
    filePushButton->setText(tr("File Dialog"));


    layout->addWidget( filePushButton, 0, 0 );
    layout->setMargin(15);
    layout->setSpacing(10);

    connect(filePushButton,SIGNAL(clicked()),this,SLOT(slotOpenFileDlg()));
}

Class_Showtime::~Class_Showtime()
{

}
