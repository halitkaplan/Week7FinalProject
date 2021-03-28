using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }   //Access Token
        public DateTime Expiration { get; set; } // Token'in bitiş süresi. Senin jeton bilgin şu, senin bu jeton bu tarihte biticek.
    }
}
