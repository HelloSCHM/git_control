#include<stdio.h>  
  
struct Node  
{  
    int s;  
    int e;  
};  
  
int count;  
  
void fun (Node a[], int i, int n)  
{  
    int m = i + 1;  
    while ((m <= n) && (a[i].e > a[m].s))  
        m++;  
  
    if (m <= n)  
    {  
        count++;  
        fun (a, m, n);  
    }  
}  
  
int main()  
{  
    int n;  
    int i, j;  
    Node a[100], temp;  
  
    while (scanf("%d", &n), n)  
    {  
        for (i = 0; i < n; i++)  
        {  
            scanf("%d%d", &a[i].s, &a[i].e);  
        }  
        for (i = 0; i < n - 1; i++)  
        {  
            for (j = 0; j < n - i - 1; j++)  
            {  
                if (a[j].e > a[j + 1].e)  
                {  
                    temp = a[j];  
                    a[j] = a[j + 1];  
                    a[j + 1] = temp;  
                }  
            }  
        }  
  
        count = 1;  
        fun(a, 0, n-1);  
        printf("%d\n", count);  
    }  
    return 0;  
}  