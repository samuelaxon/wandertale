using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

public class InkController : MonoBehaviour
{
    // Ink variables
    [HideInInspector] public TextAsset inkJSON;

    public Story story;
    public GameObject sceneCamera;
    public GameController controller;
    [HideInInspector] public bool isStoryLoaded = false;
    [HideInInspector] public int isStoryDone = 0;
    public string lastStoryLoaded;

    // UI
    public TMP_Text storyTextPrefab;
    public Button storyChoicePrefab;
    public GameObject storyTextPanel;
    public GameObject storyChoicePanel;
    public TMP_FontAsset storyChoiceFont;

    private void Awake()
    {
        Debug.Log("InkController.Awake(): InkController woke up.");
        controller = GetComponent<GameController>();
    }

    void Start()
    {
        story = null;
    }

    // We're using the Update function to check if a story is active. The moment a variable in the story changes to say it's over, we run the UnloadStory function.
    private void Update()
    {
        if (isStoryLoaded == true)
        {
            isStoryDone = (int)story.variablesState["storyEnd"];
            if (isStoryDone == 1)
            {
                Debug.Log("The story is done, calling CanvasModeSwitch from InkController/Update.");
                UnloadStory();
            }
        }
    }

    // Loads a new Ink story when called.
    public void LoadStory(string storyKeyToLoad)
    {
        Debug.Log("InkController.LoadStory() was called.");

        if (controller.roomNavigation.mobOrStaticStoryDictionary.ContainsKey(storyKeyToLoad))
        {
            inkJSON = controller.roomNavigation.mobOrStaticStoryDictionary[storyKeyToLoad];
            story = new Story(inkJSON.text);
            controller.variableTracker.SendNewVariablesToStory();
            isStoryLoaded = true;
            lastStoryLoaded = storyKeyToLoad;
            RefreshUI();
        }
        else if (controller.variableTracker.masterStoryDictionary.ContainsKey(storyKeyToLoad))
        {
            inkJSON = controller.variableTracker.masterStoryDictionary[storyKeyToLoad];
            story = new Story(inkJSON.text);
            controller.variableTracker.SendNewVariablesToStory();
            isStoryLoaded = true;
            lastStoryLoaded = storyKeyToLoad;
            RefreshUI();
        }
        else
        {
            Debug.Log("InkController.LoadStory(): No story found in relevant dictionaries, so no story was loaded.");
        }
    }

    // Unloads the story and updates universal variables based on the story when it ends.
    public void UnloadStory()
    {
        Debug.Log("InkController.UnloadStory() was called.");
        controller.variableTracker.UpdateVariablesFromStoryEnd();

        EraseUI();

        // Fades the music in and out at certain points in the game. Should probably move this to a function in SFXController.
        if (lastStoryLoaded == "StartGame")
        {
            // StartCoroutine(controller.sfxController.StartingFade());
        }

        if (controller.variableTracker.gameEnd == 1)
        {
            Debug.Log("InkController.UnloadStory(): Game ending because gameEnd == 1.");
            controller.CanvasModeSwitch("end");
        }
        else
        {
            controller.CanvasModeSwitch("room");
        }

        isStoryLoaded = false;
        story = null;
    }

    // Populates the text and button prefabs with concents from the Ink story. Also, handles clicking to make a choice in Ink stories.
    public void RefreshUI()
    {
        Debug.Log("InkController.RefreshUI() was called.");

        EraseUI();

        TMP_Text storyText = Instantiate(storyTextPrefab);
        storyText.text = LoadStoryChunk();
        storyText.fontSize = 24;
        storyText.paragraphSpacing = 40;
        storyText.transform.SetParent(storyTextPanel.transform, false);

        foreach (Choice choice in story.currentChoices)
        {
            Button storyButton = Instantiate(storyChoicePrefab);

            Image storyButtonImage;
            storyButtonImage = storyButton.GetComponent<Image>();

            TMP_Text storyChoiceText = storyButton.GetComponentInChildren<TMP_Text>();
            storyChoiceText.transform.SetParent(storyButton.transform, false);
            storyChoiceText.font = storyChoiceFont;
            storyChoiceText.fontSize = 30;
            storyChoiceText.color = new Color32(13, 94, 175, 255);
            storyChoiceText.text = choice.text;
            storyButton.transform.SetParent(storyChoicePanel.transform, false);
            storyButtonImage.enabled = !storyButtonImage.enabled;

            storyButton.onClick.AddListener(delegate
            {
                Debug.Log("A story choice was clicked with value " + choice);
                ChooseStoryChoice(choice);
            });
        }

        controller.inventory.CollectStatic();
    }

    // Clears the UI so it can be replaced with an updated one when the story state changes.
    void EraseUI()
    {
        Debug.Log("InkController.EraseUI() was called.");

        for (int i = 0; i < storyTextPanel.transform.childCount; i++)
        {
            Destroy(storyTextPanel.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < storyChoicePanel.transform.childCount; i++)
        {
            Destroy(storyChoicePanel.transform.GetChild(i).gameObject);
        }
    }

    // Moves the story forward after the user clicks on a choice (which is handled in refreshUI).
    void ChooseStoryChoice(Choice choice)
    {
        Debug.Log("InkController.ChooseStoryChoice() was called.");
        story.ChooseChoiceIndex(choice.index);
        RefreshUI();
    }

    // Checks if there is more of the story to load, and if so, loads it and returns the text.
    string LoadStoryChunk()
    {
        Debug.Log("InkController.LoadStoryChunk() was called.");
        string text = "";

        if(story.canContinue)
        {
            Debug.Log("InkController.LoadStoryChunk(): The story can continue.");
            text = story.ContinueMaximally();
        }

        return text;
    }
}