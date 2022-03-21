using System;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
	public Action OnEndGameTrigger;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") OnEndGameTrigger?.Invoke();
	}
}
