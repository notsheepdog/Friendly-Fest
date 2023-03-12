using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IngredientDisappear.ingredientsFound == IngredientDisappear.totalIngredients)
        {
            Debug.Log("done!");
            //level manager call
        }
    }
}
