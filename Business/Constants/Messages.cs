using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError= "eklemek istenilen kategori de maksimum 15 ürün olabilir. " ;
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded="Kategori Limiti Aşıldığı için Yeni Ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered="Kayıt oldu.";
        public static string UserNotFound="Kullanıcı Bulunamadı.";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Başarıyla Giriş Yapıldı";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}

