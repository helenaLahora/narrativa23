using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class WonderBehaviour : StateMachineBehaviour
{
    Transform player;

    //public List<Transform> wayPoints;
    //private int nextPosition = 0;
    //private int lastPosition = 0;
    //public float speed = 3f;
    //private Vector3 dir;
    //private Vector3 goTo;
    //private bool isReturning = false;
    public float detectDistance = 4;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //CheckPosition(animator);
        //SetDirection(animator);
        Execute(animator);
        CheckTriggers(animator);

    }

    private void CheckTriggers(Animator animator)
    {
        bool isPlayer = isPlayerClose(player, animator.transform);
        animator.SetBool("IsChasing", isPlayer);
        animator.SetBool("IsPatrolling", !isPlayer);    }

    private void Execute(Animator animator)
    {

        //Vector3 displacement = speed * Time.deltaTime * goTo;
        //animator.transform.Translate(displacement);
    }
    //private void SetDirection(Animator animator)
    //{

        //    dir = wayPoints[nextPosition].position;
        //    goTo = new Vector3( wayPoints[nextPosition].position.x - animator.transform.position.x,0, wayPoints[nextPosition].position.z - animator.transform.position.z);
        //    Debug.Log(goTo);
        //}
        //private void CheckPosition(Animator animator)
        //{
        //    if (goTo.magnitude < 1 && nextPosition >= length-1 || isReturning == true && goTo.magnitude < 1)
        //    {
        //        lastPosition = nextPosition;
        //        nextPosition--;
        //        dir = wayPoints[nextPosition].position;
        //        isReturning = true;
        //        if (nextPosition <= 0)
        //        {
        //            isReturning = false;
        //        }

        //    }
        //    else if (goTo.magnitude<1 && isReturning == false && nextPosition < length - 1)
        //    {
        //        lastPosition = nextPosition;
        //        nextPosition++;
        //        dir = wayPoints[nextPosition].position;

        //    }


        //}

     private bool isPlayerClose(Transform player, Transform enemy)
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


