using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    public static class Extensions
    {
        public static T Wait<T>(this IWebDriver webDriver, Func<IWebDriver, T> condition)
        {
            return Wait(webDriver, TimeSpan.FromSeconds(5), condition);
        }

        public static T Wait<T>(this IWebDriver webDriver, TimeSpan timeout, Func<IWebDriver, T> condition)
        {
            var wait = new WebDriverWait(webDriver, timeout);
            return wait.Until(condition);
        }
    }
}