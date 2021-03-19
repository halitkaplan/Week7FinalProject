
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // class demek -> Referans Tip olabilir demek.
    // Bunu böyle yapınca int yazamayacak ama herhangi bir class yazabilir. 
    // Bunuda kısıtlamamız gerekiyor.
    // Veritabanı nesnelerime baktığım zaman, Product, Category ve Customer nesnelerime. Hepsi IEntity. 
    // Buraya öyle bir şey yazacağız ki, ya IEntity olabilir, ya da IEntity'nin implemente ettiği bir şey olabilir.
    // Böyle yapınca da, IEntity'de yazabiliyorum. Bunun da önüne geçmem gerekiyor. Bu soyut nesne benim işimi görmüyor.
    // new() dediğimiz zaman nesnenin newlenebilir olması anlamına geliyor.
    // IEntity'de newlenemediği için Bu şekilde çok güzel bir kısıtlama getirmiş olduk.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // GetAll dediğimde tüm datayı getirebilir. Ama filtre vererek benim istediğim dataları getirir.
        // Örnek olarak, e-ticaret sitelerinde filtreleme işlemi verilebilir.
        // Buna da Expression dediğimiz yapı diyoruz.
        // Ben bu yapı sayesinde, işte: Category'ye göre getir. şuna göre getir gibi ayrı ayrı methodlar yazmayacağım.
        List<T> GetAll(Expression<Func<T,bool>> filter =null); // filter=null demek filtre vermeyedebilirsin anlamına geliyor.
        

        // her sistem ID'ye göre getirmeyebiliyor. bunun için refactoring yapmamız lazım biraz.
        // T döndüren Get operasyonu yazdık.
        T Get(Expression<Func<T, bool>> filter); // Bu da tek bir detayı getirmek için. MEsela bankalardaki Kredi. 
                                                 // Bir kredinin detaylarını getirir. Hesaplar liste olarak geliyor diyelim.
                                                 // Tıklayarak o hesabın detaylarına gitmiş oluyoruz.
                                                 // filter dememizin sebebi, filtre vermek zorunda.  1 kere yazacağımız bir yapıdır.
                                                 // Burası bize:
                                                 // p=>p.categoryId==2 gibi işlemleri yapmamızı sağlıyor. 
                                                  

        void Add(T entity);


        void Update(T entity);


        void Delete(T entity);

      //   List<T> GetAllByCategory(int categoryId);            Yukarıdaki filtreleme işlemlerini yaptığımız için, bu koda asla ihtiyacımız kalmadı.
    }
}




