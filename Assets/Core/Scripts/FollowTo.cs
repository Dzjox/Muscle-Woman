using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTo : MonoBehaviour
{
	[SerializeField] private Transform _target;
	private Vector3 _offset;

	private void Start()
	{
		_offset = transform.position - _target.position;
	}

	private void Update()
	{
		transform.position = _target.position + _offset;
	}
}
