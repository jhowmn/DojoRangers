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

            return int.Parse(valor);
        }
    }
}