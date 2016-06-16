using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculadora
    {
        private string delimitadorCustomizado = "";

        public int Somar(string numeros)
        {
            if (string.IsNullOrWhiteSpace(numeros))
                return 0;

            if (PossuiDelimitadorCustomizado(numeros))
                numeros = ObterNumerosComDelimitadorCustomizado(numeros);

            return SomarNumeros(numeros);
        }

        private static bool PossuiDelimitadorCustomizado(string numeros)
        {
            return numeros.StartsWith("//");
        }

        private string ObterNumerosComDelimitadorCustomizado(string numeros)
        {
            var posicaoPrimeiraNovaLinha = numeros.IndexOf('\n');
            delimitadorCustomizado = numeros.Substring(2, posicaoPrimeiraNovaLinha - 2);
            numeros = numeros.Substring(posicaoPrimeiraNovaLinha + 1);
            return numeros;
        }

        private int SomarNumeros(string numeros)
        {
            var numerosSeparados = numeros.Split(ObterDelimitadores(), StringSplitOptions.RemoveEmptyEntries);
            var numerosInteiros = numerosSeparados.Select(s => int.Parse(s));

            if (numerosInteiros.Any(n => n < 0))
                throw new NumbersNotAllowedException(string.Join(",", numerosInteiros.Where(w => w < 0)));

            numerosInteiros = numerosInteiros.Where(n => n <= 1000);

            return numerosInteiros.Sum();
        }

        private string[] ObterDelimitadores()
        {
            return new string[] { ",", "\n", delimitadorCustomizado };
        }
    }
}