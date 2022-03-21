using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[Space]
	[SerializeField] private Transform _startCamera;
	[SerializeField] private Transform _endCamera;

	private Vector3 _offset;
	private bool _isFollow;

	private readonly float _timeToSetEndCamera = 1f;

	private void Awake()
	{
		transform.position = _startCamera.position;
		transform.rotation = _startCamera.rotation;

		_offset = _startCamera.position - _target.position;
		_isFollow = true;
	}

	private void Start()
	{
		EndGameCinema.Instance.EndGame += OnEndGame;
	}

	private void OnDestroy()
	{
		EndGameCinema.Instance.EndGame -= OnEndGame;
	}

	private void Update()
	{
		if (_isFollow) transform.position = _target.position + _offset;
	}

	private void OnEndGame(bool isWin)
	{
		_isFollow = false;
		if (isWin) StartCoroutine(WinRoutine());
		else StartCoroutine(LoseRoutine());
	}

	private IEnumerator WinRoutine()
	{
		var cameraSetTime = Time.time + _timeToSetEndCamera;
		float coeff = 0;
		do
		{
			coeff += _timeToSetEndCamera * Time.fixedDeltaTime;
			transform.position = Vector3.Lerp(transform.position,_endCamera.position, coeff);
			transform.rotation = Quaternion.Lerp(transform.rotation, _endCamera.rotation, coeff);
			yield return new WaitForFixedUpdate();
		} while (Time.time < cameraSetTime);
	}

	private IEnumerator LoseRoutine()
	{
		yield return null;
	}

}
