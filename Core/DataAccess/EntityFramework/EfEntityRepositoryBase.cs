using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // bir Class'ı newlediğimiz zaman, using içine yazdığımız nesneler, işi bittikten
            // sonra hemen atıcak. Contextler bellek için biraz zorlayıcı.
            //IDispsable patters implementation
            using (TContext context = new TContext())
            {
                // using bittiği an, garbagecollectöre gidiyor ve belleği hızlıca temizliyor.
                var addedEntity = context.Entry(entity);    // referansı yakala
                addedEntity.State = EntityState.Added;      // o eklenecek bir nesne
                context.SaveChanges();                      // değişiklikleri kaydet.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity);    // referansı yakala
                deletedEntity.State = EntityState.Deleted;      // o silinecek bir nesne
                context.SaveChanges();                      // değişiklikleri kaydet.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)  // bu tek data getiriyor.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // bu filtreyi, o referansa uyguluyorum ve tek bir datayı getiriyor bana. 
                                                                       // Datayı da referanstan buluyordu zaten.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //     filter == null'mı? Null ise, veritabanındaki product tablosunu listeye çevir ve bana döndür. : Değilse, filtreleyip listele. 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);      // referansı yakala
                updatedEntity.State = EntityState.Modified;     // o güncellenecek bir nesne
                context.SaveChanges();                          // değişiklikleri kaydet.
            }
        }
    }
}


