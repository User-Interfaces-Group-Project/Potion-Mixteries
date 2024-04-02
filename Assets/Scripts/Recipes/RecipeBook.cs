using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] GameObject bookPanel;
    [SerializeField] GameObject currentPage;
    [SerializeField] GameObject nextPage;
    [SerializeField] GameObject priorPage;
    
    // Open the recipe book panel. Pages are controlled in another method, which allows
    // player to keep their place when closing and re-opening the book.
    public void OpenRecipeBook()
    {
        bookPanel.SetActive(true);
    }

    // Close the recipe book panel.
    public void CloseRecipeBook()
    {
        bookPanel.SetActive(false);
    }

    // Close the current page and open the next page.
    public void TurnPage()
    {
        nextPage.SetActive(true);
        currentPage.SetActive(false);
    }

    // Close the current page and open the prior page.
    public void BackPage()
    {
        priorPage.SetActive(true);
        currentPage.SetActive(false);
    }
}
