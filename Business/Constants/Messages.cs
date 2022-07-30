using Core.Entities.Concrete;
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
        public static string Added = "Eklendi!";
        public static string UnAdded = "Eklenemedi!";
        public static string Deleted = "Silindi!";
        public static string UnDeleted = "Silinemedi!";
        public static string Updated = "Güncellendi!";
        public static string UnUpdated = "Güncellenemedi!";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string CarHired = "Araba kiralandı.";
        public static string CarNotDelivered = "Araba henüs teslim edilmedi";
        public static string CarImageLimitExceded = "Araba resim limiti aşıldığı için yeni resim eklenemiyor!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatalı!";
        public static string SuccessfulLogin = "Sisteme giriş başarılı!";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkin yok";
    }
}
