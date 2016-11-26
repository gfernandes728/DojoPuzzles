using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace DojoPuzzles.Models
{
    public class Util
    {
        public ArrayList getCharsTelefone()
        {
            ArrayList chars = new ArrayList();
            chars.Add("ABC");       // 2 -> ABC     (0)
            chars.Add("DEF");       // 3 -> DEF     (1)
            chars.Add("GHI");       // 4 -> GHI     (2)
            chars.Add("JKL");       // 5 -> JKL     (3)
            chars.Add("MNO");       // 6 -> MNO     (4)
            chars.Add("PQRS");      // 7 -> PQRS    (5)
            chars.Add("TUV");       // 8 -> TUV     (6)
            chars.Add("WXYZ");      // 9 -> WZYZ    (7)

            return chars;
        }
    }
}