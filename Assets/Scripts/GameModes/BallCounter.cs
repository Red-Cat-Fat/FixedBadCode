using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BallType
{
	Red = 0,
	Green = 1,
	Blue = 2,
}

public class BallCounter
{
	private readonly Dictionary<BallType, int> _totalBallsCounter = new Dictionary<BallType, int>();
	private readonly Dictionary<BallType, List<GameObject>> _allBalls = new Dictionary<BallType, List<GameObject>>();

	public BallCounter()
	{
		_totalBallsCounter[BallType.Red] = 0;
		_totalBallsCounter[BallType.Green] = 0;
		_totalBallsCounter[BallType.Blue] = 0;
	}

	public int GetValue(BallType type)
	{
		return _totalBallsCounter[type];
	}

	public void AddBall(BallType type, GameObject newGameObject)
	{
		_totalBallsCounter[type]++;
		if(!_allBalls.TryGetValue(type, out var list))
		{
			list = new List<GameObject>();
			_allBalls.Add(type, list);
		}
		list.Add(newGameObject);
	}

	public void DelBall(BallType type, GameObject gameObject)
	{
		_totalBallsCounter[type]--;
		if(!_allBalls.TryGetValue(type, out var list))
		{
			list = new List<GameObject>();
			_allBalls.Add(type, list);
		}
		list.Remove(gameObject);
	}
	
	public GameObject GetRandomBall(BallType targetType)
	{
		if(_allBalls.TryGetValue(targetType, out var list))
		{
			if(list.Count > 0)
				return list[Random.Range(0, list.Count)];
		}
		return null;
	}
}