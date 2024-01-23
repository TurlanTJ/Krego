using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharStats _charStats;

    [SerializeField] protected NavMeshAgent _charAgent;

    [SerializeField] protected float _enemyDetectionRadius;

    public CharacterFactions _charFaction;
    public List<CharacterFactions> _enemyFactions = new List<CharacterFactions>();

    public bool canMove = true;

    private void Start()
    {
        _enemyDetectionRadius = 20f;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    public virtual void Move()
    {
               
    }

    public enum CharacterFactions
    {
        Player,
        Civilian,
        Bandit,
        Undead,
        Orc,
        Predator,
        NonPredator
    }
}
