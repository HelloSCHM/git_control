CREATE TABLE ����(
���ź� CHAR(2),
���� VARCHAR2(21),
������ VARCHAR2(12),
��ַ VARCHAR2(51),
�绰�� INT
);

INSERT INTO ���� VALUES('01','��ҵ��','����','����ʮ�ߺ���������ҵѧԺ',111);
INSERT INTO ���� VALUES('02','������','����','����ʮ�ߺ���������ҵѧԺ',110);

SELECT * FROM ����;
DROP TABLE ����;

CREATE TABLE ְ��(
ְ���� CHAR(4),
���� VARCHAR2(12),
���� INT,
ְ�� VARCHAR2(21),
���� INT,
���ź� CHAR(2)
);

DROP TABLE ְ��;

INSERT INTO ְ�� VALUES('0001','����',18,'c++����ʦ',11111,'02');
INSERT INTO ְ�� VALUES('0002','����',18,'����ҵ��Ա',10000,'01');

SELECT * FROM ְ��;
