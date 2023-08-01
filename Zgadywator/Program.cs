using System;
using System.Diagnostics;
using System.IO;

public class Zgadywator
{
    static int playerNumber = 0;
    static int genNumber = 0;
    static int attempt = 0;
    static Stopwatch stopwatch = new Stopwatch();

    static GameStats gameStats = new GameStats();

    public static void Main()
    {
        int playerDec;
        Console.WriteLine("\nZGADYWATOR");
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Graj w zgadywator!");
        Console.WriteLine("2. Sprawdź wyniki");
        Console.WriteLine("3. Wyjdź");
        Console.Write("Twój wybór: ");
        if (int.TryParse(Console.ReadLine(), out playerDec))
        {
            switch (playerDec)
            {
                case 1:
                    playGame();
                    break;
                case 2:

                    break;
                case 3:
                    Console.WriteLine("Dzięki za gre");
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    public static void playGame()
    {
        genANum();
        Console.WriteLine("\nWitaj w Zgadywatorze!");
        Console.WriteLine("Liczba została wygenerowa.\nZgadnij liczbę od 1 do 100.\n");

        stopwatch.Reset();
        stopwatch.Start();

        while (true)
        {

            Console.Write("Wpisz swoją liczbę: ");
            try
            {
                playerNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Błąd! Wpisz liczbę od 1 do 100");
            }
            attempt++;

            toLow();
            toHigh();
            equal();
            if (playerNumber == genNumber)
            {
                congratulation();
                break;
            }

        }
    }

    public static void genANum()
    {
        Random random = new Random();
        genNumber = random.Next(1, 100);
    }

    public static void toLow()
    {
        if (playerNumber < genNumber)
        {
            Console.WriteLine("Twoja liczba jest za mała\n");
        }
    }

    public static void toHigh()
    {
        if (playerNumber > genNumber)
        {
            Console.WriteLine("Twoja liczba jest za duża\n");
        }
    }

    public static void equal()
    {
        if (playerNumber == genNumber)
        {
            Console.WriteLine("Twoja liczba jest za równa wygenerowanej liczbie\n");
        }
    }

    public static void congratulation()
    {
        Console.WriteLine("Gratulację wygrałeś");
        Console.WriteLine($"Odgadnięta liczba: {genNumber}");
        Console.WriteLine($"Liczba prób: {attempt}");
        Console.WriteLine($"Czas: {stopwatch.Elapsed}\n");
    }
}
 