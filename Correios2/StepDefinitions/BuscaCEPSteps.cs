using Correios2.Drivers;
using Correios2.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Correios2.StepDefinitions
{
	[Binding]
	public class BuscaCEPSteps
	{
		private CorreiosPage page => new CorreiosPage(WebDriverFactory.Driver);

		[Given(@"que acesso o site dos Correios")]
		public void DadoQueAcessoOSite()
		{
			page.AcessarSite();
		}

		[When(@"realizo a busca pelo CEP ""(.*)""")]
		public void QuandoBuscoOCep(string cep)
		{
			page.BuscarCep(cep);
		}

		[Then(@"devo ver a mensagem de CEP inexistente ou Preencha o campo Captcha")]
		public void EntaoValidoCepInexistente()
		{
			Assert.That(page.CepNaoRetornaResultado(), Is.True,
				"Preencha o campo Captcha! (texto contido na imagem)");
		}

		[Then(@"o endereço exibido deve ser ""(.*)""")]
		public void EntaoValidoEndereco(string endereco)
		{
			Assert.That(page.ObterMensagemResultado(),
				Does.Contain(endereco));
		}

		[When(@"retorno para a tela inicial")]
		public void QuandoVoltoTelaInicial()
		{
			page.VoltarTelaInicial();
		}

		[When(@"vai para a tela rastreamento")]
		public void QuandoVouPraRastreamento()
		{
			page.VoltarTelaRastreio();
		}

		[When(@"realizo a busca de rastreamento pelo codigo ""(.*)""")]
		public void QuandoRealizoABuscaDeRastreamento(string codigo)
		{
			page.PreencherCodigoRastreamento(codigo);
		}

		[Then(@"devo ver a mensagem de código inválido")]
		public void EntaoValidoCodigoInvalido()
		{
			Assert.That(page.ObterMensagemResultado(),
				Does.Contain("não está correto"));
		}
	}
}
