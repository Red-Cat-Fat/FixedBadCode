using System.Collections.Generic;

public enum BallType
{
    Red = 0,
    Green = 1,
    Blue = 2,
}

public class BallCounter
{
    private readonly Dictionary<BallType, int> _totalBals = new Dictionary<BallType, int>();
    
    public BallCounter()
    {
        _totalBals[BallType.Red] = 0;
        _totalBals[BallType.Green] = 0;
        _totalBals[BallType.Blue] = 0;
    }

    public int GetValue(BallType type)
    {
        return _totalBals[type];
    }
    
    public void AddBall(BallType type)
    {
        _totalBals[type]++;
    }

    public void DelBall(BallType type)
    {
        _totalBals[type]--;
    }
}
