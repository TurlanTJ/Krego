using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats
{
    private int _maxHealth = 200;
    private int _maxArmour = 100;
    private float _maxMoveSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        SetToBase(100, 20, 0, 10);
        ApplyModifier(0, 0, 0, 0);
        SetToCurrMaxStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            gameObject.GetComponent<CharCombat>().RecieveDamage(5);

    }


}
