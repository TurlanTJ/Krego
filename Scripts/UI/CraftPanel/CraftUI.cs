using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private GameObject _recipeSlot;
    [SerializeField] private GameObject _slotsParent;

    [SerializeField] private Image _outputIcon;
    [SerializeField] private List<Image> _ingredientsIconsList = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> _ingredientsNameList = new List<TextMeshProUGUI>();

    private List<GameObject> _spawnedReciperSlots = new List<GameObject>();

    public RecipeSO selectedRecipe { get; private set; }

    public void PopulateRecipeSlots(List<RecipeSO> recipes)
    {
        for(var i = 0; i < recipes.Count; i++)
        {
            GameObject slot = Instantiate(_recipeSlot, _slotsParent.transform);
            slot.GetComponent<RecipeSlot>().SetRecipe(recipes[i]);
            _spawnedReciperSlots.Add(slot);
        }
    }

    public void SetSelectedRecipe(RecipeSO recipe)
    {
        selectedRecipe = recipe;

        _outputIcon.sprite = recipe.recipeOutput.icon;

        for(var i = 0; i < recipe.recipeIngredients.Count; i++)
        {
            _ingredientsNameList[i].text = recipe.recipeIngredients[i].name;
            _ingredientsIconsList[i].sprite = recipe.recipeIngredients[i].icon;
        }
    }

    public void Craft()
    {

        if (selectedRecipe == null)
            return;

        int ingredients = selectedRecipe.recipeIngredients.Count;

        foreach (ItemSO item in selectedRecipe.recipeIngredients)
        {
            if (InventoryManager.instance._inventoryList.Contains(item))
                ingredients--;
        }

        if (ingredients <= 0)
        {
            foreach (ItemSO i in selectedRecipe.recipeIngredients)
            {
                InventoryManager.instance.RemoveFromInventory(i);
            }

            InventoryManager.instance.AddItemToInventory(selectedRecipe.recipeOutput);
        }

    }

    public void ClearRecipeSlots()
    {
        ClearSelectedRecipe();

        foreach (GameObject slot in _spawnedReciperSlots)
            Destroy(slot);
    }

    private void ClearSelectedRecipe()
    {
        selectedRecipe = null;

        _outputIcon.sprite = null;

        for (var i = 0; i < 6; i++)
        {
            _ingredientsNameList[i].text = null;
            _ingredientsIconsList[i].sprite = null;
        }
    }
}
