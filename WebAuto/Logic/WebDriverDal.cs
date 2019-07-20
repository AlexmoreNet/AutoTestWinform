using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAuto.Logic
{
    public class WebDriverDal
    {
        public void InitWebValue<T>(T entity, IWebDriver driver)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                try
                {
                    var value = item.GetValue(entity, null);
                    if (value == null) continue;
                    driver.FindElement(By.XPath($"//*[@id=\"{item.Name}\"]")).SendKeys(value.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
