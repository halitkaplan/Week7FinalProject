using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)  // işlem sonucu default true olarak verdik.
        {

        }

        //MEsaj olayına girmek istemiyorsa:
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        // Data'yı default haliyle döndürmek istiyordur belki:
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        // Hiç bir şey vermek istemiyorum.

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
