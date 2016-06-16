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
        public void SeSomarValorVazio_RetornaZero()
        {
            Assert.AreEqual(0, calculadora.Somar(""));
        }

        [TestMethod]
        public void SeSomarUmNumero_RetornaOMesmoNumero()
        {
            Assert.AreEqual(1, calculadora.Somar("1"));
        }

        [TestMethod]
        public void SeSomarDoisOuMaisNumeros_RetornaASoma()
        {
            Assert.AreEqual(5, calculadora.Somar("2,3"));
            Assert.AreEqual(19, calculadora.Somar("5,3,7,4"));
        }

        [TestMethod]
        public void SeSeparadorForNovaLinha_RetornaASoma()
        {
            Assert.AreEqual(19, calculadora.Somar("5\n3,7,4"));
        }

        [TestMethod]
        public void SeHouverSeparadorCustomizado_RetornaASoma()
        {
            Assert.AreEqual(6, calculadora.Somar("//[;]\n1;2;3"));
            Assert.AreEqual(6, calculadora.Somar("//[victor]\n1victor2victor3"));
        }

        [TestMethod]
        public void SeHouverNumerosNegativos_RetornaExcecao()
        {
            try
            {
                calculadora.Somar("-5,-9");
                Assert.Fail();
            }
            catch (NumbersNotAllowedException ex)
            {
                Assert.AreEqual("-5,-9", ex.Message);
            }
        }

        [TestMethod]
        public void SeHouverNumeroMaiorQueMil_DeveSerIgnoradoNaSoma()
        {
            Assert.AreEqual(1006, calculadora.Somar("//[;]\n1;2;3;1000"));
            Assert.AreEqual(6, calculadora.Somar("//[;]\n1;2;3;1002"));
        }

        [TestMethod]
        public void DelimitadoresPodemTerQualquerTamanhoDesdeQueEstejamEntreColchetes()
        {
            Assert.AreEqual(6, calculadora.Somar("//[%]\n1%2%3"));
            Assert.AreEqual(6, calculadora.Somar("//[***]\n1***2***3"));
        }
    }
}