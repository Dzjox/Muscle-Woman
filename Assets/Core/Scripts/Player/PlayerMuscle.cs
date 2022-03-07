using System;
using UnityEngine;

public class PlayerMuscle : MonoBehaviour
{
	[SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
	[SerializeField] private float _muscles = 0;

	public static Action<float> ChangeMuscle;

	[SerializeField] private float _addMuscleWithWeght = 7f;
	[SerializeField] private float _addMuscleWithDumbbell = 3f;

	[SerializeField] private  float _removeMuscleWithWall = 20f;
	[SerializeField] private float _removeMuscleWithTreadmill = 10f;

	private float Muscle 
	{
		get { return _muscles; }
		set
		{
			if (value > 100) _muscles = 100;
			else if (value < 0) _muscles = 0;
			else _muscles = value;

			_skinnedMeshRenderer.SetBlendShapeWeight(0,_muscles);
			ChangeMuscle.Invoke(_muscles);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Weight") Muscle += _addMuscleWithWeght;
		if (other.tag == "Dumbbell") Muscle += _addMuscleWithDumbbell;

		if (other.tag == "Wall") Muscle -= _removeMuscleWithWall;
		if (other.tag == "Treadmill") Muscle -= _removeMuscleWithTreadmill;
	}
}
