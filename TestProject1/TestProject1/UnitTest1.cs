using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System.Threading;
using Xunit;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Send API login
            //Get cookie from API response(of login)
            //Change cokie (API) for browser

            //Open browser
            //Set cookie to browser
            //Open site (profile page)

            //data Katrin.shugay@gmail.com        barraki01
            var headers = new Dictionary<string, string>
            {
                {"Content-type","application/x-www-form-urlencoded" }
                
                
            };
            var body = new Dictionary<string, string>
            {
                {"ulogin","art1613122" },
                { "upassword","505558545"}
              
            };

            IWebDriver driver = new ChromeDriver();
         
            
            var response = ApiHelp.SendJsonApiRequest(body, headers, "https://my.soyuz.in.ua/index.php", Method.POST);
            var cookie = ApiHelp.ExtractCookie(response, "zbs_lang");
            var cookie2 = ApiHelp.ExtractCookie(response, "ulogin");
            var cookie3 = ApiHelp.ExtractCookie(response, "upassword");

            driver.Navigate().GoToUrl("https://my.soyuz.in.ua");

            driver.Manage().Cookies.AddCookie(cookie);
            driver.Manage().Cookies.AddCookie(cookie2);
            driver.Manage().Cookies.AddCookie(cookie3);

            driver.Navigate().GoToUrl("https://my.soyuz.in.ua/index.php");
            driver.Quit();

        }
    }
}
