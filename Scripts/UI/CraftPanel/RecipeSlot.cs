using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private Image _recipeIcon;
    [SerializeField] private TextMeshProUGUI _recipeName;

    [SerializeField] private GameObject _selectedRecipe;

    public RecipeSO recipe;

    public void SetRecipe(RecipeSO recipe)
    {
        this.recipe = recipe;
        _recipeIcon.sprite = recipe.recipeOutput.icon;
        _recipeName.text = recipe.recipeName;
    }

    public void SelectRecipe()
    {
        if(GetComponentInParent<CraftUI>() != null)
        {
            GetComponentInParent<CraftUI>().SetSelectedRecipe(recipe);
        }
    }
}
