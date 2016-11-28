using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoPuzzles.Models
{
    public class Troco
    {
        public List<TrocoModels> listTroco = new List<TrocoModels>();

        private decimal money = 0;
        private string result = "";

        /// <summary>
        /// Troco
        /// 
        /// Funcionários de empresas comerciais que trabalham como caixa tem uma grande responsabilidade em suas mãos.A maior parte do tempo de seu expediente de trabalho é gasto recebendo valores de clientes e, em alguns casos, fornecendo troco.
        ///
        /// Seu desafio é fazer um programa que leia o valor total a ser pago e o valor efetivamente pago, informando o menor número de cédulas e moedas que devem ser fornecidas como troco.
        ///
        /// Deve-se considerar que há:
        /// + cédulas de R$100,00, R$50,00, R$10,00, R$5,00 e R$1,00;
        /// + moedas de R$0,50, R$0,10, R$0,05 e R$0,01.
        /// </summary>
        /// <param name="trocoModels"></param>
        public void calcular(TrocoModels trocoModels)
        {
            ArrayList type_money = new ArrayList();
            type_money.Add(100.00);
            type_money.Add(50.00);
            type_money.Add(10.00);
            type_money.Add(5.00);
            type_money.Add(1.00);
            type_money.Add(0.50);
            type_money.Add(0.10);
            type_money.Add(0.05);
            type_money.Add(0.01);

            money = trocoModels.money;
            result = "";

            int c = 0;
            decimal total_money = money;
            decimal get_money = 0;
            while (c < 9)
            {
                if (money > 0)
                {
                    get_money = Convert.ToDecimal(type_money[c]);
                    getPaperInMoney(get_money);
                }

                c++;
            }

            if (result.Length > 0)
            {
                TrocoModels troco = new TrocoModels();
                troco.money = total_money;
                troco.result = result;
                listTroco.Add(troco);
            }
        }

        /// <summary>
        /// Pegar papel em moeda
        /// </summary>
        /// <param name="get_money">Valor do papel da moeda</param>
        private void getPaperInMoney(decimal get_money)
        {
            int get = 0;
            while (money >= get_money)
            {
                get++;
                money -= get_money;
            }

            result += (get == 0)
                ? ""
                : " + " + get.ToString() + " " + ((get_money < 1) ? "moeda(s)" : "cédula(s)") + " de R$ " + get_money.ToString(); 
        }
    }
}