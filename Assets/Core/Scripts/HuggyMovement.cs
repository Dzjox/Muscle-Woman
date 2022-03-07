using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggyMovement : MonoBehaviour
{
	[SerializeField] private float _speed;

	private readonly Vector3 _direction = new Vector3(0, 0, 1);

	private void Update()
	{
		transform.position += _direction * _speed * Time.deltaTime;
	}
}
