CREATE TABLE 部门(
部门号 CHAR(2),
名称 VARCHAR2(21),
经理名 VARCHAR2(12),
地址 VARCHAR2(51),
电话号 INT
);

INSERT INTO 部门 VALUES('01','事业部','张三','湖北十堰湖北汽车工业学院',111);
INSERT INTO 部门 VALUES('02','开发部','李四','湖北十堰湖北汽车工业学院',110);

SELECT * FROM 部门;
DROP TABLE 部门;

CREATE TABLE 职工(
职工号 CHAR(4),
姓名 VARCHAR2(12),
年龄 INT,
职务 VARCHAR2(21),
工资 INT,
部门号 CHAR(2)
);

DROP TABLE 职工;

INSERT INTO 职工 VALUES('0001','阿大',18,'c++工程师',11111,'02');
INSERT INTO 职工 VALUES('0002','阿二',18,'销售业务员',10000,'01');

SELECT * FROM 职工;
