using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAuto.Logic;
using WebAuto.Model;

namespace WebAuto
{
    public partial class Form1 : Form
    {
        IWebDriver browser;
        OneDriver od = new OneDriver();
        ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
        LogicDal log = new LogicDal();
        WebDriverDal wd = new WebDriverDal();
        string LoginUrl = ConfigurationManager.AppSettings["WorkTable"];
        string WorkTable = ConfigurationManager.AppSettings["WorkTable"];
        public Form1()
        {
            InitializeComponent();
            this.txtAccount.Text = ConfigurationManager.AppSettings["UserAccount"];
            this.txtPassWord.Text = ConfigurationManager.AppSettings["PassWord"];
            driverService.HideCommandPromptWindow = true;//关闭黑色cmd窗口
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            await Isinit();
        }

        public static Bitmap GetElementScreenShort(IWebDriver driver, IWebElement element)
        {
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;

            img = img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
            return img;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (browser != null)
            {
                //窗口关闭前记得浏览器,否则驱动会残留在进程里面
                browser.Quit();
                driverService.Dispose();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Isinit();
            if (!browser.Url.Contains("login"))
            {
                browser.Navigate().GoToUrl(WorkTable);
            }
        }
        private Task Isinit()
        {
            return Task.Run(() =>
            {
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    this.menuStrip1.Enabled = false;
                });
                this.BeginInvoke(mi);
                if (browser == null)
                {
                    browser = new ChromeDriver(driverService);
                    browser.Manage().Window.Maximize();
                    browser.Navigate().GoToUrl(LoginUrl);
                    //  browser.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(15);
                    browser.FindElement(By.XPath("//*[@id=\"swy\"]")).SendKeys(this.txtAccount.Text);
                    browser.FindElement(By.XPath("//*[@id=\"swm2\"]")).SendKeys(this.txtPassWord.Text);

                    if (browser.FindElements(By.ClassName("yzmimg")).Count > 0)
                    {
                        var element = browser.FindElements(By.Id("vcode"))[0];
                        var img = GetElementScreenShort(browser, element);

                        var v = Regex.Replace(od.imgdo(img), "[\\s\r\n\\[ \\] \\^ \\-_*×――(^)（^）$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’'“”-]", "");
                        browser.FindElement(By.XPath("//*[@id=\"verifyCode\"]")).SendKeys(v);
                    }
                    //browser.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();
                    //browser.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);


                    //browser.FindElement(By.XPath("//*[@id=\"su\"]")).Click();
                    //browser.Close();
                }
                mi = new MethodInvoker(() =>
               {
                   this.menuStrip1.Enabled = true;
               });
                this.BeginInvoke(mi);
            });
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await Isinit();
            browser.FindElement(By.XPath("//*[@id=\"swy\"]")).Clear();
            browser.FindElement(By.XPath("//*[@id=\"swm2\"]")).Clear();
            browser.FindElement(By.XPath("//*[@id=\"swy\"]")).SendKeys(this.txtAccount.Text);
            browser.FindElement(By.XPath("//*[@id=\"swm2\"]")).SendKeys(this.txtPassWord.Text);
        }

        private void APToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取元素的Value
            config.AppSettings.Settings["UserAccount"].Value = this.txtAccount.Text;
            config.AppSettings.Settings["PassWord"].Value = this.txtPassWord.Text;
            config.Save(ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("新的账户密码保存成功");
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            await
                Task.Run(() =>
                {
                    try
                    {
                        Button btn = (Button)sender;
                        InBusinessNoEntity ib = new InBusinessNoEntity();
                        ib.BusinessNo = this.txtInBusinessNo.Text;
                        ib = log.GetBusinessNoEntity(ib);
                        var keyword = ConfigurationManager.AppSettings[btn.Tag.ToString()];
                        browser.SwitchTo().DefaultContent();
                        browser.FindElement(By.XPath($"//a[contains(@data-id,'{ keyword}')]")).Click();
                        IWebElement inweb = browser.FindElement(By.XPath($"//iframe[contains(@src,'{ keyword}')]"));
                        browser.SwitchTo().Frame(inweb);
                        wd.InitWebValue<InBusinessNoEntity>(ib, browser);
                        //browser.FindElement(By.XPath("//*[@id=\"customMasterName\"]")).SendKeys("海关总署");
                        //browser.FindElement(By.XPath("//*[@id=\"manualNo\"]")).SendKeys(this.txtAccount.Text);
                    }
                    catch (NoSuchElementException ex)
                    {
                        MessageBox.Show("请确定页面已经打开" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
    }
}
