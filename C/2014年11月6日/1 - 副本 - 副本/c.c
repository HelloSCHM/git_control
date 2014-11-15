#include<stdio.h>
#include<math.h> 

/*定义函数*/
int print();
int log2(int value);
int calculate();

/*全局变量*/
int x,n;
int rank_t[1024];
int rank_f[1024];
int end[1024][1024];

int main(int argc, char const *argv[])
{
    print();
    /* code */
    return 0;
}

int print()
{
    int i,j = 1;
    printf("输入需要排的队伍数：");
    scanf("%d",&x);
    if(x&(x-1))  //使用与运算判断一个数是否是2的幂次方  
        printf("%d不是2的幂次方！\n",x);  
    else
    {
        n =  log2(x);
        printf("%d是2的%d次方！\n",x,n);     
		
		for (i = 1; i <= x; i++)
        {
            rank_t[i] = i;
            if (i % 2 == 0)
            {
                rank_f[j] = i - 1;
                j++;
                /* code */
            }
            else
            {
                rank_f[j] = i + 1;
                j++;
            }
            printf("%3d%3d\n", rank_t[i],rank_f[i]);
        }	
    }
    //system("pause");  
    return n;  
}

int log2(int value)   //递归判断一个数是2的多少次方  
{  
    if (value == 1)  
        return 0;  
    else  
        return 1+log2(value>>1);  
} 

int calculate()
{
    int i,j;
    for (i = 1; i <= x; i++)
    {
        end[1][i] = i;
        end[i][1] = i;
        if(i % 2 == 0)
        {
            for (j = 0; j < 3; j++)
            {
                /* code */
            }
        }
        else
        {

        }
        /* code */
    }
}
