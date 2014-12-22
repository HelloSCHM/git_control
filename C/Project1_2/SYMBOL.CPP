#include "basedata.h"
#include "symbol.h"
#include <conio.h>
#include <string.h>
#include <ctype.h>

char *WORD[WORDLEN]={"BEGIN","CALL","CONST","DO",
"END","IF","ODD","PROCEDURE",
"READ","THEN","VAR","WHILE",
"WRITE","INCLUDE","STDIO",
"VOID","INT","SCANF","PRINTF",
"ELSE","MAIN"
};//保留字字符串表,用于将保留字种别码转为字符串输出

SYMBOL WSYM[WORDLEN]={BEGINSYM,CALLSYM,CONSTSYM,
DOSYM,ENDSYM,IFSYM,ODDSYM,
PROCSYM,READSYM,THENSYM,
VARSYM,WHILESYM,WRITESYM,INCLUDESYM,STDIOSYM,
VOIDSYM,INTSYM,SCANFSYM,PRINTFSYM,ELSESYM,MAINSYM};//保留字种别码表

char* SNAME[SYMBOLNUM]=
{"RBRACKET","RS","WB","PERCENT","DQM","LBRACKET","NOL","IDENT","NUMBER","PLUS","MINUS","TIMES",
"SLASH","ODDSYM","EQL","NEQ","LSS","LEQ","GTR",
"GEQ","LPAREN","RPAREN","COMMA","SEMICOLON",
"PERIOD","BECOMES","BEGINSYM","ENDSYM","IFSYM",
"THENSYM","WHILESYM","WRITESYM","READSYM",
"DOSYM","CALLSYM","CONSTSYM","VARSYM","PROCSYM",
"INCLUDESYM","STDIOSYM","VOIDSYM","INTSYM",
"SCANFSYM","PRINTFSYM","ELSESYM","MAINSYM"};
//单词字符串表,用于将保留字种别码转为字符串输出





SYMBOL sym;//最近已识的单词种别码
char   token[MAXIDLEN+1];//最近已识别的单词
int num;//最近已识别的数字值
char ch;//最近已识别的字符

int col=1,row=1;//当前行和列值
FILE *fd;//指向待编译文件
extern FILE *fout;//指向存放结果文件

void Getchar(void)
{
	
	ch=fgetc(fd);
	if(ch!=EOF && ch!='\n')
		col++;
	return;
}

void Getbc(void)
{
	while(ch==SPACE ||ch==TABLE ||ch=='\n')
	{
		if(ch=='\n') {row++;col=1;}
		Getchar();
	}//为空字符则一直读至不为空字符
}


void Retract(void)
{
	fseek(fd,-1l,SEEK_CUR);
	col--;
}

void Concat(void)
{
	char temp[2];
	temp[0]=ch;temp[1]='\0';
	strcat(token,temp);
}

int Reserve(void)
{
	int i,j;
	char temp[60];
	j=strlen(token);
	for(i=0;i<j;i++)
	{
		temp[i]=toupper(token[i]);//将当前token字以大写形式存入temp中
	}
	temp[i]='\0';
	
	for(i=0;i<WORDLEN;i++)
	{
		
		if(!strcmp(WORD[i],temp))
			break;
	}//判断当前token是否是保留字

	if(i>=WORDLEN) i=-1;
	return i;
}

void Errorsym(void)
{
	fprintf(fout,"There is error @row: %5d, @col: %5d",row,col);
}




int Getsym(void)
{
	int k;
	int flag=TRUE;
	Getchar();
	Getbc();//滤掉白字符
	strcpy(token,"");
	if(isalpha(ch))
	{
		//以字母开头则是标识符
		num=0;
		Concat();
		Getchar();
		while(isalnum(ch))
		{
			Concat();
			Getchar();
		}
		Retract();//由于超前搜索了，所以回退一个字符
		k=Reserve();//判断此标识符是否是保留字
		if(k!=-1)
		{
			sym=WSYM[k];//将保留字种别码存入sym中
			num = k;
		}
		else
		{
			num = 1000;
			sym=IDENT;//将一般标识符种别码存入sym中
		}//end else k!=-1;
		
	}//end of if isalpha
	else if(isdigit(ch))
	{
		//以数字开头则为无符号整数
		Concat();
		Getchar();
		while(isdigit(ch))
		{
			Concat();
			Getchar();
		}
		if(isalpha(ch))
		{
			flag=FALSE;
			while(isalnum(ch))
			{
				Concat();
				Getchar();
			}
		}//end of flag=FALSE
		Retract();//回退
		if(flag)//若是无符号整数，则将整数值存于num中
		{sym=NUMBER;num=atoi(token);}
	}//end of if isdigit
	else
	{
		num=0;
		switch (ch)
		{
		case '{':Concat();sym=LBRACKET;num=29;break;
		case '}':Concat();sym=RBRACKET;num=30;break;
		case '"':Concat();sym=DQM;num=34;break;
		case '%':Concat();sym=PERCENT;num=33;break;
		case '&':Concat();sym=WB;num=32;break;
		case '\\':Concat();sym=RS;num=35;break;
		case '+':Concat();sym=PLUS;num=13;break;
		case '-':Concat();sym=MINUS;num=14;break;
		case '*':Concat();sym=TIMES;num=15;break;
		case '/':Concat();sym=SLASH;num=16;break;
		case '(':Concat();sym=LPAREN;num=26;break;
		case ')':Concat();sym=RPAREN;num=27;break;
		case '=':Concat();sym=EQL;num=24;break;
		case '#':Concat();sym=NEQ;num=0;break;
		/*
		ODDSYM,EQL,NEQ,LSS,LEQ,GTR,GEQ,LPAREN,
		RPAREN,COMMA,SEMICOLON,PERIOD,BECOMES,
			*/
			
		case ',':Concat();sym=COMMA;num=25;break;
		case '.':Concat();sym=PERIOD;num=31;break;
		case ';':Concat();sym=SEMICOLON;num=25;break;
		case '>':
			Concat();Getchar();
			if(ch!='=')//若后不跟'=',则回退
			{sym=GTR;num=22;Retract();}
			else
			{Concat();num=23;sym=GEQ;}
			break;
		case '<':Concat();Getchar();
			if(ch!='=')
			{sym=LSS;num=20;Retract();}
			else
			{Concat();num=21;sym=LEQ;}
			break;
		case ':':Concat();Getchar();
			if(ch!='=')
			{flag=FALSE;Retract();}
			else
			{Concat();sym=BECOMES;}
			break;
			
		default :Concat();flag=FALSE;break;
			
		}//end of switch else char
	}//end of else char
	return flag;
}
