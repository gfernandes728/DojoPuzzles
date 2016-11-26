using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class Bissexto
    {
        public List<BissextoModels> listBissexto = new List<BissextoModels>();

        /// <summary>
        /// Ano Bissexto
        /// A cada 4 anos, a diferença de horas entre o ano solar e o do calendário convencional completa cerca de 24 horas(mais exatamente: 23 horas, 15 minutos e 864 milésimos de segundo). Para compensar essa diferença e evitar um descompasso em relação às estações do ano, insere-se um dia extra no calendário e o mês de fevereiro fica com 29 dias.Essa correção é especialmente importante para atividades atreladas às estações, como a agricultura e até mesmo as festas religiosas.
        /// Um determinado ano é bissexto se:
        /// O ano for divisível por 4, mas não divisível por 100, exceto se ele for também divisível por 400.
        /// Exemplos:
        /// São bissextos por exemplo: 1600, 1732, 1888, 1944, 2008
        /// Não são bissextos por exemplo: 1742, 1889, 1951, 2011
        /// Escreva uma função que determina se um determinado ano informado é bissexto ou não.
        /// </summary>
        /// <param name="bissextoModels"></param>
        public void calcular(BissextoModels bissextoModels)
        {
            int year = bissextoModels.year;

            BissextoModels bissexto = new BissextoModels();
            bissexto.year = year;

            string result = year.ToString();

            bool is_divided_by_4 = ((year % 4) == 0) ? true : false;
            bool is_divided_by_100 = ((year % 100) == 0) ? true : false;
            bool is_divided_by_400 = ((year % 400) == 0) ? true : false;

            bool is_bissessto = (is_divided_by_4 && !is_divided_by_100) ? true : false;
            is_bissessto = (is_divided_by_4 && is_divided_by_100 && is_divided_by_400) ? true : is_bissessto;

            result += (is_bissessto) ? " é ano bissexto" : " não é ano bissexto";

            bissexto.result = result;

            listBissexto.Add(bissexto);
        }
    }
}