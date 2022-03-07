using UnityEngine;

public class DestoryOnContactWithPlayer : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") Destroy(gameObject);
	}
}
