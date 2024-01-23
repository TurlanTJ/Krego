using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCombat : CharCombat
{


    // Update is called once per frame
    void Update()
    {
        if(_charStats.health <= 0)
        {
            if (!IsDead)
            {
                IsDead = true;
                _animController.PlayDeathAnim();
            }
        }
    }

    public bool GetDeathStatus()
    {
        return IsDead;
    }
}
