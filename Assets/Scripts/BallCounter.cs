using System.Collections.Generic;

public class BallCounter
{
    public Dictionary<string, int> TotalBals = new Dictionary<string, int>();
    
    public BallCounter()
    {
        TotalBals["red"] = 0;
        TotalBals["green"] = 0;
        TotalBals["blue"] = 0;
    }
}
