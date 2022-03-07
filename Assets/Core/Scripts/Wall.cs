using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	[SerializeField] private Rigidbody[] _bricks;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag =="Player" || other.tag == "Huggy")
			for (int i = 0; i < _bricks.Length; i++)
			{
				_bricks[i].useGravity = true;
			}
	}
}
