using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAuto
{
    public class SingelIWebDriver
    {
        private static IWebDriver IWebDriver = null;
        private static readonly object lockS = new object();//确保线程同步

        private  SingelIWebDriver()

        {

        }

        public static IWebDriver getChromesingleton()

        {

            if (IWebDriver == null)

                lock (lockS)

                {
                    if (IWebDriver == null)
                    {
                        ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                        driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口
                        IWebDriver IWebDriver = new ChromeDriver(driverService);
                    }
                }
            return IWebDriver;
        }

    

   }
}
