using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerInput _playerInput;
	[SerializeField] private float _speed;
	[SerializeField] private float _sideSpeed;
	[SerializeField, Range(0f, 1f)] private float _placeOnRaod = 0.5f;


	private readonly Vector3 _direction = new Vector3(0,0,1);
	private readonly float _roadWidth = 2.4f;

	private void Start()
	{
		_playerInput.HorizontalChange += ((value) => _placeOnRaod = value);
	}

	private void Update()
	{
		transform.position += MoveForward() + MoveSide();
	}

	private Vector3 MoveForward()
	{
		return _direction * _speed * Time.deltaTime;
	}

	private Vector3 MoveSide()
	{
		var target = Mathf.Lerp( _roadWidth/2, - _roadWidth/2, _placeOnRaod);

		if (Mathf.Abs(transform.position.x - target) < _sideSpeed * Time.deltaTime) return Vector3.zero;

		var result = new Vector3(1, 0, 0) * _sideSpeed * Time.deltaTime;

		return (transform.position.x - target > 0) ? - result : result;
	}

}
