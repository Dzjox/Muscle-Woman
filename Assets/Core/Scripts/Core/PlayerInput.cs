using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public Action<float> HorizontalChange;

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
		
		if (Input.GetMouseButton(0))
		{
			HorizontalChange?.Invoke(CalculateValue(Input.mousePosition));
		}
		
		if (Input.touches.Length > 0)
		{
			HorizontalChange?.Invoke(CalculateValue(Input.touches[0].position));
		}
	}

	private float CalculateValue(Vector3 mousePosition)
	{
		return Mathf.InverseLerp(0,Screen.width, mousePosition.x);
	}

	private void OnEndGame(bool isWin)
	{
		this.enabled = false;
	}
}
