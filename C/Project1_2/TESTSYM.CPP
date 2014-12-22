#include "basedata.h"
#include "symbol.h"
#include <conio.h>

extern char *WORD[WORDLEN];
extern int WSYM[WORDLEN];
extern char* SNAME[SYMBOLNUM];
extern SYMBOL sym;//last readed word type;
extern char   token[MAXIDLEN+1];//last readed word
extern int num;//last readed num;
extern char ch;//last readed char;
extern int col,row;
extern FILE *fd;


FILE *fout;
void Init(void);
void Quit(void);

void main()
{
  int flag;
  Init();

  fprintf(fout,"\n     TOKEN       SYM         NUM");
  do{
	
	flag=Getsym();
	if(flag)
	 {
	  fprintf(fout,"\n%10s    %10s        %d",token,SNAME[sym],num);
	 }
	else if(ch!=EOF)
	 {
	  fprintf(fout,"\n%10s",token);
	  Errorsym();
	 }
	}while(ch!=EOF);//��������Getsym()ʶ�𵥴ʣ�������������fout��

  Quit();

}


//======================================
void Init(void)
{
  char temp[30];
  printf("\nPlease input your file name:");
  gets(temp);
  if ((fd = fopen(temp,"rt"))
	== NULL)
  {
   fprintf(stderr, "Cannot open input file %s.\n",temp);
   getch();
   return ;
  }//��fdָ��ָ�������Դ�ļ�
  if ((fout = fopen("mydata.dat", "wt"))
	== NULL)
  {
   fprintf(stderr, "Cannot open input file.\n");
   getch();
   return ;
  }//��foutָ���ļ�mydata.dat
}
void Quit(void)
{
  fclose(fd);
  fclose(fout);
}