using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject currentPage;
    [SerializeField] GameObject firstPage;
    [SerializeField] GameObject nextPage;

    // Open the tutorial.
    public void OpenGuide()
    {
        tutorialPanel.SetActive(true);
    }

    // Progress to next part of tutorial.
    public void NextGuidePage()
    {
        currentPage.SetActive(false);
        nextPage.SetActive(true);
    }

    // Close tutorial, reset pages
    public void CloseGuide()
    {
        currentPage.SetActive(false);
        firstPage.SetActive(true);
        tutorialPanel.SetActive(false);
    }
}
