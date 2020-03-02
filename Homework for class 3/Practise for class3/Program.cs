using System;

namespace Practise_for_class3
{
    public interface Shape //最初的接口
    {
        void isLegal();
        double getArea();
    }
    public class Rectangle : Shape  //长方形
    {
        Random ran = new Random();
        public double width;
        public double height;
        public double area;
        bool legal = false;
        public Rectangle() { }
        public double Width { set; get; }
        public double Height { set; get; }
        public void isLegal()  //判断是否合法以便后续计算，下同
        {
            width = ran.Next(1, 10);
            height = ran.Next(1, 10);
            if (width != 0 && height != 0 && width != height)
            {
                Console.WriteLine("该长方形合法。");
                legal = true;
            }
            else
            { Console.WriteLine("该长方形不合法。"); }
        }
        public double getArea()  //计算面积，下同
        {
            if (legal)
            {
                area = width * height;
                Console.WriteLine("该长方形面积为：" + area);
                Console.WriteLine("");
                return area;
            }
            else 
            {
                Console.WriteLine("");
                return 0; 
            }
        }
    }
    public class Square : Shape  //正方形
    {
        Random ran = new Random();
        public double side;
        public double area;
        bool legal = false;
        public Square() { }
        public double Side { set; get; }
        public void isLegal()
        {
            side = ran.Next(1, 10);
            if (side != 0)
            {
                Console.WriteLine("该正方形合法。");
                legal = true;
            }
            else
            { Console.WriteLine("该正方形不合法。"); }
        }
        public double getArea()
        {
            if (legal)
            {
                area = side * side;
                Console.WriteLine("该正方形面积为：" + area);
                Console.WriteLine("");
                return area;
            }
            else
            {
                Console.WriteLine("");
                return 0;
            }
        }
    }
    public class Triangle : Shape  //三角形
    {
        Random ran = new Random();
        public double a;
        public double b;
        public double c;
        public double area;
        bool legal = false;
        public Triangle() { }
        public double A { set; get; }
        public double B { set; get; }
        public double C { set; get; }
        public void isLegal()
        {
            a = ran.Next(1, 10);
            b = ran.Next(1, 10);
            c = ran.Next(1, 10);
            if (a != 0 && b != 0 && c != 0 && a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine("该三角形合法。");
                legal = true;
            }
            else
            { Console.WriteLine("该三角形不合法。"); }
        }
        public double getArea()
        {
            if (legal)
            {
                area = Math.Sqrt((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)) / 4;
                Console.WriteLine("该三角形面积为：" + area);
                Console.WriteLine("");
                return area;
            }
            else
            {
                Console.WriteLine("");
                return 0;
            }
        }
    }
    public class shapeFactory  //制造工厂，用于随机的生成图形
    {
        public static Shape creator()
        {
            Random ran = new Random();
            int op = ran.Next(1, 4);
            switch (op)
            {
                case 1:
                    return new Rectangle();
                case 2:
                    return new Square();
                case 3:
                    return new Triangle();
                default:
                    return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 1; i < 11; i++)
                    {
                     Shape sha = shapeFactory.creator();  //用工厂生成图形并开始计算，其中不合法的部分的面积为0
                     sha.isLegal();
                     sum = sum + sha.getArea();
                    }
            Console.WriteLine("10个图形中合格的部分的总面积为" + sum);
        }
    }
}
