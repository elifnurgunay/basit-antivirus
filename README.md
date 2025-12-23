# Basit Virüs ve Antivirüs Projesi
<img width="764" height="770" alt="Ekran görüntüsü 2025-12-23 231516" src="https://github.com/user-attachments/assets/10fd67a9-c1f5-4a0e-bfa6-dcca9c9412de" />

<img width="1535" height="766" alt="Ekran görüntüsü 2025-12-23 231525" src="https://github.com/user-attachments/assets/2d6149ad-dc93-4ade-8e83-c897e50444ef" />

Bu proje, eğitim amaçlı olarak geliştirilmiş basit bir virüs ve antivirüs uygulamasıdır.

## ⚠️ ÖNEMLİ UYARILAR

- **Bu proje sadece eğitim ve test amaçlıdır**
- Gerçek sistem dosyalarına zarar vermez
- Virüs sadece test klasöründe çalışır
- Her zaman `Ctrl+Shift+Q` tuş kombinasyonu ile kapatılabilir


## 🚀 Kullanım

### Gereksinimler

- .NET 6.0 SDK veya üzeri
- Windows işletim sistemi
- Visual Studio 2022 veya Visual Studio Code


**Ne Yapar:**
- Klavyeyi kilitler (tüm tuş girişlerini engeller)
- `Ctrl+Shift+Q` kombinasyonu ile kapatılabilir
- Test klasörü oluşturur (gerçek sistem dosyalarına dokunmaz)

**Kapatma:**
- `Ctrl+Shift+Q` tuşlarına basarak güvenli şekilde kapatabilirsiniz

### SimpleAntivirus'ü Çalıştırma

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


