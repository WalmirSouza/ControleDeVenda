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
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
            Assert.AreEqual("Logradouro Não Deve Ser Nulo ou Branco!", ex.Message);
        }

        [TestMethod]
        public void QuandoLogradouroMaiorQue15Caracteres_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "1234567890123456"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
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
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
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
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
            Assert.AreEqual("Numero deve entre de 1 a 15 Caracteres!", ex.Message);
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
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
            Assert.AreEqual("Número Não Deve Ser Nulo ou Branco!", ex.Message);
        }

        [TestMethod]
        public void QuandoBairroMaiorQue15Caracteres_DeveRetornarErro()
        {
            var endereco = new Endereco
            {
                Logradouro = "123456789012345",
                Numero = "1234567890123456"
            };
            var ex = Asserts.Throws<ApplicationException>(() => endereco.EhValido());
            Assert.IsNotNull(ex);
            Assert.AreEqual("Numero deve entre de 1 a 15 Caracteres!", ex.Message);
        }
    }
}
