using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // İnjection:

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        // bu ne demek: ProductManager Newlendiği zaman, IProductDal referans ver diyor. Bu InMemory olabilir, entitiy olabiilir..

        public List<Product> GetAll()
        {
            // İş Kodları [Tümünü listeleme çalışıyor ama yetkisi var mı gibi ...]


            // Veri, iş kodlarından geçiyorsa eğer, Veriye erişimi çağırmam lazım. İş kodları derken: Mesela
            /*  Bir satıcı, ayda en fazla 10 ürün satabilsin.  ya da alıcı, aynı anda 2 ürün satın alabilsin.
             *  Bu kişi ürün satabilmek için şartları sağlıyor mu? ya da satın alabilmek için
             *   Eğer Şartları sağlıyorsa, Veriye erişim katmanını çağıracağız. Şöyle ki:
             */

            // InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();

            // Ben burayı böyle yazdığım zaman, Benim kodlarım InMemory ile çalışır.
            // Farklı bir veritabanına geçeceğim zaman, tüm veriye erişimleri değiştirmem gerekiyor.
            // bir iş sınıfı farklı bir sınıfı newleyemek gibi bir kuralımız var.
            // bunun için şöyle bir şey yapıyoruz. injection: 


            // Yukarıdaki injectionu oluşturduktan sonra:

            return _productDal.GetAll();
           
            


        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
            // GetAll() yaptığımda uyarı ekranı olarak bana bir Expression ver diyor program. Yani bana bir lamda ver diyor. => (lamda)
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
