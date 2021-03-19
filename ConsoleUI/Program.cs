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

              ProductTest();

            //  CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // bu şu an ; Ben InMemory Çalışacağım demek.

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }
    }
}
