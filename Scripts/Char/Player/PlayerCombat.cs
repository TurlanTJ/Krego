using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCombat : CharCombat
{
    [SerializeField] private PlayerInputManager _playerInputManager;

    public delegate void PlayerHasDied();
    public PlayerHasDied playerHasDied;

    private bool _playerDied;

    // Start is called before the first frame update
    private void Start()
    {
        _playerInputManager.OnAttackAction += _playerInputManager_OnAttackAction;

        timeToNextAttack = 2f;

        _playerDied = false;
    }

    void Update()
    {
        if (!_playerDied && _charStats.health <= 0)
            Die();

        if (Input.GetKeyDown(KeyCode.Space))
            _inCombat = !_inCombat;

        timeToNextAttack -= Time.deltaTime;

        if (_isAttacking)
        {

        }

        if (timeToNextAttack < 1f)
        {
            attackCount = 0;
            timeToNextAttack = 2f;
        }
    }

    private void _playerInputManager_OnAttackAction(object sender, EventArgs e)
    {
        if (CanAttack())
        {
            SetMoveStatus(false);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (timeToNextAttack >= 0)
            {
                if (attackCount == 2)
                    Attack(_charStats.damage, mousePos, 2);
                
                if(attackCount == 3)
                    Attack(_charStats.damage, mousePos, 3);
            }
            else
                Attack(_charStats.damage, mousePos, 1);

            attackCount++;
        }
    }

    // Update is called once per frame

    public override void Attack(int damage, Vector3 attackDirection, int attackCount)
    {
        base.Attack(damage, attackDirection, attackCount);
    }


    private bool CanAttack()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return false;

        return true;
    }

    public override void Die()
    {
        base.Die();
        _playerDied = true;
        playerHasDied?.Invoke();
    }
}
