using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        // hangi tip ile çalıştığımızı ve hangi tipe döüştüreceğimizi bu şekilde verebiliyoruz.
        // ben sana bşr key vereyim, ben bellekten bu key'e karşılık gelen datayı sana vereyim.
        T Get<T>(string key);

        object Get(string key); // bu şekilde de yazılabilir.

        void Add(string key, object value, int duration); // bir key gelecek ve her tipten veri gelebilir.
                                                          // object, bütün veri tiplerinin basesi. int gelir, string gelir, başka bir şey gelir.
                                                          // Bir de, bu Cache içerisinde ne kadar duracak diye bir parametre daha ekliyorum

        // Cache'e eklerken,
        // GetAllByCategoryId, bizim şuna bakmamız lazım; bunu cache'den mi getirelim, veritabanından mı?
        // buna nasıl karar veririz? Cache'de var mı? diye sorarız. 
        // Cache'de yoksa, veritabanından getirir, cache'ye ekleriz.
        bool IsAdd(string key);
        void Remove(string key);

        // GetAllByCategoryId, parametrik ya, biz buna hangi key2i vereceğiz. Bir sürü olabilir
        // böyle bir durumd ada bir patterns yazsam; isminde 'Get' olanları uçur, 'CAtegory' olanları uşur gibi bir şey yapabilirim.

        void RemoveByPattern(string pattern); // pattern versem, başı sonu önemli değil için de benim verdiğim varsa.


    }
}
