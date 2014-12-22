#ifndef STANDARDDIALOGS_H
#define STANDARDDIALOGS_H

#include <QtGui>

class StandardDialogs : public QWidget
{
    Q_OBJECT
public:
    StandardDialogs( QWidget *parent=0, Qt::WindowFlags  f=0 );
    ~StandardDialogs();
public:
    QGridLayout *Alayout;
    QGridLayout *Playout;
    QGridLayout *Dlayout;
    //QGridLayout *Rlayout;
    //QGridLayout *Llayout;
    
    QLabel *label;
    QImage *image;
    QPushButton *NextButton;
    QPushButton *BackButton;

    QToolBar *toolbar;
    QToolButton *fileTButton;
    QToolButton *ChangeTButton;
    //QToolButton *BigTButton;
    //QToolButton *SmallTButton;
    QToolButton *LeftTButton;
    QToolButton *RightTButton;
    QToolButton *BackTButton;
    QToolButton *NextTButton;
    QToolButton *DelTButton;
    QToolButton *SlideTButton;

private slots:
    void slotOpenFileDlg();
    void slotDelFileDlg();
    void slotChangeFileDlg();
    void slotLeftFileDlg();
    void slotRightFileDlg();
    void slotBackFileDlg();
    void slotNextFileDlg();
    void slotSlideFileDlg();
    //void slotBigFileDlg();
    //void slotSmallFileDlg();

};


#endif 
