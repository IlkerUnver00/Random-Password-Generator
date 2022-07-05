// See https://aka.ms/new-console-template for more information
static void sifreolusturucu()
{
    string fileName = @"C:\..\passwordlist";

label:
    Console.WriteLine("Oluşturulacak Şifre Uzunluğu Nedir ?");
    Console.WriteLine("____________________________________________");
    string uzunluk = Console.ReadLine();
    Console.WriteLine("____________________________________________");
    if (System.Text.RegularExpressions.Regex.IsMatch(uzunluk, "[^0-9]"))
    {
        Console.WriteLine("Sadece Sayı Girebilirsiniz.");
        goto label;
    }
    Console.WriteLine("Kaç Adet Şifre Oluşturalacak ?");
    Console.WriteLine("____________________________________________");
    string adet = Console.ReadLine();
    Console.WriteLine("____________________________________________");
label2:
    if (System.Text.RegularExpressions.Regex.IsMatch(uzunluk, "[^0-9]"))
    {
        Console.WriteLine("Sadece Sayı Girebilirsiniz.");
        goto label2;
    }

    Console.WriteLine("Şifre Türünü Seçiniz.. (1/2)");
    Console.WriteLine("1) Rastgele Şifre");
    Console.WriteLine("2) Anahtar Karakterli Şifre");
    Console.WriteLine("____________________________________________");
label3:
    string secim = Console.ReadLine();
    Console.WriteLine("____________________________________________");
    if (secim == "1")
    {
        Random rnd = new Random();
        string character = "ABCDEFGHIJKLMNOPRSTUVYZQW._-+/?!abcdefghijklmnoprstuvyzqw0123456789";

        for (int z = 0; z < Convert.ToInt64(adet); z++)
        {
            string aaa = "";
            for (int i = 0; i < Convert.ToInt32(uzunluk); i++)
            {
                int r = rnd.Next(0, character.Length);
                aaa = aaa + character[r];
            }
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            Console.WriteLine(aaa);
            Console.WriteLine("____________________________________________");
            string writeText = aaa;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, Environment.NewLine + writeText);
        }
    }
    else if (secim == "2")
    {
        Random rnd = new Random();
        Console.WriteLine("İstediğiniz Karakterleri Giriniziz.");
        Console.WriteLine("____________________________________________");
        string characters = Console.ReadLine();
        Console.WriteLine("____________________________________________");
        for (int z = 0; z < Convert.ToInt64(adet); z++)
        {
            string sonuc = "";
            for (int i = 0; i < Convert.ToInt32(uzunluk); i++)
            {
                int r = rnd.Next(0, characters.Length);
                sonuc = sonuc + characters[r];
            }
            Console.WriteLine(sonuc);
            Console.WriteLine("____________________________________________");
            string writeText = sonuc;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, Environment.NewLine + writeText);
        }
    }
    else
    {
        Console.WriteLine("Lütfen 1 ya da 2 numaralı seçeneği seçiniz.");
        goto label3;
    }
}
sifreolusturucu();