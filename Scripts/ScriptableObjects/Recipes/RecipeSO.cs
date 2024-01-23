using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipes")]
public class RecipeSO : ScriptableObject
{
    public string recipeID;
    public string recipeName;
    public List<ItemSO> recipeIngredients;
    public ItemSO recipeOutput;

    public RecipeType recipeType;
}

public enum RecipeType
{
    Food,
    Potion,
    Weapon,
    Armour
}
