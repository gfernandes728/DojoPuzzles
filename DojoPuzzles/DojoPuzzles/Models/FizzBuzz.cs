using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class FizzBuzz
    {
        public List<FizzBuzzModels> listFizzBuzz = new List<FizzBuzzModels>();

        /// <summary>
        /// FizzBuzz
        /// 
        /// Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:
        /// + Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
        /// + Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
        /// + Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
        /// </summary>
        /// <param name="fizzBuzzModels"></param>
        public void calcular(FizzBuzzModels fizzBuzzModels)
        {
            int start = fizzBuzzModels.start;
            int end = fizzBuzzModels.end;

            listFizzBuzz.Clear();

            string result = "";
            bool is_divided_by_3 = false;
            bool is_divided_by_5 = false;

            while (start <= end)
            {
                is_divided_by_3 = ((start % 3) == 0) ? true : false;
                is_divided_by_5 = ((start % 5) == 0) ? true : false;

                result = "";
                result += (is_divided_by_3) ? "Fizz" : "";
                result += (is_divided_by_5) ? "Buzz" : "";

                FizzBuzzModels fizzBuzz = new FizzBuzzModels();
                fizzBuzz.count = start;
                fizzBuzz.result = (result.Length == 0) ? start.ToString() : result;
                listFizzBuzz.Add(fizzBuzz);

                start++;
            }
        }
    }
}