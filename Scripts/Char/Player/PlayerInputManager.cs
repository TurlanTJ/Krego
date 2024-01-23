using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerAnimController _playerAnimController;

    public InputActions _inputActions { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnAttackAction;

    public event EventHandler OnInventoryPanelCalled;
    public event EventHandler OnEquipmentPanelCalled;

    private void Awake()
    {
        _inputActions = new InputActions();

        _inputActions.Player.Movement.Enable();
        _inputActions.Player.Attack.Enable();
        _inputActions.Player.Interact.Enable();

        _inputActions.UI.Inventory.Enable();
        _inputActions.UI.Equipment.Enable();

        _inputActions.Player.Interact.performed += Interact_performed;
        //_inputActions.Player.Attack.performed += Attack_performed;


        _inputActions.UI.Inventory.performed += Inventory_performed;
        _inputActions.UI.Equipment.performed += Equipment_performed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Equipment_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnEquipmentPanelCalled?.Invoke(this, EventArgs.Empty);
    }

    private void Inventory_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInventoryPanelCalled?.Invoke(this, EventArgs.Empty);
    }


    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttackAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _inputActions.Player.Movement.ReadValue<Vector2>();

        return inputVector;
    }
}
