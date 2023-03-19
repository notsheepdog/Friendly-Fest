using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngredientGameManager : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public Level2SO levelTwoState;
    // Start is called before the first frame update
    void Start()
    {
        counter.text = "Ingredients: " + IngredientDisappear.ingredientsFound + "/" + IngredientDisappear.totalIngredients;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = "Ingredients: " + IngredientDisappear.ingredientsFound + "/" + IngredientDisappear.totalIngredients;
        if (IngredientDisappear.ingredientsFound == IngredientDisappear.totalIngredients)
        {
            //level manager call
            levelTwoState.ingreadientsFound = true;
            GameObject.FindObjectOfType<LevelManager>().MoveToNextScene();
        }
    }
}
