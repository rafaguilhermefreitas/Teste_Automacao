using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Correios2.Drivers
{
	public static class WebDriverFactory
	{
		public static IWebDriver Driver { get; private set; }

		public static void InitDriver()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());

			var options = new ChromeOptions();
			options.AddArgument("--start-maximized");

			Driver = new ChromeDriver(options);
		}

		public static void QuitDriver()
		{
			Driver?.Quit();
			Driver = null;
		}
	}
}
