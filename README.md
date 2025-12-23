# Basit Virüs ve Antivirüs Projesi

Bu proje, eğitim amaçlı olarak geliştirilmiş basit bir virüs ve antivirüs uygulamasıdır.

## ⚠️ ÖNEMLİ UYARILAR

- **Bu proje sadece eğitim ve test amaçlıdır**
- Gerçek sistem dosyalarına zarar vermez
- Virüs sadece test klasöründe çalışır
- Her zaman `Ctrl+Shift+Q` tuş kombinasyonu ile kapatılabilir

## 📁 Proje Yapısı

```
basit antivirüs/
├── SimpleVirus/          # Klavye kilitleyen basit virüs
│   ├── SimpleVirus.csproj
│   ├── Program.cs
│   └── KeyboardHook.cs
├── SimpleAntivirus/      # Virüsü tespit edip temizleyen antivirüs
│   ├── SimpleAntivirus.csproj
│   └── Program.cs
└── README.md
```

## 🚀 Kullanım

### Gereksinimler

- .NET 6.0 SDK veya üzeri
- Windows işletim sistemi
- Visual Studio 2022 veya Visual Studio Code

### SimpleVirus'ü Çalıştırma

1. Visual Studio'da `SimpleVirus` projesini açın
2. Projeyi derleyin (Build)
3. Projeyi çalıştırın (Run)

**Ne Yapar:**
- Klavyeyi kilitler (tüm tuş girişlerini engeller)
- `Ctrl+Shift+Q` kombinasyonu ile kapatılabilir
- Test klasörü oluşturur (gerçek sistem dosyalarına dokunmaz)

**Kapatma:**
- `Ctrl+Shift+Q` tuşlarına basarak güvenli şekilde kapatabilirsiniz

### SimpleAntivirus'ü Çalıştırma

1. Visual Studio'da `SimpleAntivirus` projesini açın
2. Projeyi derleyin (Build)
3. Projeyi çalıştırın (Run)

**Ne Yapar:**
- Çalışan SimpleVirus proseslerini tespit eder
- Virüs proseslerini sonlandırır
- Test klasörünü temizleme seçeneği sunar
- Detaylı rapor gösterir

## 🔒 Güvenlik Özellikleri

1. **Kill Switch**: `Ctrl+Shift+Q` kombinasyonu her zaman çalışır
2. **İzole Test Klasörü**: Virüs sadece belirlenen test klasöründe çalışır
3. **Sistem Dosyalarına Dokunmaz**: Gerçek sistem dosyalarına hiçbir şekilde müdahale etmez
4. **Kolay Temizleme**: Antivirüs ile kolayca temizlenebilir

## 🛠️ Teknik Detaylar

### SimpleVirus

- Windows API (`user32.dll`) kullanarak global keyboard hook oluşturur
- `SetWindowsHookEx` ile tuş girişlerini yakalar
- Tüm tuşları engeller, sadece kill switch kombinasyonuna izin verir

### SimpleAntivirus

- Çalışan tüm prosesleri tarar
- SimpleVirus adlı prosesleri tespit eder
- `Process.Kill()` ile virüs proseslerini sonlandırır

## 📝 Notlar

- Virüs çalışırken klavye kilitli olacaktır, bu normaldir
- Eğer kill switch çalışmazsa, görev yöneticisinden (Task Manager) manuel olarak kapatabilirsiniz
- Bu proje sadece eğitim amaçlıdır ve kötü amaçlı kullanım için tasarlanmamıştır

## ⚖️ Sorumluluk Reddi

Bu yazılım "olduğu gibi" sağlanmaktadır. Yazar, bu yazılımın kullanımından kaynaklanan herhangi bir zarardan sorumlu değildir. Bu yazılımı yalnızca yasal ve etik amaçlarla kullanın.


