using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
public class Zgadywator
{
    static int playerNumber = 0;
    static int genNumber = 0;
    static int attempt = 0;
    static Stopwatch stopwatch = new Stopwatch();

    static GameStats gameStats = new GameStats();

    public static void Main()
    {
        loadStats();

        while (true)
        {
            Console.WriteLine("\nZGADYWATOR");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Graj w zgadywator!");
            Console.WriteLine("2. Sprawdź wyniki");
            Console.WriteLine("3. Wyjdź");
            Console.Write("Twój wybór: ");
            if (int.TryParse(Console.ReadLine(), out int playerDec))
            {
                switch (playerDec)
                {
                    case 1:
                        playGame();
                        break;
                    case 2:
                        displayStats();
                        break;
                    case 3:
                        Console.WriteLine("Dzięki za gre");
                        SaveStats();
                        return;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
    }

    public static void loadStats()
    {
        string baseFile = "stats.json";

        if (File.Exists(baseFile))
        {
            string jsonStats = File.ReadAllText(baseFile);
            gameStats = JsonConvert.DeserializeObject<GameStats>(jsonStats);
        }
    }
    public static void SaveStats()
    {
        string baseFile = "stats.json";

        gameStats.totalGames++;
        gameStats.totalAttempts += attempt;
        gameStats.bestScore = Math.Min(gameStats.bestScore, attempt);
        gameStats.FastestTime = gameStats.FastestTime < stopwatch.Elapsed ? gameStats.FastestTime : stopwatch.Elapsed;

        string jsonStats = JsonConvert.SerializeObject(gameStats, Formatting.Indented);

        File.WriteAllText(baseFile, jsonStats);

        Console.WriteLine("Statystyki zostały zapisane do pliku.");
    }
    public static void playGame()
    {
        genANum();
        attempt = 0;
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
                SaveStats();
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
            Console.WriteLine("Twoja liczba jest równa wygenerowanej liczbie\n");
        }
    }

    public static void congratulation()
    {
        Console.WriteLine("Gratulację wygrałeś");
        Console.WriteLine($"Odgadnięta liczba: {genNumber}");
        Console.WriteLine($"Liczba prób: {attempt}");
        Console.WriteLine($"Czas: {stopwatch.Elapsed}\n");

        // Sprawdzamy, czy czas wygranej jest najszybszy i go aktualizujemy
        if (stopwatch.Elapsed < gameStats.FastestTime)
        {
            gameStats.FastestTime = stopwatch.Elapsed;
            Console.WriteLine("Najszybszy czas wygranej!");
        }
    }

    public static void displayStats()
    {
        Console.WriteLine("\nStatystyki:");
        Console.WriteLine($"Liczba gier: {gameStats.totalGames}");
        Console.WriteLine($"Średnia liczba prób: {calculateAverageAttempts():F2}");
        Console.WriteLine($"Najlepszy wynik: {gameStats.bestScore}");
        Console.WriteLine($"Najszybszy czas wygranej: {gameStats.FastestTime}\n");
    }

    public static double calculateAverageAttempts()
    {
        if (gameStats.totalGames > 0)
        {
            return (double)gameStats.totalAttempts / gameStats.totalGames;
        }
        return 0;
    }
}
 