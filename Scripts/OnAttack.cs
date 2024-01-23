using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttack : StateMachineBehaviour
{
    private CharCombat _charCombat;

    [SerializeField] private Attacks _attack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _charCombat = animator.GetComponentInParent<CharCombat>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject weapon;

        //weapon = _charCombat.gameObject.GetComponent<CharEquipments>().GetEquipment();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string paramName = "";

        foreach(AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == _attack.ToString())
                paramName = param.name;
        }

        Debug.Log(paramName);

        CharAnimController animController = animator.GetComponentInParent<CharAnimController>();

        animController.PlayAttackAnim(paramName, false);
        _charCombat.SetMoveStatus(true);
        _charCombat._isAttacking = false;
    }

    public enum Attacks
    {
        FirstAttackPerformed,
        SecondAttackPerformed,
        ThirdAttackPerformed
    }
}
