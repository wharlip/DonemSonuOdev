namespace DonemSonuOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kaç öğrenci girmek istiyorsunuz?");
            int ogrenciSayisi = int.Parse(Console.ReadLine());

            string[,] tablo = new string[ogrenciSayisi + 1, 7];
            tablo[0, 0] = "Numara";
            tablo[0, 1] = "Ad";
            tablo[0, 2] = "Soyad";
            tablo[0, 3] = "Vize Notu";
            tablo[0, 4] = "Final Notu";
            tablo[0, 5] = "Ortalama Not";
            tablo[0, 6] = "Harf Notu";


            double endusuknot = 100;
            double enyukseknot = 0;
            double toplamnot = 0;

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Öğrencinin Numarasını giriniz:");
                tablo[i + 1, 0] = Console.ReadLine();

                Console.WriteLine($"{i + 1}. Öğrencinin Adını giriniz:");
                tablo[i + 1, 1] = Console.ReadLine();

                Console.WriteLine($"{i + 1}. Öğrencinin Soyadını giriniz:");
                tablo[i + 1, 2] = Console.ReadLine();

                Console.WriteLine($"{i + 1}. Öğrencinin Vize Notunu giriniz (0-100):");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int vize) && vize >= 0 && vize <= 100)
                    {
                        tablo[i + 1, 3] = vize.ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçerli bir vize notu giriniz (0-100):");
                    }
                }

                Console.WriteLine($"{i + 1}. Öğrencinin Final Notunu giriniz (0-100):");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int final) && final >= 0 && final <= 100)
                    {
                        tablo[i + 1, 4] = final.ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçerli bir final notu giriniz (0-100):");
                    }
                }

                double ortalama = (int.Parse(tablo[i + 1, 3]) * 0.4) + (int.Parse(tablo[i + 1, 4]) * 0.6);
                tablo[i + 1, 5] = ortalama.ToString("F2");

                string harfNotu =  ortalama >= 85 ? "AA" :
                                   ortalama >= 75 ? "BA" :
                                   ortalama >= 60 ? "BB" :
                                   ortalama >= 50 ? "CB" :
                                   ortalama >= 40 ? "CC" :
                                   ortalama >= 30 ? "DC" :
                                   ortalama >= 20 ? "DD" :
                                   ortalama >= 10 ? "FD" : "FF";

                tablo[i + 1, 6] = harfNotu;


                endusuknot = Math.Min(endusuknot, ortalama);
                enyukseknot = Math.Max(enyukseknot, ortalama);
                toplamnot += ortalama;
            }


            double genelOrtalama = toplamnot / ogrenciSayisi;

            Console.WriteLine();
            for (int i = 0; i <= ogrenciSayisi; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{tablo[i, j],-15}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"En Düşük Not: {endusuknot:F2}");
            Console.WriteLine($"En Yüksek Not: {enyukseknot:F2}");
            Console.WriteLine($"Genel Ortalama: {genelOrtalama:F2}");
        }
    }
}
