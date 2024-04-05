using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskTracker : MonoBehaviour
{
    /* Used to track the player's progress through the assigned tasks. */

    [SerializeField] GameObject questPanel;
    [SerializeField] TextMeshProUGUI questText;
    [SerializeField] TextMeshProUGUI summaryText;

    int currQuest = 1;

    // Check player's progress when the game starts.
    private void Start()
    {
        switch (currQuest)
        {
            case 1:
                summaryText.text = "Quest 1";
                break;
            case 2:
                summaryText.text = "Quest 2";
                break;
            case 3:
                summaryText.text = "Quest 3";
                break;
            case 4:
                summaryText.text = "Quest 4";
                break;
            case 5:
                summaryText.text = "Quest 5";
                break;
            default:
                summaryText.text = "Something broke";
                break;
        }
    }

    // Open the quest details panel.
    public void OpenQuestDetails()
    {
        questPanel.SetActive(true);
        // Update the quest details text
        switch (currQuest)
        {
            case 1:
                questText.text = "Dear Cousin,\n\nThank you once again for tending the shop in my absence. " +
                    "Potion Mixteries may not be a booming business, but even a day or two away is bound to put me behind in orders.\n\n" +
                    "To help you get started, I recommend making yourself an intelligence potion to sharpen your mind. " +
                    "You will find the directions in the recipe book on the shelf. Consider it practice for your work.\n\n" +
                    "You should have all you need for this and other potions in the cabinets. " +
                    "However, you may not be able to use all of the ingredients until you gain a little more experience.\n\n" +
                    "Once you begin the work properly, remember that our customers may not know the proper names of the mixtures they need. " +
                    "Read their requests closely and use your good judgment to select the proper recipe.\n\n" +
                    "A final note: I'm afraid there was a spill on my recipe book the other night, so it may be impossible to read all of the ingredients. " +
                    "You're a quick study, so I have no doubt you will be able to puzzle your way through.\n\n" +
                    "Best of luck to you. Please do not burn down my shop.\n\nYour loving cousin,\nAlchamedes";
                break;
            case 2:
                questText.text = "Quest 2";
                break;
            case 3:
                questText.text = "Quest 3";
                break;
            case 4:
                questText.text = "Quest 4";
                break;
            case 5:
                questText.text = "Quest 5";
                break;
            default:
                questText.text = "Something broke";
                break;
        }
    }

    // Close the quest details panel.
    public void CloseQuestDetails()
    {
        questPanel.SetActive(false);
    }

    // Check the submitted potion and update accordingly
    /* Recipes are as follows:
     * Mind Sharpening: Ginseng, Morning Dew, Clear Quartz
     * Vigor & Wellness: Cloves, Ginseng, Beech Bark
     * Conman's Bane: Crow Feather, Absinthe, Dandelion Stem
     * Classic Love: Rose Buds, Puppy's Eyelash, Ladybug Wing
     * Eagle Eye: Clear Quartz, Black Cat Fur, Parchment
     * Mage Mix: Campfire Ash, Beech Bark, Nightshade
     * Elongating: Beeswax, Dandelion Stem, Ant Legs
     * Strengthening: Oak Root, Ginseng, Ant Legs
     * Youth Fount: Puppy's Eyelash, Ginseng, Beeswax
     * Still & Calm: Nightshade, Goldfish Scale, Jellyfish Venom*/
    public void CheckSubmission()
    {
        // If submission matches recipe, congratulate player, increment currQuest


        // Else, advise player the potion is incorrectly mixed

    }
}
