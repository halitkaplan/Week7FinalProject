using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Normal şartlarada New operasyonu felan yapmıyoruz ama şimdilik şöyle bir şey yapacağız:

            ProductManager productManager = new ProductManager(new EfProductDal()); // bu şu an ; Ben InMemory Çalışacağım demek.

            foreach (var product in productManager.GetByUnitPrice(50,100))
            { 
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
