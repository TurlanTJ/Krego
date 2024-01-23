using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableInteract : Interactable
{
    [SerializeField] private List<RecipeSO> _craftRecipes;
    [SerializeField] private List<RecipeSO> _availableRecipes;

    private PlayerManager _playerManager;
    private LearntRecipes _learntRecipes;
    private UIManager _UIManager;

    private void Start()
    {
        _playerManager = PlayerManager.playerManager;
        _UIManager = UIManager.instance;

        _learntRecipes = _playerManager.GetPlayer().GetComponent<LearntRecipes>();
    }

    public override void Interact()
    {
        base.Interact();

        List<RecipeSO> knownRecipes = new List<RecipeSO>();

        foreach (RecipeSO r in _learntRecipes.knownRecipes)
        {
            if (r.recipeType == RecipeType.Weapon || r.recipeType == RecipeType.Armour)
                knownRecipes.Add(r);
        }

        foreach (RecipeSO recipe in _craftRecipes)
        {
            foreach(RecipeSO knownRecipe in knownRecipes)
            {
                if (recipe == knownRecipe && !_availableRecipes.Contains(recipe))
                {
                    _availableRecipes.Add(recipe);
                    break;
                }           
            }
        }

        _UIManager.onCraftingActionCalled?.Invoke(_availableRecipes);
    }
}