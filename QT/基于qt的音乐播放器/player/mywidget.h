#ifndef MYWIDGET_H
#define MYWIDGET_H

#include <QWidget>
#include <Phonon>
#include <QSystemTrayIcon>

class QLabel;
class MyPlaylist;
class MyLrc;

namespace Ui {
class MyWidget;
}

class MyWidget : public QWidget
{
    Q_OBJECT
    
public:
    explicit MyWidget(QWidget *parent = 0);
    ~MyWidget();
    
private:
    Ui::MyWidget *ui;
    void InitPlayer();
    Phonon::MediaObject *media_object;
    QAction *play_action;
    QAction *stop_action;
    QAction *skip_backward_action;
    QAction *skip_forward_action;
    QLabel *top_label;
    QLabel *time_label;

    MyPlaylist *playlist;
    Phonon::MediaObject *meta_information_resolver;
    QList<Phonon::MediaSource> sources;
    void change_action_state();

    MyLrc *lrc;
    QMap<qint64, QString> lrc_map;
    void resolve_lrc(const QString &source_file_name);

    QSystemTrayIcon *tray_icon;

private slots:
    void UpdateTime(qint64 time);
    void SetPaused();
    void SkipBackward();
    void SkipForward();
    void OpenFile();
    void SetPlayListShown();
    void SetLrcShown();

    void StateChanged(Phonon::State new_state, Phonon::State old_state);
    void SourceChanged(const Phonon::MediaSource &source);
    void AboutToFinish();
    void MetaStateChanged(Phonon::State new_state, Phonon::State old_state);
    void TableClicked(int row);
    void ClearSources();

    void TrayIconActivated(QSystemTrayIcon::ActivationReason activation_reason);

protected:
    void closeEvent(QCloseEvent *);

};

#endif // MYWIDGET_H
