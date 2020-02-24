using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Practise1_for_class_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string InputNum;
            bool end = false;
            while (!end)
            {
                Console.WriteLine("请输入一个数据：");
                InputNum = Console.ReadLine();
                int cleanInt = 0;
                //判断输入的数是否是一个正确的int型数据
                while (!int.TryParse(InputNum, out cleanInt))
                {
                    Console.Write("这不是一个正确的数据！");
                    InputNum = Console.ReadLine();
                }
                num = Convert.ToInt32(InputNum);
                int n = 2;      //用于检验该数是否为素数因子
                while (num != 1)
                {
                    if (num % n == 0)
                    {
                        num = num / n;
                        Console.WriteLine(n);
                    }
                    else
                    {
                        n++;
                    }
                }
                Console.Write("输入esc以结束程序，或输入其他字母以重新开始程序: ");
                if (Console.ReadLine() == "esc") end = true;
                Console.WriteLine("\n");
            }
            return;
        }
    }
}
