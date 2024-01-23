using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombat : MonoBehaviour
{
    [SerializeField] protected CharAnimController _animController;
    [SerializeField] protected CharStats _charStats;
    [SerializeField] protected Character _char;

    [SerializeField] protected float _timeToLeaveCombat = 10f;

    protected bool IsDead = false;

    //public List<CharCombat> affectedTargets = new List<CharCombat>();

    public bool _inCombat = false;
    public bool _isAttacking = false;

    public int attackCount { get; protected set; }
    public float timeToNextAttack { get; protected set; }

    private void Start()
    {
        attackCount = 0;
    }

    private void Update()
    {
        if (_inCombat)
        {
            _timeToLeaveCombat -= Time.deltaTime;

            if(_timeToLeaveCombat <= 1f)
            {
                SetCombatState(false, false, false);
                _timeToLeaveCombat = 10f;
            }
        }
    }

    public virtual void Attack(int damage, Vector3 attackDirection, int attackCount)
    {

        if (!_inCombat)
        {
            SetCombatState(false, false, true);
            return;
        }

        _isAttacking = true;

        _char.transform.forward = attackDirection;

        switch (attackCount)
        {
            case 1:
                _animController.PlayAttackAnim(_animController.firstAttackPerformed, true);
                break;
            case 2:
                _animController.PlayAttackAnim(_animController.secondAttackPerformed, true);
                break;
            case 3:
                _animController.PlayAttackAnim(_animController.thirdAttackPerformed, true);
                break;
        }
    }

    public virtual void RecieveDamage(int damage)
    {
        if(!_inCombat)
            SetCombatState(true, false, false);

        _charStats.health -= damage;
    }

    public virtual void Heal(int heal)
    {
        _charStats.health += heal;

        if(_charStats.health > _charStats._currMaxHealth)
            _charStats.health = _charStats._currMaxHealth;
    }

    public virtual void SetCombatState(bool tookDamage, bool detectedEnemy, bool performedAttack)
    {
        if (tookDamage || detectedEnemy || performedAttack)
            _inCombat = true;
        else
            _inCombat = false;
    }

    public void SetMoveStatus(bool status)
    {
        _char.canMove = status;
    }

    public virtual void Die()
    {
        _char.canMove = false;
        _animController.PlayDeathAnim();
    }
}
