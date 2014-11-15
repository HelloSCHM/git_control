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
    printf("输入需要排的队伍数：");
    scanf("%d",&x);
    if(x&(x-1))  //使用与运算判断一个数是否是2的幂次方  
        printf("%d不是2的幂次方！\n",x);  
    else
    {
        n =  log2(x);
        printf("%d是2的%d次方！\n",x,n); 		
    }
    //system("pause");  
    return 0;  
}

int log2(int value)   //递归判断一个数是2的多少次方  
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
		printf("第%d个数为：%d\r",rank[i]);
        /* code */
    }
}