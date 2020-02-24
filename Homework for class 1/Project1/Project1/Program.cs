using System;

namespace Project1
{
    class Calculator
    {
        public static double Calculate(double num1, double num2, string op)
        {
            double result = double.NaN;
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.Write("请输入一个非零数！");
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("C#语言的控制台计算器程序\r");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {
                string num1 = "";
                string num2 = "";
                double result = 0;
                Console.Write("请输入第一个操作数：");
                num1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(num1, out cleanNum1))
                {
                    Console.Write("请输入一个数字：");
                    num1 = Console.ReadLine();
                }
                Console.Write("请输入第二个操作数（如果您想使用除法，请不要输入0）：");
                num2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(num2, out cleanNum2))
                {
                    Console.Write("请输入一个数字：");
                    num2 = Console.ReadLine();
                }
                Console.WriteLine("输入字母已选择对应的计算方法：");
                Console.WriteLine("\ta - 加");
                Console.WriteLine("\ts - 减");
                Console.WriteLine("\tm - 乘");
                Console.WriteLine("\td - 除");
                string op = Console.ReadLine();
                try
                {
                    result = Calculator.Calculate(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("这将会导致一个数学错误！\n");
                    }
                    else Console.WriteLine("运算结果: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("发生事故导致程序终止。\n - 细节: " + e.Message);
                }

                Console.WriteLine("------------------------\n");
                Console.Write("输入“q”关闭计算器，或者输入其他数以继续进行其他运算：");
                if (Console.ReadLine() == "q") endApp = true;
                Console.WriteLine("\n");
            }
            return;
        }
    }
}
