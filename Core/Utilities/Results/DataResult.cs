using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message) // success ve messageyi tekrar yazmak istemiyoruz.
        {
            Data = data; 
            // bunu böyle yapmamızın sebebi;
            // Mesaj gönderilmesini istemiyor olabilir. 
            // ZAten, mesaj gönderiliyorsa burası çalışıyor.
            // fakat mesaj gönderilmediğinde burada bi sıkıntı oluşacak.
            // buradaki kod parçacığı, bir altta yazılanı kapsıyor. 
            // burası çalıştığında, aşağıdaki de çalışacak!
        }

        // mesaj yollamak zorunda olmayabilir:

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }

}
