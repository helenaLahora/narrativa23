using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    public float speed = 5f;
    private Vector3 goTo;
    public float detectDistance = 4f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDirection(animator);
        Execute(animator);
        CheckTriggers(animator);

    }
    private void Execute(Animator animator)
    {

        Vector3 displacement = (speed/2) * Time.deltaTime * (goTo - Vector3.one);
        animator.transform.Translate(displacement);
    }
    private void SetDirection(Animator animator)
    {


        goTo = new Vector3(player.position.x - animator.transform.position.x, 0, player.position.z - animator.transform.position.z);
    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsChasing", isPlayer);
        animator.SetBool("IsPatrolling", !isPlayer);
    }
    public bool isPlayerClose(Transform player, Transform enemy)
    {

        return Vector3.Distance(player.position, enemy.position) < detectDistance;
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
