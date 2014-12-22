#include "class_picture.h"

Class_Picture::Class_Picture(QWidget *parent)
    : QMainWindow(parent)
{
    openAction = new QAction(tr("&Open"), this);
           openAction->setShortcut(QKeySequence::Open);
           openAction->setStatusTip(tr("Open a file."));

           QMenu *file = menuBar()->addMenu(tr("&File"));
           file->addAction(openAction);

           QToolBar *toolBar = addToolBar(tr("&File"));
           toolBar->addAction(openAction);

}

~Class_Picture()
{

}
