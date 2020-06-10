using System;
namespace LeanEventInstance
{
    public delegate void WaterHeaterDelegate(int Temperature);

    class WaterHeater
    {

        public event WaterHeaterDelegate WaterDele;


        public void Shaoshui() //开始事件
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i > 95)
                {
                    WaterDele.Invoke(i); //调用启动事件
                }
            }
        }

        public void WaterHot(int temperature) //水温提示
        {
            Console.WriteLine("水已经有{0}C了", temperature);
        }

        public void WaterBoiling(int temperature) //水烧开
        {
            Console.WriteLine("水已经烧开了" + temperature);
        }
    }

    class LeanEventInstance
    {
        static void Main(string[] args)
        {
            WaterHeater water = new WaterHeater();  //热水器实例化对象
            water.WaterDele += new WaterHeaterDelegate(water.WaterHot); //绑定事件
            water.WaterDele += new WaterHeaterDelegate(water.WaterBoiling); //绑定事件
            //water.WaterDele -= new WaterHeaterDelegate(water.WaterBoiling); //解绑事件
        
            water.Shaoshui();

            Console.ReadKey();
        }

       
    }
}