using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // bir Class'ı newlediğimiz zaman, using içine yazdığımız nesneler, işi bittikten
            // sonra hemen atıcak. Contextler bellek için biraz zorlayıcı.
            //IDispsable patters implementation
            using (NorthwindContext context = new NorthwindContext())
            {
                // using bittiği an, garbagecollectöre gidiyor ve belleği hızlıca temizliyor.
                var addedEntity = context.Entry(entity);    // referansı yakala
                addedEntity.State = EntityState.Added;      // o eklenecek bir nesne
                context.SaveChanges();                      // değişiklikleri kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                
                var deletedEntity = context.Entry(entity);    // referansı yakala
                deletedEntity.State = EntityState.Deleted;      // o silinecek bir nesne
                context.SaveChanges();                      // değişiklikleri kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)  // bu tek data getiriyor.
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // bu filtreyi, o referansa uyguluyorum ve tek bir datayı getiriyor bana. 
                                                                       // Datayı da referanstan buluyordu zaten.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //     filter == null'mı? Null ise, veritabanındaki product tablosunu listeye çevir ve bana döndür. : Değilse, filtreleyip listele. 
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            } 
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity);      // referansı yakala
                updatedEntity.State = EntityState.Modified;     // o güncellenecek bir nesne
                context.SaveChanges();                          // değişiklikleri kaydet.
            }
        }
    }
}
