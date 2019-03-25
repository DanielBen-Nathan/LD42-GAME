using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	 //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      
        animator.gameObject.GetComponent<EnemyMovement>().enabled = true;
        animator.gameObject.GetComponent<Skeleton>().enabled = true;
        animator.gameObject.GetComponent<Skeleton>().spawned = true;
        animator.gameObject.transform.GetComponentInChildren<EnemyShootArrows>().enabled=true;
        animator.gameObject.GetComponent<Rigidbody2D>().mass = animator.gameObject.GetComponent<Rigidbody2D>().mass / 1000;
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Debug.Log("activate");
        //animator.gameObject.GetComponent<Movement>().enabled = true;
    }
}
