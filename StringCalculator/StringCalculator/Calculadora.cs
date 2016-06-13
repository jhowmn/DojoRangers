using System;

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
            var numeroses = numeros.Split(ObterDelimitadores(), StringSplitOptions.RemoveEmptyEntries);
            int total = 0;
            foreach (var numero in numeroses)
                total += int.Parse(numero);
            return total;
        }

        private string[] ObterDelimitadores()
        {
            return new string[] { ",", "\n", delimitadorCustomizado };
        }

    }
}