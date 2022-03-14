using System;
using UnityEngine;

public class PlayerMuscle : MonoBehaviour
{
	[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
	[SerializeField] private float _muscles = 0;

	[SerializeField] private float _addMuscleWithWeght = 7f;
	[SerializeField] private float _addMuscleWithDumbbell = 3f;

	[SerializeField] private  float _removeMuscleWithWall = 20f;
	[SerializeField] private float _removeMuscleWithTreadmill = 30f;

	public static Action<float> ChangeMuscle;
	private bool isTreadmill;

	private float Muscle 
	{
		get { return _muscles; }
		set
		{
			if (value > 100) _muscles = 100;
			else if (value < 0) _muscles = 0;
			else _muscles = value;

			_skinnedMeshRenderer.SetBlendShapeWeight(0,_muscles);
			ChangeMuscle?.Invoke(_muscles);
		}
	}

	private void FixedUpdate()
	{
		if (!isTreadmill) return;
		Muscle -= _removeMuscleWithTreadmill * Time.fixedDeltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Weight") Muscle += _addMuscleWithWeght;
		if (other.tag == "Dumbbell") Muscle += _addMuscleWithDumbbell;

		if (other.tag == "Wall") Muscle -= _removeMuscleWithWall;
		if (other.tag == "Treadmill") isTreadmill = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Treadmill") isTreadmill = false;
	}
}
