using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisappear : MonoBehaviour
{
    public static int ingredientsFound = 0;
    public static int totalIngredients = 0;

    // Start is called before the first frame update
    void Start()
    {
        ingredientsFound = 0;
        totalIngredients++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IngredientClicked()
    {
        Debug.Log("Clicked!");
        ingredientsFound++;
        gameObject.SetActive(false);
    }
}
