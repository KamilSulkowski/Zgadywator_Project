using System.Diagnostics;
using System.Security.Cryptography;

public class Zgadywator
{
    static int playerNumber = 0;
    static int genNumber = 0;
    static int attempt = 0;

    public static void Main()
    {

    }

    public static void playGame()
    {

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
    }
}
 