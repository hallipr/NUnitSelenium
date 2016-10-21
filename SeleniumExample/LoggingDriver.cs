using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumExample
{
    public class LoggingDriver : ChromeDriver
    {
        private int i = 0;

        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            var stopwatch = Stopwatch.StartNew();
            var instance = i++;
            Debug.WriteLine($"Start {instance} {driverCommandToExecute} w/ {JsonConvert.SerializeObject(parameters)}");
            var result = base.Execute(driverCommandToExecute, parameters);
            Debug.WriteLine($"End {instance} {stopwatch.ElapsedMilliseconds}");
            return result;
        }
    }
}