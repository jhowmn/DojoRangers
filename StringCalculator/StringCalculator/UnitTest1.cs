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
    }
}
