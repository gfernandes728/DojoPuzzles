using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class Estatisticas
    {
        public List<EstatisticasModels> listEstatisticas = new List<EstatisticasModels>();

        /// <summary>
        /// Calculando estatísticas simples
        /// Sua tarefa é processar uma seqüência de números inteiros para determinar as seguintes estatísticas:
        /// + Valor mínimo
        /// + Valor máximo
        /// + Número de elementos na seqüência
        /// + Valor médio
        /// Por exemplo para uma seqüência de números "6,9,15,-2,92,11", temos como saída:
        /// + Valor mínimo: -2
        /// + Valor máximo: 92
        /// + Número de elementos na seqüência: 6
        /// + Valor médio: 21.8333333
        /// </summary>
        /// <param name="estatisticasModels"></param>
        public void calcular(EstatisticasModels estatisticasModels)
        {
            string sequencia = estatisticasModels.sequencia;
            string[] split = sequencia.Split(',');

            EstatisticasModels estatisticas = new EstatisticasModels();
            estatisticas.sequencia = sequencia;

            int count = split.Length;
            estatisticas.count = count;

            int minimo = 0;
            int maximo = 0;
            int c = 0;
            int get = 0;
            double sum = 0;
            while (c < count)
            {
                get = Convert.ToInt32(split[c]);

                switch (c)
                {
                    case 0:
                        minimo = get;
                        maximo = get;
                        break;
                    default:
                        minimo = (get < minimo) ? get : minimo;
                        maximo = (get > maximo) ? get : maximo;
                        break;
                }

                sum += get;

                c++;
            }

            estatisticas.minimo = minimo;
            estatisticas.maximo = maximo;
            estatisticas.media = sum / 6;

            listEstatisticas.Add(estatisticas);
        }
    }
}