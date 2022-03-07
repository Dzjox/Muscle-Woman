using System;

public class PlayerInfo
{
	private int _money;
	public int Money 
	{ 
		get { return _money; }
		set 
		{
			_money = value;
			ChangeMoney?.Invoke(_money);
		}
	}

	public Action<int> ChangeMoney; 

	public PlayerInfo(int money)
	{
		Money = money;
	}

	public void AddMoney(int delta)
	{
		Money += delta;
	}

	public void SpendMoney(int delta)
	{
		Money -= delta;
	}
}
