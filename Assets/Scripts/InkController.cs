using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class InkController : MonoBehaviour
{
    // Ink variables
    [HideInInspector] public TextAsset inkJSON;

    public Story story;

    // UI variables
    public TMP_Text storyTextPrefab;
    public Button storyButtonPrefab;
    public GameObject storyBackgroundPrefab;
    public GameObject sceneCamera;
    private Camera sceneCameraComponent;
    public TMP_FontAsset storyChoiceFont;

    // Other variables
    public GameController controller;
    [HideInInspector] public bool isStoryLoaded = false;
    [HideInInspector] public int isStoryDone = 0;
    private string lastStoryLoaded;

    private void Awake()
    {
        Debug.Log("InkController woke up.");
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
        Debug.Log("InkController/LoadStory() was called.");

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
            Debug.Log("InkController/LoadStory(): No story found in relevant dictionaries, so no story was loaded.");
        }
    }

    // Unloads the story and updates universal variables based on the story when it ends.
    public void UnloadStory()
    {
        Debug.Log("InkController/UnloadStory() was called.");
        controller.variableTracker.UpdateVariablesFromStoryEnd();

        controller.variableTracker.UpdateFoundStatics(); // SLEUTH: If the player found the weapon, key, or body this conversation, adds them to a list of statics to exclude when displaying the room.

        // SLEUTH: Fades the music in and out at certain points in the game.
        if (lastStoryLoaded == "StartGame")
        {
            StartCoroutine(controller.sfxController.StartingFade());
        }
        else if (lastStoryLoaded == "EndGameAccuse")
        {
            StartCoroutine(controller.sfxController.EndingFade());
        }

        if (controller.variableTracker.gameEnd == 1)
        {
            Debug.Log("InkController/UnloadStory(): Game ending because gameEnd == 1.");

            controller.CanvasModeSwitch("end");
            // sfxController.StopSFX(); Disabled because we're not using this in this project yet.
        }
        else
        {
            controller.CanvasModeSwitch("room");
        }

        isStoryLoaded = false;
        story = null;
        EraseUI();
    }

    // Populates the text and button prefabs with concents from the Ink story. Also, handles clicking to make a choice in Ink stories.
    void RefreshUI()
    {
        Debug.Log("InkController's RefreshUI was called.");

        EraseUI();
        GameObject storyBackground = Instantiate(storyBackgroundPrefab);
        storyBackground.transform.SetParent(controller.storyCanvas.transform, false);
        /* Temporarily disabling this since there is no longer a video player here in Sleuth.
        VideoPlayer storyBackgroundVideo = storyBackground.GetComponent<VideoPlayer>();
        sceneCameraComponent = sceneCamera.GetComponent<Camera>();
        storyBackgroundVideo.targetCamera = sceneCameraComponent;
        storyBackgroundVideo.Play();
        */
        TMP_Text storyText = Instantiate(storyTextPrefab);
        storyText.text = LoadStoryChunk();
        storyText.transform.SetParent(controller.storyCanvas.transform, false);
        storyText.fontSize = 20;
        storyText.paragraphSpacing = 40;

        controller.variableTracker.CheckToPlayDiscoveryAudio(); // SLEUTH

        foreach (Choice choice in story.currentChoices)
        {
            Button storyButton = Instantiate(storyButtonPrefab);
            storyButton.transform.SetParent(controller.storyCanvas.transform, false);

            TMP_Text storyChoiceText = storyButton.GetComponentInChildren<TMP_Text>();
            storyChoiceText.font = storyChoiceFont;
            storyChoiceText.fontSize = 20;
            storyChoiceText.color = Color.white;
            storyChoiceText.text = choice.text;

            storyButton.onClick.AddListener(delegate
            {
                Debug.Log("A story choice was clicked.");
                ChooseStoryChoice(choice);
            });
        }
    }

    // Clears the UI so it can be replaced with an updated one when the story state changes.
    void EraseUI()
    {
        Debug.Log("InkController's EraseUI was called.");
        for (int i = 0; i < controller.storyCanvas.transform.childCount; i++)
        {
            Destroy(controller.storyCanvas.transform.GetChild(i).gameObject);
        }
    }

    // Moves the story forward after the user clicks on a choice (which is handled in refreshUI).
    void ChooseStoryChoice(Choice choice)
    {
        Debug.Log("InkController's ChooseStoryChoice was called.");
        story.ChooseChoiceIndex(choice.index);

        RefreshUI();
    }

    // Checks if there is more of the story to load, and if so, loads it and returns the text.
    string LoadStoryChunk()
    {
        Debug.Log("InkController's LoadStoryChunk was called.");
        string text = "";

        if(story.canContinue)
        {
            Debug.Log("InkController's LoadStoryChunk says the story can continue.");
            text = story.ContinueMaximally();
        }

        return text;
    }
}