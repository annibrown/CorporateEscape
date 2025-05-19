using UnityEngine;

public static class ScoreKeeper
{
    private static int score = 0;

    public static void Add(int amount)
    {
        score += amount;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void Reset()
    {
        score = 0;
    }
    
}
