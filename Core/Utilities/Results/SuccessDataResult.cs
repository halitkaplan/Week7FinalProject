using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>  :   DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data,true,message)  // işlem sonucu default true olarak verdik.
        {

        }

        //MEsaj olayına girmek istemiyorsa:
        public SuccessDataResult(T data) : base(data,true)
        {

        }

        // Data'yı default haliyle döndürmek istiyordur belki:
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }

        // Hiç bir şey vermek istemiyorum.

        public SuccessDataResult() : base(default,true)
        {

        }
    }
}

