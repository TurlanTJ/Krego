using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    protected int _baseHealth { get; private set; }
    protected int _baseDamage { get; private set; }
    protected int _baseArmour { get; private set; }
    protected float _baseMoveSpeed { get; private set; }
    public float baseRotSpeed = 15f;

    public int health;
    public int damage;
    public int armour;
    public float moveSpeed;

    public int _currMaxHealth;
    public int _currMaxArmour;
    public int _currMaxDamage;
    public float _currMaxMoveSpeed;

    public int maxHealth { get; private set; }
    public int maxDamage { get; private set; }
    public int maxArmour { get; private set; }
    public float maxMoveSpeed { get; private set; }

    public void ApplyModifier(int healthMod, int damageMod, int armourMod, int moveSpeedMod)
    {
        _currMaxHealth = _baseHealth + healthMod;
        _currMaxDamage = _baseDamage + damageMod;
        _currMaxArmour = _baseArmour + armourMod;
        _currMaxMoveSpeed = _baseMoveSpeed + moveSpeedMod;
    }

    protected void SetToBase(int healthBase, int damageBase, int armourBase, float moveSpeedBase)
    {
        _baseHealth = healthBase;
        _baseDamage = damageBase;
        _baseArmour = armourBase;
        _baseMoveSpeed = moveSpeedBase;
    }

    protected void SetToCurrMaxStats()
    {
        health = _currMaxHealth;
        damage = _currMaxDamage;
        armour = _currMaxArmour;
        moveSpeed = _currMaxMoveSpeed;
    }

    protected void ApplyEffects()
    {

    }
}