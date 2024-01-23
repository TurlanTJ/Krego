using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent<BanditCombat>(out BanditCombat banditCombat))
        {
            if (banditCombat.GetDeathStatus())
                return;
        }

        if (other.TryGetComponent(out Character _char))
        {
            if (_enemyFactions.Contains(_char._charFaction))
            {
                GetComponent<CharCombat>().SetCombatState(false, true, false);
                transform.LookAt(other.transform.localPosition);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (TryGetComponent<BanditCombat>(out BanditCombat banditCombat))
        {
            if(banditCombat.GetDeathStatus())
                return;
        }


        if (other.TryGetComponent(out Character _char))
        {
            if (_enemyFactions.Contains(_char._charFaction))
                transform.LookAt(other.transform.localPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TryGetComponent<BanditCombat>(out BanditCombat banditCombat))
        {
            if (banditCombat.GetDeathStatus())
                return;
        }

        if (other.TryGetComponent(out Character _char))
        {
            if (_enemyFactions.Contains(_char._charFaction))
                GetComponent<CharCombat>().SetCombatState(false, false, false);
        }
    }
}
