using System;
using System.Threading;

namespace Project2
{
    public delegate void TickHandler(object sender, TickEventArgs args);
    public class TickEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    public delegate void AlarmHandler(object sender, AlarmEventArgs args);
    public class AlarmEventArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
    public class Clock
    {
        public event TickHandler OnTick;
        public event AlarmHandler OnAlarm;
        public void Tick()
        {
            TickEventArgs args = new TickEventArgs();
            OnTick(this, args);
        }
        public void Alarm()
        {
            AlarmEventArgs args = new AlarmEventArgs();
            OnAlarm(this, args);
        }
    }
    public class SetClock
    {
        public int setHour { get; set; }
        public int setMinute { set; get; }
        public int setSecond { get; set; }
        public Clock clock = new Clock();
        public SetClock(int h, int m, int s)
        {
            setHour = h;
            setMinute = m;
            setSecond = s;
            clock.OnTick += new TickHandler(Clk_OnTick);
            clock.OnAlarm += new AlarmHandler(Clk_OnAlarm);
        }
        void Clk_OnTick(object sender, TickEventArgs args)
        {
            Console.WriteLine("滴答");
        }
        void Clk_OnAlarm(object sender, AlarmEventArgs args)
        {
            Console.WriteLine("叮叮叮");
        }
        public void work()
        {
            while (true)
            {
                int hou = DateTime.Now.Hour;
                int min = DateTime.Now.Minute;
                int sec = DateTime.Now.Second;
                if (hou == setHour & min == setMinute & sec == setSecond)
                {
                    clock.Alarm();
                    break;
                }
                else
                {
                    clock.Tick();
                }
                Thread.Sleep(1000);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请设置响铃时间：");
            Console.WriteLine("时：");
            int inputHour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("分：");
            int inputMinute = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("秒：");
            int inputSecond = Convert.ToInt32(Console.ReadLine());
            SetClock setClock = new SetClock(inputHour, inputMinute, inputSecond);
            setClock.work();
        }
    }
}
