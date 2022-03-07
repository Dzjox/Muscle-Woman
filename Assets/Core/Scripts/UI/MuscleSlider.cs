using UnityEngine;
using UnityEngine.UI;

public class MuscleSlider : MonoBehaviour
{
	[SerializeField] private Slider _slider;

	private void Start()
	{
		PlayerMuscle.ChangeMuscle += ((value) => _slider.value = value/100);
	}
}
