# PatikaPratikJwt
PatikaPratikJwt, ASP.NET Core ile JWT (JSON Web Token) kimlik doğrulama işlemlerini gerçekleştirmek için oluşturulmuş bir projedir. Bu proje, kullanıcı kaydı, giriş işlemi ve JWT tabanlı yetkilendirme işlevlerini içermektedir.

## İçindekiler
Özellikler
Kurulum
Yapılandırma
Kullanım

## Özellikler
- Kullanıcı kaydı ve giriş işlemleri
- JWT (JSON Web Token) ile kimlik doğrulama
- Veri koruma ve şifreleme
- Swagger ile API dokümantasyonu
## Kurulum
- Projeyi Klonlayın:

```
git clone https://github.com/kullanici-adi/PatikaPratikJwt.git
cd PatikaPratikJwt
```
- Bağımlılıkları Yükleyin: Projeyi Visual Studio veya komut satırında açarak gerekli bağımlılıkları yükleyin:

```
dotnet restore
```
- Projeyi Derleyin:

```
dotnet build
```
## Yapılandırma
appsettings.json: JWT ayarları, veri tabanı bağlantı dizesi ve veri koruma ayarları gibi uygulama yapılandırmaları appsettings.json dosyasında yapılmalıdır.

Örnek:
```
json
Kodu kopyala
"JWT": {
  "Secret": "YourSecretKeyHere",
  "Issuer": "PatikaPratikJwt",
  "Audience": "PatikaPratikJwtUsers",
  "ExpireMinutes": "60"
}
```

## Kullanım
### Kullanıcı Kayıt ve Giriş İşlemleri
Kullanıcı kaydı ve giriş işlemleri için AuthController üzerinde endpoint'ler bulunmaktadır.

- Kullanıcı Kaydı: /auth/register endpoint'ine POST isteği ile email ve password bilgileri gönderilir.
- Giriş: /auth/login endpoint'ine POST isteği ile giriş yapılır ve başarılı bir giriş sonucunda JWT token döndürülür.
Örnek Giriş İsteği
```
json
Kodu kopyala
POST /auth/login
{
  "email": "user@example.com",
  "password": "YourPassword123!"
}
```
### JWT ile Yetkilendirme
JWT token, yetkilendirilmiş endpoint'lere erişim sağlamak için kullanılır. Token, Authorization başlığında "Bearer {token}" formatında gönderilmelidir.
