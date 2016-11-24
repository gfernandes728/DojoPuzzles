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
        /// Analisando a conjectura de Collatz
        /// Para definir uma seqüência a partir de um número inteiro o positivo, temos as seguintes regras:
        /// n → n/2 (n é par)
        /// n → 3n + 1 (n é ímpar)
        /// Usando a regra acima e iniciando com o número 13, geramos a seguinte seqüência:
        /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
        /// Podemos ver que esta seqüência(iniciando em 13 e terminando em 1) contém 10 termos.Embora ainda não tenha sido provado(este problema é conhecido como Problema de Collatz), sabemos que com qualquer número que você começar, a seqüência resultante chega no número 1 em algum momento.
        /// Desenvolva um programa que descubra qual o número inicial entre 1 e 1 milhão que produz a maior seqüência.
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
                    ? (number / 2) // "number" → "number"/2 ("number" é par)
                    : ((3 * number) + 1);  // "number" → (3 * "number") + 1 ("number" é ímpar)

                result += " -> " + number.ToString();
                can_escape = (number == 1) ? true : false; // Sair do while se "number" for 1
            }

            collatz.result = result;

            listCollatz.Add(collatz);
        }
    }
}