using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //  Bu bir araç olduğu için static olarak yapmak istiyorum.
        {                                                  // params verdiğimiz zaman, run içerisinde istediğimiz kadar
                                                           // IResult verebiliriz parametre olarak. bu sayede
                                                           // istediğimiz kadar parametre yollayablirim.
                                                           // logics'te iş kuralı demek.
                                                           // logicsler geldi diyelim.

            foreach (var logic in logics)   // her bir iş kuralı için
            {
                if (!logic.Success) // başarısız ise
                {
                    return logic;   // ne döndürecek, errorresult döndürece.
                                    // burada, başarısız olanı business'a haberdar ediyoruz.
                }
            }

            return null;    // başarılı ise, bir şey yapmana gerek yok.

        }
    }
}
