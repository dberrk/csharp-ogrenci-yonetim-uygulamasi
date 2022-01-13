using System;
using System.Collections.Generic;

namespace OgrenciYonetimUygulamasi
{
    class Program
    {
        static bool DevamMi = true;
        static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        static void Main(string[] args)
        {
            Uygulama();
        }

        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            while (DevamMi == true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                    case "E":
                        OgrenciEkle();
                        break;
                    case "2":
                    case "L":
                        OgrenciListele();
                        break;
                    case "3":
                    case "S":
                        OgrenciSil();
                        break;
                    case "4":
                    case "X":
                        DevamMi = false;
                        break;
                }
                Console.WriteLine();
            }
        }

        static string SecimAl()
        {
            string karakterler = "1234ESLX";
            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();
                int index = karakterler.IndexOf(giris);

                if (giris.Length == 1 && karakterler.IndexOf(giris) >= 0)
                {
                    return giris;
                }
                else
                {
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum.Program sonlandırılıyor.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
            }
        }




        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)       ");
            Console.WriteLine("2 - Öğrenci Listele(L)    ");
            Console.WriteLine("3 - Öğrenci Sil(S)        ");
            Console.WriteLine("4 - Çıkış(X)              ");
            Console.WriteLine();
        }




        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();
            Console.WriteLine("1- Öğrenci Ekle--------");
            Console.WriteLine("Öğrencinin");

            int no;
            do
            {
                Console.Write("No: ");
                no = int.Parse(Console.ReadLine());
            }
            while (OgrenciVarMi(no) == true);

            o.No = no;

            Console.Write("Adı: ");
            o.Ad = IlkHarfiBuyut(Console.ReadLine().Split(' '));
            Console.Write("Soyadı: ");
            o.Soyad = IlkHarfiBuyut(Console.ReadLine());
            Console.Write("Şube: ");
            o.Sube = IlkHarfiBuyut(Console.ReadLine());

            Console.WriteLine("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)");
            string secim = Console.ReadLine();
            if (secim.ToUpper() == "E")
            {
                Ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }
        }



        

        static void OgrenciListele()
        {
            Console.WriteLine("2- Öğrenci Listele");
            Console.WriteLine();

            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine("Gösterilecek öğrenci yok.");
                return;
            }

            Console.WriteLine("Şube".PadRight(8, ' ') + "No".PadRight(8) + "Ad Soyad");
            Console.WriteLine("-----------------------------");
            foreach (Ogrenci item in Ogrenciler)
            {
                Console.WriteLine(item.Sube.PadRight(8) + item.No.ToString().PadRight(8) + item.Ad + " " + item.Soyad);
            }


        }
                
        static void OgrenciSil()
        {
            Console.WriteLine("3- Öğrenci Sil ---------");
            Console.WriteLine();

            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
                return;
            }


            Console.WriteLine("Silmek istediğiniz öğrencinin");
            Console.Write("No: ");
            int no = int.Parse(Console.ReadLine());
            Ogrenci ogr = null;
            foreach (Ogrenci item in Ogrenciler) //öğrenciyi bulmak için döngü var
            {
                if (item.No == no)
                {
                    ogr = item;
                    break;
                }
            }
            if (ogr != null)
            {
                Console.WriteLine("Adı: " + ogr.Ad);
                Console.WriteLine("Soyadı: " + ogr.Soyad);
                Console.WriteLine("Şubesi: " + ogr.Sube);
                Console.WriteLine("Öğrenciyi silmek istediğinize emin misiniz? (E/H)");
                string secim = Console.ReadLine();
                if (secim.ToUpper() == "E")
                {
                    Ogrenciler.Remove(ogr);
                    Console.WriteLine("Öğrenci silindi.");
                }
                else
                {
                    Console.WriteLine("Öğrenci silinmedi.");
                }
            }
            else
            {
                Console.WriteLine("Listede böyle bir öğrenci yok.");
            }
        }

        static void SahteVeriGir()
        {
            Ogrenci o1 = new Ogrenci();
            o1.No = 12;
            o1.Ad = "Ayla";
            o1.Soyad = "Akın";
            o1.Sube = "A";
            Ogrenciler.Add(o1);

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Burak";
            o2.Soyad = "Beyaz";
            o2.No = 45;
            o2.Sube = "B";
            Ogrenciler.Add(o2);

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Neşe";
            o3.Soyad = "Can";
            o3.No = 23;
            o3.Sube = "B";
            Ogrenciler.Add(o3);

        }

       
        static string IlkHarfiBuyut(string[] veri)
        {
            string yeniVeri = "";

            for (int i = 0; i < veri.Length; i++)
            {
                yeniVeri += IlkHarfiBuyut(veri[i]) + " ";
            }

            return yeniVeri;
        }

        static string IlkHarfiBuyut(string veri)
        {
            return veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
        }

        static bool OgrenciVarMi(int no)
        {
            foreach (Ogrenci item in Ogrenciler)
            {
                if (item.No == no)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
