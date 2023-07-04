using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class VariableTracker : MonoBehaviour
{
    // Scripts
    public GameController controller;

    // Ink story variables
    public int storyEnd = 0;
    public int gameEnd = 0;

    // Mobs

    public Mob bob;

    public List<TextAsset> masterStoryList = new List<TextAsset>();
    [HideInInspector] public Dictionary<string, TextAsset> masterStoryDictionary = new Dictionary<string, TextAsset>();

    private void Awake()
    {
        AddToMasterStoryList();
    }

    // Adds universal stories (not room or mob/item specific) to a dictionary for reference by various functions—this is used for game over, accuse, and help.
    private void AddToMasterStoryList()
    {
        Debug.Log("VariableTracker/AddToMasterStoryList() was called.");

        for (int storyToAdd = 0; storyToAdd < masterStoryList.Count; storyToAdd++)
        {
            Debug.Log("VariableTracker/AddToMasterStoryList(): Adding story " + masterStoryList[storyToAdd].name + " to master story list.");

            masterStoryDictionary.Add(masterStoryList[storyToAdd].name, masterStoryList[storyToAdd]);
        }
    }


    // Records variables from a story as it ends, so they can be remembered for use in another story.
    public void UpdateVariablesFromStoryEnd()
    {
        Debug.Log("VariableTracker/UpdateVariablesFromStoryEnd() was called.");

        // Mob states
        bob.mobState = (int)controller.inkController.story.variablesState["bobConversationLevel"];

        // Game states
        storyEnd = (int)controller.inkController.story.variablesState["storyEnd"];
        gameEnd = (int)controller.inkController.story.variablesState["gameEnd"];
    }

    // Tells a new story all the variables it needs to know as soon as it's launched.
    public void SendNewVariablesToStory()
    {
        Debug.Log("VariableTracker/SendNewVariablesToStory() was called.");

        // Mob states
        controller.inkController.story.variablesState["bobConversationLevel"] = bob.mobState;
    }
}