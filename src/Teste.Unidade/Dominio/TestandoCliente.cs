using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.PlenoControle.Dominio.Entidades;
using MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Abstracao;
using System;

namespace MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Dominio
{
	[TestClass]
	public class TestandoCliente
	{
		[TestMethod]
		public void QuandoInformarNomeBrancoOuNulo_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = ""
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("Nome não Pode ser Branco ou Nulo!", ex.Message);
		}

		[TestMethod]
		public void QuandoNomeContiverMenosDe6Caracteres_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "AAAAA"
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("Nome Deve ter mais de 6 Cadacteres!", ex.Message);
		}

		[TestMethod]
		public void QuandoNomeContiverCaracteresEspeciais_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "AAAAA@%$"
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("Nome Não Deve Conter Cadacteres Especiais!", ex.Message);
		}

		[TestMethod]
		public void QuandoNomeContiverNumeros_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "AAAAA123"
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("Nome Não Deve Conter Numeros!", ex.Message);
		}

		[TestMethod]
		public void QuandoCPFForBrancoOuNulo_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "Jorge Luiz",
				CPF = ""
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("CPF não Deve ser Nulo!", ex.Message);
		}

		[TestMethod]
		public void QuandoCPFContiverLetras_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "Jorge Luiz",
				CPF = "123XXX"
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("CPF deve conter apenas Numeros!", ex.Message);
		}

		[TestMethod]
		public void QuandoCPFForMenorQue11_DeveRetornarErro()
		{
			var cliente = new Cliente
			{
				Nome = "Jorge Luiz",
				CPF = "0135837375"
			};
			var ex = Asserts.Throws<ApplicationException>(() => cliente.EhValido());
			Assert.IsNotNull(ex);
			Assert.AreEqual("Quantidade de Dígitos de CPF deve Ser Igual a 11!", ex.Message);
		}
	}
}