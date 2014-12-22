#include <QtGui>
#include "drawwidget.h"

DrawWidget::DrawWidget()	
{
    setAutoFillBackground(true);
	
    QPalette palette = this->palette();
    palette.setColor(QPalette::Window,Qt::white);
    setPalette(palette);
    
    pix = new QPixmap(size());
    pix->fill(Qt::white);
    
    setMinimumSize(600,400);
}

void DrawWidget::setStyle(int s)
{
    style = s;
}

void DrawWidget::setWidth(int w)
{
    weight = w;
}


void DrawWidget::paintEvent(QPaintEvent *)
{
    QPainter painter(this);
    painter.drawPixmap(QPoint(0,0),*pix);
}


void DrawWidget::resizeEvent(QResizeEvent * event)
{
//    if(height() > pix->height() || width() > pix->width())
    {
        QPixmap *newPix = new QPixmap(size());
        newPix->fill(Qt::white);
        QPainter p(newPix);
        p.drawPixmap(QPoint(0,0),*pix);
        pix = newPix;
    }
    QWidget::resizeEvent(event);
}


void DrawWidget::clear()
{
    QPixmap *clearPix = new QPixmap(size());
    clearPix->fill(Qt::white);
    pix = clearPix;
    update();
}
