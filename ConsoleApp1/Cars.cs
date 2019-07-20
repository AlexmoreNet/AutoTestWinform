using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public abstract class Car
    {
        public abstract void Drive();
    }
    public abstract class Factory
    {
        public abstract Car CreateCar();
    }
    public class AodiCar : Car
    {
        public override  void Drive()
        {
            Console.WriteLine("奥迪车启动");
        }
    }
    public class BaoMaCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("宝马车启动");
        }
    }
    public class  AoDiF : Factory
    {
        public override Car CreateCar()
        {
            return new AodiCar();
        }
    }
}
