using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class CalculadoraTest
    {
        private static Calculadora calculadora;

        [ClassInitialize]
        public static void InicializarClasse(TestContext context)
        {
            calculadora = new Calculadora();
        }

        [TestMethod]
        public void SeAdicionarValorVazio_RetornaZero()
        {
            Assert.AreEqual(0, calculadora.Adicionar(""));
        }

        [TestMethod]
        public void SeAdicionarUmNumero_RetornaOMesmoNumero()
        {
            Assert.AreEqual(1, calculadora.Adicionar("1"));
        }

        [TestMethod]
        public void SeAdicionarDoisOuMaisNumeros_RetornaASoma()
        {
            Assert.AreEqual(5, calculadora.Adicionar("2,3"));
        }
    }
}
