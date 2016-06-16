using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculadora
    {
        private List<string> delimitadoresCustomizados = new List<string>();

        public Calculadora()
        {
            delimitadoresCustomizados.Add(",");
            delimitadoresCustomizados.Add("\n");
        }

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
            var delimitadores = numeros.Substring(2, posicaoPrimeiraNovaLinha - 2);
            delimitadoresCustomizados.AddRange(delimitadores.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries));
            return numeros.Substring(posicaoPrimeiraNovaLinha + 1);
        }

        private int SomarNumeros(string numeros)
        {
            var numerosSeparados = numeros.Split(delimitadoresCustomizados.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var numerosInteiros = numerosSeparados.Select(s => int.Parse(s));

            if (numerosInteiros.Any(n => n < 0))
                throw new NumbersNotAllowedException(string.Join(",", numerosInteiros.Where(w => w < 0)));

            numerosInteiros = numerosInteiros.Where(n => n <= 1000);

            return numerosInteiros.Sum();
        }
    }
}