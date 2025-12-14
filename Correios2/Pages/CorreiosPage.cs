using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Correios2.Pages
{
	public class CorreiosPage
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public CorreiosPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		// ========= AÇÕES =========

		public void AcessarSite()
		{
			driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php?");
			Thread.Sleep(2000); // só para visualizar
		}

		public void BuscarCep(string cep)
		{
			var campoCep = wait.Until(d =>
			{
				var el = d.FindElement(By.Id("endereco"));
				return el.Displayed ? el : null;
			});

			campoCep.Clear();
			campoCep.SendKeys(cep);
			campoCep.SendKeys(Keys.Enter);
			Thread.Sleep(2000); // só para visualizar
		}

		public bool CepNaoRetornaResultado()
		{
			// Aguarda a página processar a busca (JS)
			Thread.Sleep(2000);

			var tabelas = driver.FindElements(By.Id("resultado-dnec"));

			// Se não existe nenhuma tabela, o CEP é inexistente
			return tabelas.Count == 0;
		}

		public void VoltarTelaInicial()
		{
			driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php?");
			Thread.Sleep(2000); // só para visualizar
		}

		public void VoltarTelaRastreio()
		{
			driver.Navigate().GoToUrl("https://rastreamento.correios.com.br/app/index.php");
			Thread.Sleep(2000); // só para visualizar
		}

		public CorreiosPage ClicarBuscarRastreamento()
		{
			driver.FindElement(By.Id("btnPesq")).Click();
			return this;
		}

		public CorreiosPage PreencherCodigoRastreamento(string codigo)
		{
			var campoDoc = wait.Until(d =>
			{
				var el = d.FindElement(By.Id("objeto"));
				return el.Displayed ? el : null;
			});

			campoDoc.Clear();
			campoDoc.SendKeys(codigo);
			campoDoc.SendKeys(Keys.Enter);
			Thread.Sleep(2000); // só para visualizar
			return this;
		}
		

		// ========= VALIDAÇÃO =========

		public string ObterMensagemResultado()
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

			var mensagemElemento = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("Preencha o campo Captcha! (texto contido na imagem)")));
			// Retorna o texto da mensagem
			return mensagemElemento.Text;
		}
	}
}
