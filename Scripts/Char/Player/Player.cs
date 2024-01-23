using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : Character
{
    [SerializeField] private PlayerInputManager _playerInputManager;
    [SerializeField] private PlayerAnimController _playerAnimController;

    private List<Interactable> _interactablesList = new List<Interactable>();

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager.OnInteractAction += _playerInputManager_OnInteraction;

        _charFaction = CharacterFactions.Player;

        _enemyFactions.Add(CharacterFactions.Bandit);
        _enemyFactions.Add(CharacterFactions.Orc);
        _enemyFactions.Add(CharacterFactions.Predator);
        _enemyFactions.Add(CharacterFactions.NonPredator);
    }

    private void _playerInputManager_OnInteraction(object sender, System.EventArgs e)
    {
        Interact();
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        if (canMove)
            Move();
        else
            _playerAnimController.PlayMovementAnim(0f);
    }

    private void Interact()
    {
        if (_interactablesList.Count == 0)
            return;

        Vector3 closestInteractableDist = new Vector3(10f, 10f, 10f);

        Interactable closestInteractable = _interactablesList[0];

        if (_interactablesList.Count > 1)
        {
            foreach (Interactable item in _interactablesList)
            {
                Vector3 dist = transform.position - item.transform.position;

                if (dist.magnitude < closestInteractableDist.magnitude)
                {
                    closestInteractableDist = dist;
                    closestInteractable = item;
                }         
            }
        }

        closestInteractable.Interact();

        if(closestInteractable.TryGetComponent<ItemPickUp>(out ItemPickUp itemPickUp))
            _interactablesList.Remove(closestInteractable);
    }

    public override void Move()
    {
        Vector2 inputVector = _playerInputManager.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 vel = moveDir * _charStats.moveSpeed;

        _charAgent.Move(vel * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, moveDir, _charStats.baseRotSpeed * Time.deltaTime);
        _playerAnimController.PlayMovementAnim(vel.normalized.magnitude);
    }

    public void ApplyEffects(ConsumableSO consumableSO)
    {
        if (consumableSO.consumableEffect == ConsumableEffect.Heal)
            GetComponent<PlayerCombat>().Heal(consumableSO.consumableEffectModifier);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Interactable interactable))
        {
            _interactablesList.Add(interactable);

            if (other.TryGetComponent(out InteractableSign sign))
                sign.ShowInteractSign(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            _interactablesList.Remove(interactable);

            if (other.TryGetComponent(out InteractableSign sign))
                sign.ShowInteractSign(false);
        }
    }
}
