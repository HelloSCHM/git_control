#include "stdio.h"
#include "stdlib.h"
#include "math.h"

int print();
int input();
//void output_print(int rank[1024][1024]);
void caculate(int n);
int log2(int value);

int n;

int main(int argc, char const *argv[])
{
    print();
	caculate(n);
    /* code */
    return 0;
}

int print()
{
    int x;
    printf("������Ҫ�ŵĶ�������");
    scanf("%d",&x);
    if(x&(x-1))  //ʹ���������ж�һ�����Ƿ���2���ݴη�  
        printf("%d����2���ݴη���\n",x);  
    else
    {
        n =  log2(x);
        printf("%d��2��%d�η���\n",x,n); 		
    }
    //system("pause");  
    return 0;  
}

int log2(int value)   //�ݹ��ж�һ������2�Ķ��ٴη�  
{  
    if (value == 1)  
        return 0;  
    else  
        return 1+log2(value>>1);  
} 

void caculate(int n)
{
    int rank[1024];
	int i;
	printf("please");
	printf("%d",n);
    for(i = 0; i < n; i++)
    {
        rank[i] = i;
		printf("��%d����Ϊ��%d\r",rank[i]);
        /* code */
    }
}