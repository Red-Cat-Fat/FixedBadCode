using System.Collections.Generic;

public enum BallType
{
    Red = 0,
    Green = 1,
    Blue = 2,
}

public class BallCounter
{
    private readonly Dictionary<BallType, int> _totalBalls = new Dictionary<BallType, int>();
    
    public BallCounter()
    {
        _totalBalls[BallType.Red] = 0;
        _totalBalls[BallType.Green] = 0;
        _totalBalls[BallType.Blue] = 0;
    }

    public int GetValue(BallType type)
    {
        return _totalBalls[type];
    }
    
    public void AddBall(BallType type)
    {
        _totalBalls[type]++;
    }

    public void DelBall(BallType type)
    {
        _totalBalls[type]--;
    }
}
