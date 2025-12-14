using NUnit.Framework;
using Correios2.Drivers;
using System.Threading;

namespace Correios2.Tests
{
	[TestFixture]
	public class ControleWebDriverTests
	{
		//[Test]
		public void TesteBasico_WebDriver_DeveAbrirEFechar()
		{
			WebDriverFactory.InitDriver();

			WebDriverFactory.Driver.Navigate().GoToUrl("https://www.google.com");

			Thread.Sleep(3000); // só para visualizar

			WebDriverFactory.QuitDriver();

			Assert.Pass("Driver funcionou corretamente");
		}
	}
}
