using TechTalk.SpecFlow;
using Correios2.Drivers;

namespace Correios2.Hooks
{

	[Binding]
	public class Hooks
	{
		[BeforeScenario]
		public void BeforeScenario()
		{
			WebDriverFactory.InitDriver();
		}

		[AfterScenario]
		public void AfterScenario(ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError != null)
			{
				System.Threading.Thread.Sleep(2000); // só se falhar
			}

			WebDriverFactory.QuitDriver();
		}
	}
}
