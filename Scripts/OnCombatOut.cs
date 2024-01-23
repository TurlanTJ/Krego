using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCombatOut : StateMachineBehaviour
{
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharEquipments charEq = animator.GetComponentInParent<CharEquipments>();

        if (charEq != null)
            charEq.UnequipEqipment();
        animator.GetComponentInParent<CharAnimController>().SetLayerWeight(layerIndex, 0f);
    }
}
