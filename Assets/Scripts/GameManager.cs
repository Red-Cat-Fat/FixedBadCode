using System.Collections.Generic;

public class GameManager
{
    private static GameManager _instance;

    public static GameManager Instance
        => _instance ??= new GameManager();

    public Dictionary<string, int> TotalBals = new Dictionary<string, int>();
    
    private GameManager()
    {
        TotalBals["red"] = 0;
        TotalBals["green"] = 0;
        TotalBals["blue"] = 0;
    }
}
