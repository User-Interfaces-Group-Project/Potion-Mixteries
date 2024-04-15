using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskTracker : MonoBehaviour
{
    /* Used to track the player's progress through the assigned tasks. */

    [SerializeField] GameObject alertPanel;
    [SerializeField] GameObject questPanel;
    [SerializeField] TextMeshProUGUI alertText;
    [SerializeField] TextMeshProUGUI questText;
    [SerializeField] TextMeshProUGUI summaryText;
    [SerializeField] GameObject check1;
    [SerializeField] GameObject check2;
    [SerializeField] GameObject check3;
    [SerializeField] GameObject check4;
    [SerializeField] GameObject check5;

    int currQuest = 1;

    // Check player's progress when the game starts.
    private void Start()
    {
        SwitchQuest();
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
                questText.text = "Dear Potion Maker,\n\n" +
                    "My name is Lily and I am ten years old. I am writing to you because there are many children in the village who are mean to me. " +
                    "They pick on me and throw things at me. I want to teach them a lesson. If they think I am a witch, " +
                    "they will not be mean to me! Please help me get witch powers.\n\nSincerely,\nLily";
                break;
            case 3:
                questText.text = "Good Potion Maker,\n\n" +
                    "This is a terribly embarrassing letter to write, but you are my last hope in this situation. My husband and I have " +
                    "been married forty years, and it has been at least ten since I have felt that spark every person in love talks about. " +
                    "I understand you have a mixture which may help me feel like a young girl in love again. Please send it as soon as you can.\n\n" +
                    "With thanks,\nMarian";
                break;
            case 4:
                questText.text = "To: The Potion Maker\n\n" +
                    "I am an investigator charged with solving the murder of a young man in the south. It has been weeks since I began the assignment, " +
                    "and I am no closer to finding the killer. There must be something I cannot see. Do you have any elixirs which might be useful in clarifying my vision?\n\n" +
                    "From: Maxwell";
                break;
            case 5:
                questText.text = "Good morning Potion Maker,\n\n" +
                    "While it is true my son is the brightest light in my life, he is also the most exhausting part of it. Many warned me it would be difficult to " +
                    "have a young boy at my age, but I suppose I assumed I would gain a sort of fatherly vigor. I did not realize it would be the vigor of Father Time. " +
                    "I have been told you know a way to help a man in my position, and I hope it is not too good to be true.\n\n" +
                    "Thank you in advance,\nFather Tired";
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

    // Open the alert notification
    public void OpenAlert(string alertMessage)
    {
        alertPanel.SetActive(true);
        alertText.text = alertMessage;
    }

    // Close the alert notification
    public void CloseAlert()
    {
        alertPanel.SetActive(false);
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
        // If submission matches recipe, congratulate player, increment currQuest, SwitchQuest
        // OpenAlert("Well done! The customer has paid you for your hard work.");

        // Else, advise player the potion is incorrectly mixed
        // OpenAlert("Something isn't right. Check your recipe book and try another combination.");

    }

    /* Update the current quest information. */
    public void SwitchQuest()
    {
        switch (currQuest)
        {
            case 1:
                summaryText.text = "Getting Started";
                break;
            case 2:
                summaryText.text += "\nMake a Witch";
                break;
            case 3:
                summaryText.text += "\nRekindle a Spark";
                break;
            case 4:
                summaryText.text += "\nFind a Clue";
                break;
            case 5:
                summaryText.text += "\nEnergize a Father";
                break;
            default:
                summaryText.text = "Oh, no.";
                break;
        }
    }
}
