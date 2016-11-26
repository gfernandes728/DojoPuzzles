using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class EscrevendoCelular
    {
        public List<EscrevendoCelularModels> listEscrevendoCelular = new List<EscrevendoCelularModels>();

        /// <summary>
        /// Escrevendo no Celular
        /// 
        /// Um dos serviços mais utilizados pelos usuários de aparelhos celulares são os SMS (Short Message Service), que permite o envio de mensagens curtas (até 255 caracteres em redes GSM e 160 caracteres em redes CDMA).
        /// 
        /// Para digitar uma mensagem em um aparelho que não possui um teclado QWERTY embutido é necessário fazer algumas combinações das 10 teclas numéricas do aparelho para conseguir digitar.Cada número é associado a um conjunto de letras como a seguir:
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
        /// Espaço  ->  0 
        /// 
        /// Desenvolva um programa que, dada uma mensagem de texto limitada a 255 caracteres, retorne a seqüência de números que precisa ser digitada.Uma pausa, para ser possível obter duas letras referenciadas pelo mesmo número, deve ser indicada como _.
        /// 
        /// Por exemplo, para digitar "SEMPRE ACESSO O DOJOPUZZLES", você precisa digitar:
        /// 77773367_7773302_222337777_777766606660366656667889999_9999555337777
        /// </summary>
        /// <param name="escrevendoCelularModels"></param>
        public void calcular(EscrevendoCelularModels escrevendoCelularModels)
        {
            Util _util = new Util();

            ArrayList chars = _util.getCharsTelefone();
            chars.Add(" ");         // 0 -> Espaço  (8)
            chars.Add("123456790"); // n -> Números (9)

            string texto = escrevendoCelularModels.texto;
            string sequencia = "";
            string get_texto = "";
            string get_chars = "";
            string get_sequencia = "";

            int get_g = -1;
            int old_g = -1;

            int len = texto.Length;
            int c = 0;
            int g = 0;

            while (c < len)
            {
                get_texto = texto[c].ToString().ToUpper();
                g = 0;

                while (g < 10)
                {
                    get_chars = chars[g].ToString();
                    if (get_chars.Contains(get_texto))
                    {
                        switch (g)
                        {
                            case 8:
                                get_sequencia = "0";
                                get_g = g;
                                break;
                            case 9:
                                get_sequencia = get_texto;
                                get_g = Convert.ToInt32(get_texto);
                                break;
                            default:
                                get_sequencia = verifySequencia(get_chars, get_texto, (g + 2).ToString());
                                get_g = g;
                                break;
                        }
                        g = 10;
                    }
                    g++;
                }

                sequencia += (get_g == old_g) ? "_" : "";
                sequencia += get_sequencia;
                old_g = get_g;

                c++;
            }

            EscrevendoCelularModels escrevendoCelular = new EscrevendoCelularModels();
            escrevendoCelular.texto = texto;
            escrevendoCelular.sequencia = sequencia;
            listEscrevendoCelular.Add(escrevendoCelular);
        }

        /// <summary>
        /// Verificar sequência e número de vezes para chegar a letra pretendida
        /// </summary>
        /// <param name="get_chars">string</param>
        /// <param name="get_texto">string</param>
        /// <param name="g">string</param>
        /// <returns>string Sequência obtida</returns>
        private string verifySequencia(string get_chars, string get_texto, string g)
        {
            int len = get_chars.Length;
            int c = 0;
            string sequencia = "";
            bool has_sequencia = false;

            while (!has_sequencia)
            {
                sequencia += g;
                if (get_chars[c].ToString() == get_texto)
                    has_sequencia = true;

                c++;
            }

            return sequencia;
        }
    }
}