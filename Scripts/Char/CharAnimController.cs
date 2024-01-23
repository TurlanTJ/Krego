using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    public string moveVelParam { get; private set; }
    public string firstAttackPerformed { get; private set; }
    public string secondAttackPerformed { get; private set; }
    public string thirdAttackPerformed { get; private set; }
    public string inCombatParam { get; private set; }
    public string hasDiedParam { get; private set; }

    private void Awake()
    {
        moveVelParam = "MovementVelocity";
        firstAttackPerformed = "FirstAttackPerformed";
        secondAttackPerformed = "SecondAttackPerformed";
        thirdAttackPerformed = "ThirdAttackPerformed";
        inCombatParam = "InCombat";
        hasDiedParam = "HasDied";
    }

    private void Update()
    {
        bool inCombat = GetComponent<CharCombat>()._inCombat;

        _animator.SetBool(inCombatParam, inCombat);

        if (inCombat)
            SetLayerWeight(1, 1f);
    }

    public virtual void SetLayerWeight(int layer, float layerWeight)
    {
        _animator.SetLayerWeight(layer, layerWeight);
    }

    public virtual void PlayAttackAnim(string attack, bool status)
    {
        _animator.SetBool(attack, status);
    }

    public virtual void PlayMovementAnim(float vel)
    {
        _animator.SetFloat(moveVelParam, vel, 0.2f, Time.deltaTime);
    }

    public virtual void PlayDeathAnim()
    {
        _animator.SetTrigger(hasDiedParam);
    }
}
