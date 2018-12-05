using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.PlenoControle.Dominio.Entidades;
using MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Abstracao;
using System;

namespace MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Dominio.Entidades
{
	[TestClass]
	public class TestandoEndereco
	{
		[TestMethod]
		public void QuandoLogradouroBrancoOuNulo_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = ""
			};
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Logradouro Não Deve Ser Nulo ou Branco!", ex.Message);
		}

		[TestMethod]
		public void QuandoLogradouroMaiorQue15Caracteres_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = "1234567890123456"
			};
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Logradouro deve entre de 1 a 15 Caracteres!", ex.Message);
		}

		[TestMethod]
		public void QuandoNumeroNuloOuBranco_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = "123456789012345",
				Numero = ""
			};
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Número Não Deve Ser Nulo ou Branco!", ex.Message);
		}

		[TestMethod]
		public void QuandoNumeroMaiorQue15Caracteres_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = "123456789012345",
				Numero = "1234567890123456"
			};
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Número deve ter entre de 1 e 15 Caracteres!", ex.Message);
		}

		[TestMethod]
		public void QuandoBairroNuloOuBranco_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = "123456789012345",
				Numero = "123445",
				Bairro = ""
			};
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Bairro Não Deve Ser Nulo ou Branco!", ex.Message);
		}

		[TestMethod]
		public void QuandoBairroMaiorQue15Caracteres_DeveRetornarErro()
		{
			var endereco = new Endereco
			{
				Logradouro = "123456789012345",
				Numero = "1234567",
                Bairro = "1234567890123456"
            };
			var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
			Assert.AreEqual("Bairro deve ter entre de 1 e 15 Caracteres!", ex.Message);
		}

        [TestMethod]
        public void QuandoCidadeNuloOuBranco_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = ""
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("Cidade Não Deve Ser Nulo ou Branco!", ex.Message);
        }

        [TestMethod]
        public void QuandoCidadeMaiorQue15Caracteres_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123123456789012346"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("Cidade deve ter entre de 1 e 15 Caracteres!", ex.Message);
        }

        [TestMethod]
        public void QuandoEstadoNuloOuBranco_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "1234",
                Estado = ""
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("Estado Não Deve Ser Nulo ou Branco!", ex.Message);
        }

        [TestMethod]
        public void QuandoEstadoMaiorQue2Caracteres_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123",
                Estado = "RJJ"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("Estado deve ter 2 Caracteres!", ex.Message);
        }

        [TestMethod]
        public void QuandoEstadoConterNumeros_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123",
                Estado = "12"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("Estado só deve conter Letras!", ex.Message);
        }

        [TestMethod]
        public void QuandoCEPNuloOuBranco_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123",
                Estado = "RJ",
                CEP    = ""
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("CEP Não deve ser Nulo", ex.Message);
        }

        [TestMethod]
        public void QuandoCEPConterLetras_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123",
                Estado = "RJ",
                CEP = "1A1A1a1a"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("CEP Não Pode Conter Letras!", ex.Message);
        }

        [TestMethod]
        public void QuandoCEPMenorQue8Digitos_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "123456789012345",
                Bairro = "123",
                Cidade = "123",
                Estado = "RJ",
                CEP = "11"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.Validar());
            Assert.AreEqual("CEP Não Pode Conter Menos de 8 digitos!", ex.Message);
        }
    }
}