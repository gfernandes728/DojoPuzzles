using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class Collatz
    {
        public List<CollatzModels> listCollatz = new List<CollatzModels>();

        /// <summary>
        /// Calcular Collatz
        /// </summary>
        /// <param name="collatzModels"></param>
        public void calcular(CollatzModels collatzModels)
        {
            int number = collatzModels.number;

            CollatzModels collatz = new CollatzModels();
            collatz.number = number;

            string result = number.ToString();
            bool can_escape = false;
            while (!can_escape)
            {
                number = ((number % 2) == 0) // verificar se "number" é divisível por 2
                    ? (number / 2) // se "number" for par
                    : ((3 * number) + 1);  // se "number" for ímpar

                result += " -> " + number.ToString();
                can_escape = (number == 1) ? true : false; // Sair do while se "number" for 1
            }

            collatz.result = result;

            listCollatz.Add(collatz);
        }
    }
}