using System;
using System.Collections.Generic;
using System.IO;

namespace SozlukUygulmasi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("     Bu Program ile Mehmet Nuri Kureş'in Sözlüğüne, Yeni Kelimeler Kazandırabilirsiniz.");
            Console.WriteLine();
            Console.WriteLine("     Lütfen Adınızı ve Soyadınızı Yazarak, Enter Tuşuna Basınız?");

            var name = Console.ReadLine();
            var currentDate = DateTime.Now;

            Console.WriteLine($"{Environment.NewLine}    Selam, {name}, Hoş geldiniz, şu an tarih {currentDate:d}, saat {currentDate:t}'dir.");
            Console.WriteLine();

            var kelimeKarsiligi = new SortedDictionary<string, List<string>>() { };
            Console.WriteLine("    İngilizce-Türkçe sözlüğümüzü geliştirmek için, Programımıza İngilizce bir kelime girebilir veya çıkmak için 'quit' tuşuna basınız.");

            string ingKel;
            do
            {
                ingKel = Console.ReadLine();
                if (ingKel == "quit")
                {
                    break;
                }
                string turKel;
                var karsiliklari = new List<string>();
                //Her İngilizce kelime için, Türkçe kelime karşılıklarının girilmesi
                do
                {
                    Console.WriteLine("    Türkçe karşılığını giriniz. Çıkmak için 'quit'e basınız.");
                    turKel = Console.ReadLine();
                    if (turKel == "quit")
                    {
                        break;
                    }

                    karsiliklari.Add(turKel);
                } while (true);

                kelimeKarsiligi.Add(ingKel, karsiliklari);
                Console.WriteLine("Yeni bir İngilizce kelime giriniz veya çıkmak için 'quit'e basınız.");

            } while (true);

            var dosyaAdi = @"C:\CSV Dosyalari\YeniListe.txt";

            StreamWriter writer = File.AppendText(dosyaAdi);

            foreach (var kavram in kelimeKarsiligi)
            {
                writer.Write(kavram.Key);
                foreach (var s in kavram.Value)
                    writer.Write("," + s);
                writer.WriteLine();
            }
            writer.Close();

            foreach (var kavram in kelimeKarsiligi)
            {
                Console.Write(kavram.Key);
                kavram.Value.ForEach(s => Console.Write("," + s));

                Console.WriteLine(kavram.Key);
                kavram.Value.ForEach(s => Console.WriteLine("\t>" + s));
            }
            Console.Write($"{Environment.NewLine} Çıkmak için herhangi bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
