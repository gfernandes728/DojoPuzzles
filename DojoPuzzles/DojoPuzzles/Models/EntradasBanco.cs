using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace DojoPuzzles.Models
{
    public class EntradasBanco
    {
        public List<EntradasBancoModels> listEntradasBanco = new List<EntradasBancoModels>();

        /// <summary>
        /// Caminho para gravar e ler arquivo de log
        /// </summary>
        private string file = @"C:\Users\Gustavo Fernandes\Downloads\EntradasBanco.txt";

        /// <summary>
        /// Entradas no Banco
        /// Todas as vezes que alguém passa na porta do maior banco da cidade de Pirenópolis, é gravado em um arquivo de log a data e a hora da abertura da porta.
        /// Cada registro no arquivo de log possui o seguinte formato:
        /// + [YYYY-mm-dd H:i:s] - Abertura da Porta OK
        /// O gerente do banco precisa saber quantas pessoas entraram no banco no horário de expediente, para isso ele solicitou que você faça um programa que verifique se o registro de entrada é válido e se a hora se encontra dentro do intervalo de funcionamento do banco, das 10:00:00 até as 16:00:00.
        /// </summary>
        /// <param name="entradasBancoModels"></param>
        public void calcular(EntradasBancoModels entradasBancoModels)
        {
            DateTime dtNow = DateTime.Now;
            int year = dtNow.Year;
            int month = dtNow.Month;
            int day = dtNow.Day;

            DateTime dtAbertura = new DateTime(year, month, day, 10, 0, 0);
            DateTime dtFechamento = new DateTime(year, month, day, 16, 0, 0);

            // compare_open < 0 -> dtAbertura < dtNow (ex: 10:00h < 11:00h) => Open door
            // compare_open = 0 -> dtAbertura = dtNow (ex: 10:00h = 10:00h) => Open door
            // compare_open > 0 -> dtAbertura > dtNow (ex: 10:00h > 09:00h) => Close door
            int compare_open = DateTime.Compare(dtAbertura, dtNow);

            // compare_close < 0 -> dtFechamento < dtNow (ex: 16:00h < 17:00h) => Close door
            // compare_close = 0 -> dtFechamento = dtNow (ex: 16:00h = 16:00h) => Open door
            // compare_close > 0 -> dtFechamento > dtNow (ex: 16:00h > 15:00h) => Open door
            int compare_close = DateTime.Compare(dtFechamento, dtNow);

            bool can_open_door = (compare_open > 0) ? false : true;
            can_open_door = (compare_close < 0) ? false : can_open_door;

            string status = (can_open_door) ? "Abertura da Porta OK" : "Porta Fechada";

            addDadosParaList(dtNow, status);
            createLog(dtNow, status);
        }

        /// <summary>
        /// Adicionar dados para list
        /// </summary>
        /// <param name="dtNow">DateTime</param>
        /// <param name="status">string</param>
        private void addDadosParaList(DateTime dtNow, string status)
        {
            EntradasBancoModels entradasBanco = new EntradasBancoModels();
            entradasBanco.entrada = dtNow;
            entradasBanco.status = status;
            listEntradasBanco.Add(entradasBanco);
        }

        /// <summary>
        /// Contar número de vezes que a porta foi aberta
        /// </summary>
        /// <returns>int - número de log de porta aberta</returns>
        public int getOpenDoor()
        {
            int count_open_door = 0;
            foreach(EntradasBancoModels getEntradasBanco in listEntradasBanco)
            {
                if (getEntradasBanco.status == "Abertura da Porta OK")
                    count_open_door++;
            }

            return count_open_door;
        }

        /// <summary>
        /// Ler arquivo de log e salvar na list
        /// </summary>
        public void readLog()
        {
            if (File.Exists(file) && listEntradasBanco.Count == 0)
            {
                string linha = "";
                string[] split = null;
                StreamReader stream = File.OpenText(file);
                while (stream.EndOfStream != true)
                {
                    linha = stream.ReadLine();
                    split = linha.Split(']');

                    addDadosParaList(
                        Convert.ToDateTime(split[0].ToString().Replace("[", "").Replace(" ", "T")), 
                        split[1].ToString().Replace("-", "").Trim());
                }
                stream.Close();
            }
        }

        /// <summary>
        /// Criar arquivo de log para entrada de banco
        /// </summary>
        /// <param name="dtNow">DateTime</param>
        /// <param name="status">string</param>
        private void createLog(DateTime dtNow, string status)
        {
            string text = "[" + dtNow.ToString("yyyy-MM-dd HH:mm:ss") + "] - " + status;

            StreamWriter stream = new StreamWriter(file, true, Encoding.ASCII);
            stream.WriteLine(text);
            stream.Close();
        }
    }
}