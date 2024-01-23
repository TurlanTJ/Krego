using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearntRecipes : MonoBehaviour
{
    public List<RecipeSO> knownRecipes = new List<RecipeSO>();

    private void Update()
    {
        
    }

    public void LearnNewRecipe(RecipeSO recipe)
    {
        knownRecipes.Add(recipe);
    }
}
