namespace Dovus
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Oyun Karakterlerini Seçiniz:");
            Console.WriteLine("1. Savaşçı");
            Console.WriteLine("2. Büyücü");
            Console.WriteLine("3. Elf");
            Console.WriteLine("4. Ork");

            
            int userChoice = GetUserChoice(1, 4);

            // Seçilen karaktere göre özellikleri belirle
            int userHealth = 0;
            int userAttackPower = 0;

            switch (userChoice)
            {
                case 1:
                    userHealth = 120;
                    userAttackPower = 15;
                    break;
                case 2:
                    userHealth = 80;
                    userAttackPower = 20;
                    break;
                case 3:
                    userHealth = 100;
                    userAttackPower = 12;
                    break;
                case 4:
                    userHealth = 90;
                    userAttackPower = 18;
                    break;
            }

           
            Random random = new Random();
            int computerHealth = random.Next(80, 121);
            int computerAttackPower = random.Next(10, 21);

            // Oyun döngüsü
            while (true)
            {
                
                Console.WriteLine("Siz saldırıyorsunuz!");
                bool userHit = CheckHit();
                if (userHit)
                {
                    Console.WriteLine("İsabet!");
                    computerHealth -= userAttackPower;
                }
                else
                {
                    Console.WriteLine("İsabetsiz!");
                }
                Thread.Sleep(1000);
               
                Console.WriteLine("Bilgisayar saldırıyor!");
                bool computerHit = CheckHit();
                if (computerHit)
                {
                    Console.WriteLine("İsabet!");
                    userHealth -= computerAttackPower;
                }
                else
                {
                    Console.WriteLine("İsabetsiz!");
                }
                Thread.Sleep(1000);

               
                if (userHealth <= 0)
                {
                    Console.WriteLine("Oyun bitti! Kaybettiniz.");
                    break;
                }

                if (computerHealth <= 0)
                {
                    Console.WriteLine("Oyun bitti! Kazandınız.");
                    break;
                }
            }
        }

        static int GetUserChoice(int minValue, int maxValue)
        {
            int userChoice = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Seçiminizi yapınız: ");
                try
                {
                    
                    if (userChoice < minValue || userChoice > maxValue)
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen daha küçük bir sayı girin.");
                }

            } while ( userChoice < minValue || userChoice > maxValue);

            return userChoice;
        }

        static bool CheckHit()
        {
            Random random = new Random();
            return random.Next(0, 2) == 0; // 0 veya 1 döner (50% isabet şansı)
        }
    }

}
