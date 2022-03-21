using UnityEngine;

public class MoveForward : StateMachineBehaviour
{
	private Transform _playerTransform;

	private float _rotationSpeed = 1;
	private float _coeff = 0;
	private Quaternion _startRotation;
	private Quaternion _endRotation;


	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_playerTransform = animator.transform.parent;
		_startRotation = _playerTransform.rotation;
		_endRotation = Quaternion.Euler(_startRotation.eulerAngles + new Vector3(0,-180,0));
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_coeff += _rotationSpeed * Time.fixedDeltaTime;
		_playerTransform.rotation = Quaternion.Lerp(_startRotation, _endRotation, _coeff);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{

	//}

	// OnStateMove is called right after Animator.OnAnimatorMove()
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that processes and affects root motion
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK()
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that sets up animation IK (inverse kinematics)
	//}
}
