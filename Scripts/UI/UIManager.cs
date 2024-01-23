using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _InventoryUIPanel;
    [SerializeField] private GameObject _EquipmentUIPanel;
    [SerializeField] private GameObject _CraftUIPanel;
    [SerializeField] private GameObject _LootUIPanel;
    [SerializeField] private GameObject _GameOverUIPanel;

    [SerializeField] private PlayerInputManager _playerInputManager;

    public static UIManager instance;

    public delegate void OnLootingActionCalled(List<ItemSO> loot);
    public OnLootingActionCalled onLootingActionCalled;

    public delegate void OnCraftingActionCalled(List<RecipeSO> recipes);
    public OnCraftingActionCalled onCraftingActionCalled;
    public OnCraftingActionCalled onCookingActionCalled;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;

        onLootingActionCalled += EnabelAndPopulateLootItems;
        onCraftingActionCalled += EnableCraftingPanel;
        onCookingActionCalled += EnableCraftingPanel;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager.OnEquipmentPanelCalled += _playerInputManager_OnEquipmentPanelCalled;
        _playerInputManager.OnInventoryPanelCalled += _playerInputManager_OnInventoryPanelCalled;

        _playerInputManager.GetComponent<PlayerCombat>().playerHasDied += SetGameOverUIActive;

        _InventoryUIPanel.SetActive(true);
        _EquipmentUIPanel.SetActive(true);
        _GameOverUIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCraftPanel()
    {
        _CraftUIPanel.GetComponent<CraftUI>().ClearRecipeSlots();
        _CraftUIPanel.SetActive(false);
    }

    public void CloseLootPanel()
    {
        _LootUIPanel.SetActive(false);
    }

    private void _playerInputManager_OnEquipmentPanelCalled(object sender, EventArgs e)
    {
        OnEquipmenActionPerformed();
    }

    private void _playerInputManager_OnInventoryPanelCalled(object sender, EventArgs e)
    {
        OnInventoryActionPerformed();
    }

    public void OnEquipmenActionPerformed()
    {
        _EquipmentUIPanel.SetActive(!_EquipmentUIPanel.activeSelf);
    }

    private void OnInventoryActionPerformed()
    {
        _InventoryUIPanel.SetActive(!_InventoryUIPanel.activeSelf);
    }

    private void EnableCraftingPanel(List<RecipeSO> recipes)
    {
        _CraftUIPanel.GetComponent<CraftUI>().PopulateRecipeSlots(recipes);

        _CraftUIPanel.SetActive(true);

        
    }

    private void EnabelAndPopulateLootItems(List<ItemSO> loot)
    {
        _LootUIPanel.GetComponent<PopulateLootSlots>().PopulateSlots(loot);

        _LootUIPanel.SetActive(true);



        //_LootUIPanel.SetActive(false);
    }

    private void SetGameOverUIActive()
    {
        StartCoroutine(OnPlayerDeath());
    }

    private IEnumerator OnPlayerDeath()
    {
        yield return new WaitForSecondsRealtime(2);
        _GameOverUIPanel.SetActive(true);
    }
}
