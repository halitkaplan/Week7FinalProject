using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // burası InMemory, yani: bellekte datamız varmışta biz onu yönetiyormuş gibi olacağız.
        // dolayısıyla başlangıçta veri varmış gibi bir ortamı simüle edelim.
         
        List<Product> _products;  // bu projeyi başlattığımda bellekte veri listesi oluştursun.
        public InMemoryProductDal()   //ctor + tab + tab yaparak bu kısmı oluşturduk.
        {
            // Uygulama çalıştığı anda demek : o newlendiği anda, Bu Listeyi oluşturacak.
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},    //1. ürünüm
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},    //2. ürünüm
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},  //3. ürünüm
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},   //4. ürünüm
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=80, UnitsInStock=1}        //5. ürünüm
                                                                                                                // Projeyi çalıştırdığımız zaman, böyle bir ürün listesi oluşturdu. Bir yerden geliyormuş gibi
                                                                                                                // simüle ediyorum. SQL geliyormuş gibi simüle ettik diyebiliriz.
            };
        }
        

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Listeden silme işlemi yapabilmemiz için, silme işlemine 'referans' göndermemiz gerekiyor.
            // Göndereceğimiz Product'ın bilgilerinin aynı olması önemli değil. Aynı isim soyisime ait farklı kişiler olabilir.
            // ama Referans numarası tektir. PrimeryKey'ini kullanırız. ID her zaman farklıdır.
            // Id'yi kullanarak eşleşen nesneyi bulacağız. LINQ ile karşımıza çıkıyor.


            // LINQ bilmediğimizi varsayardak:
            //Product productToDelete = null; // null'ı hata vermesin diye yazdık. normalde list olarak döndürürüz.
            //foreach (var p in _products )  // bu döngü ile listeyi tek tek dolanabiliyoruz.
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            Product productToDelete;

            // yukarıdaki foreach'i tek bir komutla döneceğiz. SingleOrDefault, products'ı tek tek dolaşmaya yarar.
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            // Her bir p için, p nin productId'si benim gönderdiğim Id'ye eşit mi diye kontrol eder.

            _products.Remove(productToDelete);



        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;   // Veritabanındaki ürünlerin hepsini döndürüyor. Hepsini getirecek çünkü.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return  _products.Where(p => p.CategoryId == categoryId).ToList(); 

            // Where koşulu: İçindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
        }

        public void Update(Product product)
        {
            Product productToUpdate;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            


        }
    }
}
