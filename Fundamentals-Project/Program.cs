﻿using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Kullanıcıdan hangi programı çalıştırmak istediğini seçme işlemi
        Console.WriteLine("Hangi programı çalıştırmak istersiniz?\n1 - Rastgele Sayı Bulma Oyunu\n2 - Hesap Makinesi\n3 - Ortalama Hesaplama");
        Console.Write("Seçiminiz: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        // Kullanıcının seçimine göre ilgili fonksiyonu çağırma
        switch (choice)
        {
            case 1:
                RastgeleSayiBulmaOyunu(); // Rastgele sayı bulma oyununu başlat
                break;
            case 2:
                HesapMakinesi(); // Hesap makinesini başlat
                break;
            case 3:
                OrtalamaHesaplama(); // Ortalama hesaplama fonksiyonunu başlat
                break;
            default:
                Console.WriteLine("Geçersiz seçim yaptınız. Program sonlanıyor.");
                break;
        }
    }

    // Rastgele sayı bulma oyunu
    static void RastgeleSayiBulmaOyunu()
    {
        Random random = new Random(); // Rastgele sayı üretici
        int rastgeleSayi = random.Next(1, 101); // 1 ile 100 arasında rastgele bir sayı
        int kalanHak = 5; // Kullanıcının 5 tahmin hakkı var

        Console.WriteLine("1 ile 100 arasında bir sayıyı tahmin etmeye çalışın. Toplam 5 hakkınız var.");

        while (kalanHak > 0) // Kullanıcıya tahmin yapma hakkı
        {
            Console.Write("Tahmininiz: ");
            int tahmin = Convert.ToInt32(Console.ReadLine());

            // Eğer doğru tahmin ederse
            if (tahmin == rastgeleSayi)
            {
                Console.WriteLine("Tebrikler! Doğru tahmin ettiniz.");
                return;
            }
            // Yanlış tahmin, hangi yönde tahmin yapması gerektiğini bildir
            else if (tahmin < rastgeleSayi)
            {
                Console.WriteLine("Daha yüksek bir sayı girin.");
            }
            else
            {
                Console.WriteLine("Daha düşük bir sayı girin.");
            }

            kalanHak--; // Kullanıcının kalan hakkını bir azaltma
            Console.WriteLine($"Kalan hakkınız: {kalanHak}");
        }

        // Kullanıcı tüm haklarını kullanırsa doğru sayıyı gösterme işlemi
        Console.WriteLine($"Tahmin hakkınız bitti. Doğru sayı: {rastgeleSayi}");
    }

    // Hesap makinesi fonksiyonu
    static void HesapMakinesi()
    {
        Console.Write("İlk sayıyı girin: ");
        double sayi1 = Convert.ToDouble(Console.ReadLine()); // İlk sayıyı al

        Console.Write("İkinci sayıyı girin: ");
        double sayi2 = Convert.ToDouble(Console.ReadLine()); // İkinci sayıyı al

        Console.Write("Yapmak istediğiniz işlemi seçin (+, -, *, /): ");
        char islem = Convert.ToChar(Console.ReadLine());

        double sonuc; //işlemler ondalıklı değerler içerebileceği için double türünde tanımladım

        // Seçilen işleme göre hesaplama yap
        switch (islem)
        {
            case '+':
                sonuc = sayi1 + sayi2;
                Console.WriteLine($"Sonuç: {sonuc}");
                break;
            case '-':
                sonuc = sayi1 - sayi2;
                Console.WriteLine($"Sonuç: {sonuc}");
                break;
            case '*':
                sonuc = sayi1 * sayi2;
                Console.WriteLine($"Sonuç: {sonuc}");
                break;
            case '/':
                if (sayi2 != 0) //  sıfıra bölme hatası kontrolü
                {
                    sonuc = sayi1 / sayi2;
                    Console.WriteLine($"Sonuç: {sonuc}");
                }
                else
                {
                    Console.WriteLine("Hata: Bir sayı sıfıra bölünemez.");
                }
                break;
            default:
                Console.WriteLine("Geçersiz işlem seçimi.");
                break;
        }
    }

    // Ortalama hesaplama fonksiyonu
    static void OrtalamaHesaplama()
    {
        Console.Write("Birinci ders notunu girin: ");
        double not1 = Convert.ToDouble(Console.ReadLine()); // Birinci ders notunu al

        Console.Write("İkinci ders notunu girin: ");
        double not2 = Convert.ToDouble(Console.ReadLine()); // İkinci ders notunu al

        Console.Write("Üçüncü ders notunu girin: ");
        double not3 = Convert.ToDouble(Console.ReadLine()); // Üçüncü ders notunu al

        // Notların geçerli olup olmadığını kontrol etme  (0 ile 100 arasında olmalı)
        if ((not1 < 0 || not1 > 100) || (not2 < 0 || not2 > 100) || (not3 < 0 || not3 > 100))
        {
            Console.WriteLine("Hata: Notlar 0 ile 100 arasında olmalıdır.");
            return;
        }

        // Ortalamayı hesapla
        double ortalama = (not1 + not2 + not3) / 3;
        double yuvarlanmisOrtalama = Math.Round(ortalama, 2); // 2 ondalık basamağa yuvarlar örn: 75.666  bunun çıktısı 75.67 olur
        Console.WriteLine($"Ortalamanız: {yuvarlanmisOrtalama}");


        int ortalamaYuvarlanmis = (int)Math.Floor(ortalama); // Ortalamayı tam sayı olarak aşağı yuvarlarma ,double olan türü int'e çeviriyoruz

        // Ortalama değerine göre harf notu ver
        switch (ortalamaYuvarlanmis)
        {
            case >= 90:
                Console.WriteLine("Harf Notu: AA");
                break;
            case >= 85:
                Console.WriteLine("Harf Notu: BA");
                break;
            case >= 80:
                Console.WriteLine("Harf Notu: BB");
                break;
            case >= 75:
                Console.WriteLine("Harf Notu: CB");
                break;
            case >= 70:
                Console.WriteLine("Harf Notu: CC");
                break;
            case >= 65:
                Console.WriteLine("Harf Notu: DC");
                break;
            case >= 60:
                Console.WriteLine("Harf Notu: DD");
                break;
            case >= 55:
                Console.WriteLine("Harf Notu: FD");
                break;
            default:
                Console.WriteLine("Harf Notu: FF");
                break;
        }
    }

}
//Switch -case yapısını bu projede kullanmamın sebebi, kullanıcının yapacağı seçimlere göre ilgili fonksiyonları çalıştırmayı daha düzenli ve okunabilir bir şekilde organize etmekti.
//Ayrıca seçimler sabit değerler olduğu için, bu yapı if-else 'den daha pratik ve performanslı bir çözüm sağladı.
//Özellikle kullanıcıya basit ve anlaşılır bir deneyim sunmayı hedeflediğim için bu yapıyı tercih ettim.