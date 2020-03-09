using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node;
            for (node = head; node != null;node = node.Next)
                {
                action(node.Data);
                }
        }
    }
    delegate void Fun(int x);
    class Program
    {
        public void print(int n)
        {
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            int sum = 0;
            Console.WriteLine("链表元素如下：");
            intlist.ForEach(x => Console.WriteLine(x));
            int max = 0;
            int min = 0;
            int n = 0;
            intlist.ForEach(max => { n = n < max ? max : n; } );
            Console.WriteLine("链表元素最大值为" + n);
            intlist.ForEach(min => { n = n > min ? min : n; });
            Console.WriteLine("链表元素最小值为" + n);
            intlist.ForEach(x => sum += x);
            Console.WriteLine("链表元素之和为" + sum);
        }

    }
}