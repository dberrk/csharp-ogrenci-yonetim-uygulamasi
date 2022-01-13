using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimUygulamasi
{
    class Ogrenci
    {
        public int No;
        public string Ad;
        public string Soyad;
        public string Sube;

        
        //kurucu metotlar
        //constructors
        public Ogrenci()
        {

        }
        public Ogrenci(int no, string ad, string soyad)
        {
            No = no;
            Ad = ad;
            Soyad = soyad;
        }
               

    }
}
