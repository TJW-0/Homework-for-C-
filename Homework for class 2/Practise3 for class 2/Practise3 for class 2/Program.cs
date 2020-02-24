using System;

namespace Practise3_for_class_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            a = new int[100];
            int n=0;
            //津行数组赋值
            while (n <99)
            {
                n++;
                a[n] = n + 1;
            }
            Console.WriteLine("输入任意数以开始对2-100的埃氏筛法：");
            string b = Console.ReadLine();
            int m = 0;
            while (m < 100)
            {
                int k = 2;
                while (k < a[m])
                {
                    if(a[m]%k == 0)
                    {
                        a[m] = 0;
                    }
                    k++;
                }
                m++;
            }
            int j = 0;
            Console.WriteLine("经埃氏筛法之后的素数如下：");
            while (j < 100)
            {
                if(a[j] != 0)
                {
                    Console.Write(a[j]+" ");
                }
                j++;
            }
        }
    }
}
