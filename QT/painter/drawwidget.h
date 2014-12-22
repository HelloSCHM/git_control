#ifndef DRAWWIDGET_H
#define DRAWWIDGET_H

#include <QWidget>

class QPixmap;

class DrawWidget : public QWidget
{
    Q_OBJECT
public:
    DrawWidget();

    void paintEvent(QPaintEvent *);
    void resizeEvent(QResizeEvent *);

public slots:   
    void setStyle(int);
    void setWidth(int);
    void clear();
    
private:
    QPixmap *pix;

    int style;
    int weight;
};

#endif 
