
1���������ݿⱾ���û�test������Ϊoracle��Ĭ�ϱ�ռ�Ϊusers����ʱ��ռ�Ϊtemp��ͬʱ����create sessionϵͳȨ�ޡ�

CREATE USER TEST
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;

GRANT CREATE SESSION TO TEST;
REVOKE CREATE SESSION FROM TEST;

GRANT CONNECT TO TEST;
REVOKE CONNECT FROM TEST;
GRANT RESOURCE TO TEST;
REVOKE RESOURCE FROM TEST;

2���û���������������SELECTȨ����

CREATE USER ����
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO ����;

GRANT SELECT ON hr.ְ�� TO ����;
GRANT SELECT ON hr.���� TO ����;
REVOKE SELECT ON hr.ְ�� FROM ����;
REVOKE SELECT ON hr.���� FROM ����;


3���û����¶���������INSERT��DELETEȨ����

CREATE USER ����
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO ����;

GRANT INSERT ON hr.ְ�� TO ����;
GRANT INSERT ON hr.���� TO ����;
REVOKE INSERT ON hr.ְ�� FROM ����;
REVOKE INSERT ON hr.���� FROM ����;

GRANT DELETE ON hr.ְ�� TO ����;
GRANT DELETE ON hr.���� TO ����;
REVOKE DELETE ON hr.ְ�� FROM ����;
REVOKE DELETE ON hr.���� FROM ����;

4���û����Ƕ�ְ������SELECTȨ�����Թ����ֶξ��и���Ȩ����

DROP USER ���� CASCADE;

CREATE USER ����
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO ����;

GRANT SELECT ON hr.ְ�� TO ����;
REVOKE SELECT ON hr.ְ�� FROM ����;
GRANT UPDATE(����) ON hr.ְ�� TO ����;
REVOKE UPDATE (����) ON hr.ְ�� FROM ����;

5���û���ƽ���ж�����������Ȩ���������塢�ġ�ɾ���ݣ��������и������û���Ȩ��Ȩ����
��ʾ������Ȩ��ΪALL PRIVILEGE����GRANT�����ʹ��WITH GRANT OPTIONѡ�����Ȩ���û��;������ٴν�����Ȩ�����������û���������

DROP USER ��ƽ CASCADE;

CREATE USER ��ƽ
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO ��ƽ;

GRANT ALL PRIVILEGES ON hr.���� TO ��ƽ WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON hr.ְ�� TO ��ƽ WITH GRANT OPTION;

6���û��������д�ÿ������ְ����SELECT��߹��ʣ���͹��ʣ�ƽ�����ʵ�Ȩ���������ܲ鿴ÿ���˵Ĺ��ʡ�
��ʾ�����ȴ�����ͼ��ѯÿ������ְ���е���߹��ʣ���͹��ʺ�ƽ�����ʣ�Ȼ�������û���ѯ��ͼ��Ȩ�ޡ�

CREATE USER ����
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO ����;

CREATE VIEW ְ��_����(���ź�,ƽ������,��߹���,��͹���) AS
SELECT ���ź�,AVG(����),MAX(����),MIN(����) FROM hr.ְ��
GROUP BY ���ź�;

SELECT * FROM ְ��_����
DROP VIEW ְ��_����;


GRANT SELECT ON ְ��_���� TO ����;
REVOKE SELECT ON ְ��_���� FROM ����;



������ư�ȫ����ʹ���û���liming��ֻ�ܲ�ѯ������40�����ϣ�������ְ����
��ʾ������ͼʵ��

CREATE USER LIMING
IDENTIFIED BY ORACLE
DEFAULT TABLESPACE USERS
TEMPORARY TABLESPACE TEMP;
GRANT CREATE SESSION TO LIMING;

CREATE VIEW ְ��_����(ְ����,����,����) AS
SELECT ְ����,����,���� FROM hr.ְ��
WHERE ���� >= 40;

SELECT * FROM ְ��_����
DROP VIEW ְ��_����;


GRANT SELECT ON ְ��_���� TO LIMING;
REVOKE SELECT ON ְ��_���� FROM LIMING;




�ġ���ư�ȫ����ʹ���û���liming��ֻ�ܷ��ʡ�ְ������ְ���š�������
��ʾ������ͼʵ��

CREATE VIEW ְ��_����(ְ����,����) AS
SELECT ְ����,���� FROM hr.ְ��;

SELECT * FROM ְ��_����
DROP VIEW ְ��_����;


GRANT SELECT ON ְ��_���� TO LIMING;
REVOKE SELECT ON ְ��_���� FROM LIMING;


�塢��ƽ�ɫ��student�������Բ鿴��ְ������ְ���š����������䡣���û���liming����ӵ���ɫ��student���С�
��ʾ������ͼʵ��

CREATE ROLE STUDENT;

CREATE VIEW ְ��_��ɫ AS
SELECT ְ����,����,���� FROM hr.ְ��;

GRANT SELECT ON hr.ְ��_��ɫ TO SUTDENT;

CREATE ROLE STUDENT;

GRANT STUDENT TO LIMING;
