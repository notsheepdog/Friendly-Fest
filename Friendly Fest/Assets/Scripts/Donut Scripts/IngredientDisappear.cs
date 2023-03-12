using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisappear : MonoBehaviour
{
    public static int ingredientsFound = 0;
    public static int totalIngredients = 6;
    public static bool cabinet = false;
    public static bool sprinkles = true;
    public Button cab;
    public Button sprink;


    // Start is called before the first frame update
    void Start()
    {
        cabinet = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IngredientClicked()
    {
        ingredientsFound++;
        gameObject.SetActive(false);
    }

    public void CabinetClicked()
    {
        cab.gameObject.SetActive(!cabinet);
        if (!cabinet && sprinkles)
        {
            sprink.gameObject.SetActive(sprinkles);
        }
        else
        {
            sprink.gameObject.SetActive(false);
        }
        cabinet = !cabinet;
    }

    public void SprinklesClicked()
    {
        sprinkles = false;
        IngredientClicked();
    }
}
