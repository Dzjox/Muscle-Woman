using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
	private readonly int _addMoney = 15;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Money") ContextManager.Instance.PlayerInfo.AddMoney(_addMoney);
	}
}
