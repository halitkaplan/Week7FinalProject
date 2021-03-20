using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult :Result //ctor dan dolayı buranın altını çizdi.
    {
        public SuccessResult(string message):base (true, message)
        {

        }

        // successResult'ta mesaj vermek istemiyor olabilir

        public SuccessResult() : base(true)
        {

        }
    }
}
