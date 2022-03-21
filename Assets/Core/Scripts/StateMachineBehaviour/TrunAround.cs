using UnityEngine;

public class TurnAround : StateMachineBehaviour
{

	[SerializeField] private bool isSlowDown;

	private float _speed = 7.5f;
	private Transform playerTransform;
	private bool isStop;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerTransform = animator.transform.parent;
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (isStop) return;
		if (isSlowDown) _speed -= _speed * Time.deltaTime;
		playerTransform.position += playerTransform.forward * _speed * Time.deltaTime;
	}

	public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
	{
		isStop = true;
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
