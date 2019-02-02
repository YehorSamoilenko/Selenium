using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selenium
{
    public class SeleniumWebDriver
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void startBrowser()
        {
            driver.Navigate().GoToUrl("https://accounts.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void ValidValuesTest()
        {
            string validLogin = "Добро пожаловать, Yehor Samoilenko!";
            driver.FindElement(By.Id("identifierId")).SendKeys("TestSelenium12345678");
            driver.FindElement(By.Id("identifierNext")).Click();
            driver.FindElement(By.Name("password")).SendKeys("12345Qwert");
            driver.FindElement(By.Id("passwordNext")).Click();
            if (driver.FindElement(By.ClassName("x7WrMb")).Text.Equals(validLogin))
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&aqs=chrome..69i57.7952j0j9&sourceid=chrome&ie=UTF-8");
            else driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&aqs=chrome..69i57j0l5.8485j0j7&sourceid=chrome&ie=UTF-8");
        }
        [Test]
        public void WrongLogin()
        {
            string wrongLogin = "Не удалось найти аккаунт Google";
            driver.FindElement(By.Id("identifierId")).SendKeys("TestSelenium123456789");
            driver.FindElement(By.Id("identifierNext")).Click();
            if (driver.FindElement(By.XPath("//div[@class='GQ8Pzc']")).Text.Equals(wrongLogin))
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&aqs=chrome..69i57.7952j0j9&sourceid=chrome&ie=UTF-8");
            else driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&aqs=chrome..69i57j0l5.8485j0j7&sourceid=chrome&ie=UTF-8");
        }
        [Test]
        public void WrongPassword()
        {
            string wrongPassword= "Неверный пароль. Повторите попытку или нажмите на ссылку 'Забыли пароль?', чтобы сбросить его."; // Проверить наличие текста в элементе не вышло, так как фраза - Забыли пароль, должна быть в двойных кавычках. 
            driver.FindElement(By.Id("identifierId")).SendKeys("TestSelenium12345678");
            driver.FindElement(By.Id("identifierNext")).Click();
            driver.FindElement(By.Name("password")).SendKeys("12345Qwerty");
            driver.FindElement(By.Id("passwordNext")).Click();
            if (driver.FindElement(By.XPath("//div[@class='GQ8Pzc']")).Displayed) // Проверяю появился ли элемент с сообщением об ошибке на странице
                driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A3%D1%81%D0%BF%D0%B5%D1%85%2C+%D1%82%D0%B5%D1%81%D1%82+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD!&aqs=chrome..69i57.7952j0j9&sourceid=chrome&ie=UTF-8");
            else driver.Navigate().GoToUrl("https://www.google.com/search?q=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&rlz=1C1CHBD_ruUA834UA834&oq=%D0%A2%D0%B5%D1%81%D1%82+%D0%9D%D0%95+%D0%BF%D1%80%D0%BE%D0%B9%D0%B4%D0%B5%D0%BD.&aqs=chrome..69i57j0l5.8485j0j7&sourceid=chrome&ie=UTF-8");
        }
        
        [TearDown]
        public void closeBrowser()
        {
           driver.Close();
        }

    }
}
