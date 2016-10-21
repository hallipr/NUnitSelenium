using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumExample
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            using (var webDriver = new LoggingDriver())
            {
                webDriver.Navigate().GoToUrl("https://www.bing.com");
                
                var searchBox = webDriver.Wait(TimeSpan.FromSeconds(5), x => x.FindElement(By.Id("sb_form_q")));
                searchBox.SendKeys("Selenium");

                var searchButton = webDriver.Wait(TimeSpan.FromSeconds(5), x => x.FindElement(By.Id("sb_form_go")));
                searchButton.Click();

                var results = webDriver.FindElementsByCssSelector("#b_results li");

                var resultLink = results.Where(x => x.Text.Contains("Documentation"))
                    .Select(x => x.FindElement(By.TagName("a")))
                    .FirstOrDefault();

                Assert.That(resultLink, Is.Not.Null);
                resultLink.Click();
                Assert.That(webDriver.Url, Is.EqualTo("http://docs.seleniumhq.org/"));
            }
        }
    }
}
