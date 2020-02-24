using System;

namespace Practise2_for_class_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            string lenInput;
            int Length;
            string numInput;
            int num;
            int cleanint = 0;
            int result = 0;
            bool end = false;
            while (!end)
            {
                Console.WriteLine("请输入数组的长度：");
                lenInput = Console.ReadLine();
                while (!int.TryParse(lenInput, out cleanint))
                {
                    Console.Write("这不是一个正确的数！");
                    lenInput = Console.ReadLine();
                }
                Length = Convert.ToInt32(lenInput);
                a = new int[Length];
                int n = 0;
                // 输入数组长后循环输入各数组元素
                while (n < Length)
                {
                    int k = n + 1;
                    Console.WriteLine("请输入第" + k + "个数组元素:");
                    numInput = Console.ReadLine();
                    num = Convert.ToInt32(numInput);
                    a[n] = num;
                    n++;
                }
                Console.WriteLine("请输入你想运行的运算：");
                Console.WriteLine("\ta - 求最大值");
                Console.WriteLine("\ti - 求最小值");
                Console.WriteLine("\tv - 求平均值");
                Console.WriteLine("\ts - 求数组和");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "a":
                        n = a[0];
                        result = 0;
                        while (n < Length)
                        {
                            if (result < a[n])
                            {
                                result = a[n];
                            }
                            n++;
                        }
                        Console.WriteLine("所求的最大值为"+result);
                        break;
                    case "i":
                        n = 0;
                        result = a[0];
                        while (n < Length)
                        {
                            if (result > a[n])
                            {
                                result = a[n];
                            }
                            n++;
                        }
                        Console.WriteLine("所求的最小值为" + result);
                        break;
                    case "v":
                        n = 0;
                        result = 0;
                        while (n < Length)
                        {
                            result = result + a[n];
                            n++;
                        }
                        result = result / Length;
                        Console.WriteLine("所求的平均值为" + result);
                        break;
                    case "s":
                        n = 0;
                        result = 0;
                        while (n < Length)
                        {
                            result = result + a[n];
                            n++;
                        }
                        Console.WriteLine("所求的数组和为" + result);
                        break;
                    default:
                        break;
                }
                Console.Write("输入“ex”以结束程序或者输入其他数以重新开始：");
                if (Console.ReadLine() == "ex") end = true;
                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
