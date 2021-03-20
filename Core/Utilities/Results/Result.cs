using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        // this demek classın kendisini kasteder.
        //result2ın ctor'una tek parametreli ctor'una success'i yolla dedik. otomatik olarak diğer akradaşla beraber çalışacaklar.
        // iki parametre gönderen birisi için. burası çalışacak. ama tek bir parametre gönderdiğim de
        // burası çalışsın ama, diğeriyle otomatik olarak beraber çalışsın demiş olduk.
        // ben bi alt satırdaki kod ; ben çalışıyorum ama benimle beraber
        // bi altımdakide çalışıyor diyor.
        public Result(bool success, string message) : this(success)
        {
            Message = message;

        }
        public Result(bool success)
        {
            Success = success;
        }
        //-------------------------------------------------------------

        public bool Success { get; }

        public string Message { get; }
    }
}
