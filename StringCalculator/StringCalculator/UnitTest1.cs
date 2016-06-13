using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class CalculadoraTest
    {
        [TestMethod]
        public void ConsegueCriarClasseCalculadora()
        {
            var calculadora = new Calculadora();
        }
    }
}
