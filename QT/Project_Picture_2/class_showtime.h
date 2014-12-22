#ifndef CLASS_SHOWTIME_H
#define CLASS_SHOWTIME_H

#include<QtGui>

class Class_Showtime: public QDialog
{
    Q_OBJECT

public:
    Class_Showtime(QWidget *parent=0, Qt::WindowFlags  f=0);
    ~Class_Showtime();

public:
    QGridLayout *layout;

    QPushButton *filePushButton;

private slots:
    void slotOpenFileDlg();
};

#endif // CLASS_SHOWTIME_H
