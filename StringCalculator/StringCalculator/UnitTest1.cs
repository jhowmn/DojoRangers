using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class CalculadoraTest
    {
        [TestMethod]
        public void SeAdicionarValorVazio_RetornaZero()
        {
            var calculadora = new Calculadora();

            Assert.AreEqual(0, calculadora.Adicionar(""));
        }

        [TestMethod]
        public void SeAdicionarUmNumero_RetornaOMesmoNumero()
        {
            var calculadora = new Calculadora();

            Assert.AreEqual(1, calculadora.Adicionar("1"));
        }
    }
}
