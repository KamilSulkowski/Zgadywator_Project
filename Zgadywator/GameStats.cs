using System;

public class GameStats
{
	public int bestScore { get; set; } = int.MaxValue;
	public int totalAttempts { get; set; } = 0;
	public int totalGames { get; set; } = 0;
    public TimeSpan FastestTime { get; set; } = TimeSpan.MaxValue;
}
