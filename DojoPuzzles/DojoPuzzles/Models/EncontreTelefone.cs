using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class EncontreTelefone
    {
        public List<EncontreTelefoneModels> listEncontreTelefone = new List<EncontreTelefoneModels>();

        /// <summary>
        /// Encontre o telefone
        /// 
        /// Em alguns lugares é comum lembrar um número do telefone associando seus dígitos a letras. Dessa maneira a expressão MY LOVE significa 69 5683. Claro que existem alguns problemas, uma vez que alguns números de telefone não formam uma palavra ou uma frase e os dígitos 1 e 0 não estão associados a nenhuma letra.
        /// 
        /// Sua tarefa é ler uma expressão e encontrar o número de telefone correspondente baseado na tabela abaixo.Uma expressão é composta por letras maiúsculas(A-Z), hifens(-) e os números 1 e 0.
        ///
        /// Letras  ->  Número
        /// ABC     ->  2 
        /// DEF     ->  3 
        /// GHI     ->  4 
        /// JKL     ->  5 
        /// MNO     ->  6 
        /// PQRS    ->  7 
        /// TUV     ->  8 
        /// WXYZ    ->  9 
        ///
        /// Entrada:
        /// A entrada consiste de um conjunto de expressões.Cada expressão está sozinha em uma linha e possui C caracteres, onde 1 ≤ C ≤ 30. A entrada é terminada por fim de arquivo(EOF).
        ///
        /// Saída:
        /// Para cada expressão você deve imprimir o número de telefone correspondente.
        ///
        /// Exemplo de entrada:
        /// 1-HOME-SWEET-HOME
        /// MY-MISERABLE-JOB
        ///
        /// Saída correspondente:
        /// 1-4663-79338-4663 
        /// 69-647372253-562
        ///
        /// Curiosidades:
        /// A frase "The quick brown fox jumps over the lazy dog" é um pangrama (frase com sentido em que são usadas todas as letras do alfabeto de determinada língua) da língua inglesa.
        /// </summary>
        /// <param name="encontreTelefoneModels"></param>
        public void calcular(EncontreTelefoneModels encontreTelefoneModels)
        {
            Util _util = new Util();
            ArrayList chars = _util.getCharsTelefone();

            string codigo = encontreTelefoneModels.codigo;
            string telefone = "";
            string get_chars = "";
            string get_codigo = "";

            int len = codigo.Length;
            int c = 0;
            int g = 0;

            bool has_new_codigo = false;

            while(c < len)
            {
                get_codigo = codigo[c].ToString();
                g = 0;
                has_new_codigo = false;

                while (g < 8)
                {
                    get_chars = chars[g].ToString();
                    if (get_chars.Contains(get_codigo))
                    {
                        telefone += (g + 2).ToString();
                        has_new_codigo = true;
                        g = 8;
                    }
                    g++;
                }

                telefone += (has_new_codigo) ? "" : get_codigo;
                c++;
            }

            EncontreTelefoneModels encontreTelefone = new EncontreTelefoneModels();
            encontreTelefone.codigo = codigo;
            encontreTelefone.telefone = telefone;
            listEncontreTelefone.Add(encontreTelefone);
        }
    }
}