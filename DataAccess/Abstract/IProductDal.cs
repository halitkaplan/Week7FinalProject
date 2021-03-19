using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //// Ben ürün Listeleyeceğim mesela:
        //// Product Tablomu kullanacağım için ki bu da farklı bir katmanda:
        //// Bundan dolayı Referans ekliyoruz.
        //// DataAccess'e - Project Referans diyerek Entites'i referans olarak ekliyoruz.
        //List<Product> GetAll();

        //// Ekleme Operasyonum:
        //void Add(Product product);

        //// Güncelleme Operasyonum:
        //void Update(Product product);

        //// Silme Operasyonum:
        //void Delete(Product product);

        //List<Product> GetAllByCategory(int categoryId);

    }
}
