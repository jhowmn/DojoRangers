using System;

namespace StringCalculator
{
    internal class Calculadora
    {
        public Calculadora()
        {
        }

        public int Adicionar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return 0;

            var valores = valor.Split(',', '\n');

            int total = 0;
            foreach(var numero in valores)
                total += int.Parse(numero);

            return total;
        }
    }
}