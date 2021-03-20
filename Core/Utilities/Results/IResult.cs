using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; } // get sadece okunabilir demek.
                              // prop'lar, hem okumak hem de yazmak için kullanılıyordu
                              // burada sadece okuma işlemi yapıyoruz.
                              // burası bool tipinde. yapmaya çalıştığın ekleme işi 'True' ya da
                              // yapmaya çalıştığın işlem 'False'

        string Message { get; } // Yaptığın işlem başarılı. Yani true. 
                                // Müşteriye Ürün eklendi diyecek mesela.
                                // ya da başarısızsa ürün şundan dolayı eklenemedi. gibi

    }
}
