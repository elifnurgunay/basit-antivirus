using System;
using System.Diagnostics;
using System.IO;

namespace SimpleAntivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("    BASIT ANTİVİRÜS - VİRÜS TEMİZLEYİCİ");
            Console.WriteLine("========================================\n");

            bool virusFound = false;
            int processesKilled = 0;

            // Çalışan tüm prosesleri kontrol et
            Process[] processes = Process.GetProcesses();
            
            Console.WriteLine("Sistem taranıyor...\n");

            foreach (Process process in processes)
            {
                try
                {
                    // SimpleVirus prosesini ara
                    if (process.ProcessName.Contains("SimpleVirus") || 
                        process.MainModule?.ModuleName?.Contains("SimpleVirus") == true)
                    {
                        virusFound = true;
                        Console.WriteLine($"[TESPİT EDİLDİ] Virüs bulundu: {process.ProcessName} (PID: {process.Id})");
                        
                        // Virüs prosesini sonlandır
                        try
                        {
                            process.Kill();
                            process.WaitForExit(5000); // 5 saniye bekle
                            processesKilled++;
                            Console.WriteLine($"[TEMİZLENDİ] Virüs prosesi sonlandırıldı: {process.ProcessName}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[HATA] Proses sonlandırılamadı: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bazı sistem proseslerine erişim yetkisi olmayabilir, sessizce devam et
                    continue;
                }
            }

            // Test klasörünü temizleme seçeneği
            string testFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "basit antivirüs",
                "TestFolder"
            );

            if (Directory.Exists(testFolder))
            {
                Console.WriteLine($"\n[UYARI] Test klasörü bulundu: {testFolder}");
                Console.Write("Test klasörünü silmek ister misiniz? (E/H): ");
                string? response = Console.ReadLine();
                
                if (response?.ToUpper() == "E" || response?.ToUpper() == "EVET")
                {
                    try
                    {
                        Directory.Delete(testFolder, true);
                        Console.WriteLine("[TEMİZLENDİ] Test klasörü silindi.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[HATA] Klasör silinemedi: {ex.Message}");
                    }
                }
            }

            // Sonuç raporu
            Console.WriteLine("\n========================================");
            if (virusFound)
            {
                Console.WriteLine($"SONUÇ: {processesKilled} adet virüs prosesi temizlendi.");
                Console.WriteLine("Sistem temizlendi!");
            }
            else
            {
                Console.WriteLine("SONUÇ: Virüs bulunamadı. Sistem temiz görünüyor.");
            }
            Console.WriteLine("========================================\n");

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}


