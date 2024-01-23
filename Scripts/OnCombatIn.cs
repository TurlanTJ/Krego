using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCombatIn : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetComponentInParent<CharEquipments>() != null)
        {
            CharEquipments charEq = animator.GetComponentInParent<CharEquipments>();
            charEq.EquipEquipment();
        }
    }
}
