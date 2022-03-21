using System;
using UnityEditor.Animations;
using UnityEngine;

public class EndGameCinema : MonoBehaviour
{
	private static EndGameCinema _instance;
	public static EndGameCinema Instance => _instance;

	[SerializeField] private EndGameTrigger _playerEndGame;
	[Space]
	[SerializeField] private Animator _playerAnimator;
	[SerializeField] private Animator _huggyAnimator;
	//[Space]
	//[SerializeField] private AnimatorController _playerController;
	//[SerializeField] private AnimatorController _huggyController;
	//[Space]
	[SerializeField] private Vector3 _cinemaCenterFromFinish = new Vector3 (0,0,5f);

	public Action<bool> EndGame;

	private Camera _mainCamera;
	private Transform _playerTransform;
	private Transform _huggyTransform;
	private Vector3 _cameraOffset;

	public Vector3 CinemaCenter => _playerEndGame.transform.position + _cinemaCenterFromFinish;

	private void Awake()
	{
		if (_instance == null) _instance = this;

		_mainCamera = Camera.main;
		_playerTransform = _playerAnimator.transform.parent;
		_huggyTransform = _huggyAnimator.transform.parent;
		_playerEndGame.OnEndGameTrigger += StartEnd;
	}

	private void OnDestroy()
	{
		_playerEndGame.OnEndGameTrigger -= StartEnd;
	}

	private void StartEnd()
	{
		EndGame?.Invoke(true);
	}


}
