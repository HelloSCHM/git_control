#include "myplaylist.h"
#include <QContextMenuEvent>
#include <QMenu>


MyPlaylist::MyPlaylist(QWidget *parent) :
    QTableWidget(parent)
{
    setWindowTitle(tr("�����б�"));
    //����Ϊһ�������Ĵ��ڣ���ֻ��һ���رհ�ť
    setWindowFlags(Qt::Window | Qt::WindowTitleHint);
    resize(400, 400);
    setMaximumWidth(400);
    setMinimumWidth(400);//�̶����ڴ�С
    setRowCount(0);//��ʼ������Ϊ0
    setColumnCount(3);//��ʼ������Ϊ1

    //���õ�һ����ǩ
    QStringList list;
    list << tr("����") << tr("����") << tr("����");
    setHorizontalHeaderLabels(list);

    setSelectionMode(QAbstractItemView::SingleSelection);//����ֻ��ѡ����
    setSelectionBehavior(QAbstractItemView::SelectRows);

    setShowGrid(false);//���ò���ʾ����

}


void MyPlaylist::clear_play_list()
{
    while(rowCount())
        removeRow(0);
    emit play_list_clean();//ɾ����󣬷�����ճɹ��ź�

}


void MyPlaylist::contextMenuEvent(QContextMenuEvent *event)
{
    QMenu menu;
    menu.addAction(tr("����б�"), this, SLOT(clear_play_list()));//����ֱ��������ָ���ۺ���
    menu.exec(event->globalPos());//�������ָ���ȫ��λ��

}


void MyPlaylist::closeEvent(QCloseEvent *event)
{
    if(isVisible()) {
        hide();
        event->ignore();//������ձ�־
    }
}
