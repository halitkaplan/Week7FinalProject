using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context nesnesi -> DB tabloları ile proje classlarını bağlamak.
    // bunun ismini context vermem context olduğu anlamına gelmez. DbContext'ten implemente etmemiz gerekiyor.
    public class NorthwindContext   :   DbContext
    {
        // OnConfiguring methodu Benim projem hangi veritabanı ile ilişkili olduğunu belirteceğimiz ye. 
        // Override yazdık, boşluk bıraktık , OnConfiguring'i getirdik ve enter'a basınca burayı oluşturacak.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SqlServer kullanacağımı belirtiyorum ve bu SQL servere nasıl bağlanacağını yazacağız.
            //Buraya koyduğumuz @ işareti, Ters Slash \ işaretinin bir anlamı var. string içerisinde olsa bile.
            // normal slah'ı ters slah olarak algıla demek @ işareti.
            // optionsBuilder.UseSqlServer(@"Server=175.45.2.12"); gerçek projede bu şekilde bir ıp görürüz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        // SQL servere burada bağlandım ama
        // Hangi nesnemin, hangi nesneye karşılık geldiğini belirteceğiz şimdi de
        // Product - Products'a karşılık geliyor
        // benim Category'm - Categories tablosuna karşılık geliyor.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}


