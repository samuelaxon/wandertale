using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public TMP_Text roomText; // The TMP room text field.
    public Button accuseButton; // SLEUTH
    public Button mapButton; // SLEUTH
    public Button helpButton; // SLEUTH
    public Button quitButton; // SLEUTH
    public Button endRestartButton; // SLEUTH
    public Button endQuitButton; // SLEUTH

    public Canvas roomCanvas; // The UI for the room navigation mode.
    public Canvas storyCanvas; // The UI for the Ink story dialogue mode.
    public Canvas menuCanvas; // The UI for the menu.
    public Canvas endCanvas; // The UI for the kill screen.
    public string canvasState;
    public int gameHasStarted = 0; // Has the game started? 0 for no, 1 for yes.

    public bool testBool = false;

    [HideInInspector] public RoomNavigation roomNavigation; // A reference to roomNavigation for knowing which room we're in.
    [HideInInspector] public InkController inkController; // A reference to inkController so various scripts can communicate and work with Ink stories.
    [HideInInspector] public ObjectController objectController; // A reference to the ObjectController so various scripts can communicate and work with objects and prefabs.
    [HideInInspector] public VariableTracker variableTracker; // A reference to variable tracker so various scripts can access, use, and define the variables.
    [HideInInspector] public SFXController sfxController; // A reference to the script that plays and stops sound effects and music. Disabled for SLEUTH.

    List<string> roomLog = new List<string>(); // Creates a List of strings called room log that will go to the text field.

    // Called when the script is activated.
    private void Awake()
    {
        Debug.Log("GameController woke up.");
        roomNavigation = GetComponent<RoomNavigation>();
        inkController = GetComponent<InkController>();
        objectController = GetComponent<ObjectController>();
        variableTracker = GetComponent<VariableTracker>();
        sfxController = GetComponent<SFXController>();

        objectController.MasterRandomizer();
    }

    private void Update()
    {
        // Intended to start the game when the player clicks start or equivalent in the main menu.
        if (gameHasStarted == 0)
        {
            if (Input.anyKey)
            {
                Debug.Log("GameController/Update(): A key or mouse click has been detected.");
                gameHasStarted = 1;

                // SLEUTH: This is for going straight to the instructions screen.
                CanvasModeSwitch("story"); 
                inkController.LoadStory("StartGame");

                /* SLEUTH: Disabled because Sleuth starts with a story, not the room view.
                sfxController.PlaySFX();
                CanvasModeSwitch("room");
                */
            }
        }

        if (variableTracker.mapLocked.activeInHierarchy == true || variableTracker.mapUnlocked.activeInHierarchy == true)
        {
            if (Input.anyKey)
            {
                Debug.Log("GameController/Update(): Input was detected while the map was active, closing the map.");
                variableTracker.mapLocked.SetActive(false);
                variableTracker.mapUnlocked.SetActive(false);
            }
        }

        /* Ends the game if a story calls for it. Disabled temporarily because we moved it to InkController in SLEUTH.
        if (variableTracker.gameEnd == 1)
        {
            Debug.Log("GameController/Update(): Game ending because gameEnd == 1.");

            CanvasModeSwitch("end");
            // sfxController.StopSFX(); Disabled because we're not using this in this project yet.
        }*/
    }

    // Switches between Story and Room canvas with SetActive. Note for later: Make this into custom enum parameters instead of arbitrary string ones.
    public void CanvasModeSwitch(string canvasMode)
    {
        Debug.Log("GameController's CanvasModeSwitch was called.");
        if (canvasMode == "story")
        {
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as story.");
            canvasState = "story";
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }
        else if (canvasMode == "room")
        {
            canvasState = "room";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as room.");

            roomCanvas.gameObject.SetActive(true);
            storyCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(false);

            // SLEUTH: Tells buttons about the controller when they become active at this point.
            mapButton.GetComponent<ButtonController>().controller = this;
            accuseButton.GetComponent<ButtonController>().controller = this;
            quitButton.GetComponent<ButtonController>().controller = this;
            helpButton.GetComponent<ButtonController>().controller = this;
            endRestartButton.GetComponent<ButtonController>().controller = this;
            endQuitButton.GetComponent<ButtonController>().controller = this;

            ChangeRoom();
        }
        else if (canvasMode == "menu")
        {
            canvasState = "menu";
            menuCanvas.gameObject.SetActive(true);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
        }
        else if (canvasMode == "end")
        {
            canvasState = "end";
            endCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("GameController.CanvasModeSwitch(): No valid canvas mode was recognized.");
        }
    }

    // All the stuff that happens when we move to a new room.
    public void ChangeRoom()
    {
        Debug.Log("ChangeRoom was called.");

        roomLog.Clear();
        roomNavigation.mobOrStaticStoryDictionary.Clear(); // Added while testing new object refactor.
        roomNavigation.exitDictionary.Clear(); // Added while testing new object refactor.

        foreach (Transform child in roomNavigation.interactablesPanel.transform)
        {
            Destroy(child.gameObject);
        }

        roomText.text = null;

        UpdateRoomText();
        UnpackInteractables();
        DisplayLoggedText();
    }

    // Generates text to represent the room.
    public void UpdateRoomText()
    {
        Debug.Log("GameController's UpdateRoomText was called.");
        ClearCollectionsForNewRoom();
        Debug.Log("GameController/UpdateRoomText: The current room name is " + roomNavigation.currentRoom.name);

        // SLEUTH — These danger stange modifications are specific to this game. We should replace this method later with something more universal.
        if (variableTracker.playerDangerStage == variableTracker.priorDangerStage)
        {
            if (variableTracker.playerDangerStage == "low")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[0].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.playerDangerStage == "medium")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[1].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.playerDangerStage == "high")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[2].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.playerDangerStage == "critical" || variableTracker.playerDangerStage == "end")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[3].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
        }
        else
        {
            if (variableTracker.priorDangerStage == "low")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[0].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.priorDangerStage == "medium")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[1].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.priorDangerStage == "high")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[2].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
            else if (variableTracker.priorDangerStage == "critical" || variableTracker.playerDangerStage == "end")
            {
                string combinedRoomText = roomNavigation.currentRoom.roomStates[3].roomDescriptionByState + "\n";
                RoomLogReturn(combinedRoomText);
            }
        }

        // Sleuth: Disabled the normal approach below because it is replaced by the game-specific method above. Re-enable this if not making Sleuth.
        /*
        string combinedRoomText = roomNavigation.currentRoom.roomDescription + "\n";

        RoomLogReturn(combinedRoomText);*/
    }

    // Sets the text field's text value to match what was in our room log.
    public void DisplayLoggedText()
    {
        Debug.Log("GameController's DisplayLoggedText was called.");

        string logRoomAsText = string.Join("\n", roomLog.ToArray());

        // SLEUTH: Changes room text color based on danger level. This is Sleuth-specific, so remove later.
        if (variableTracker.playerDangerLevel >= variableTracker.dangerLevelTextThreshold)
        {
            Debug.Log("GameController/DisplayLoggedText(): playerDangerLevel was " + variableTracker.playerDangerLevel + " and dangerLevelTextThreshold was " + variableTracker.dangerLevelTextThreshold);

            int invertedDangerLevel = variableTracker.dangerEnd - variableTracker.playerDangerLevel;

            Debug.Log("GameController/DisplayLoggedText(): Set invertedDangerLevel to " + invertedDangerLevel);

            if (invertedDangerLevel >= 1)
            {
                int adjustedDangerLevel = invertedDangerLevel / 3;
                Debug.Log("GameController/DisplayLoggedText(): adjustedDangerLevel is " + adjustedDangerLevel + " from invertedDangerLevel " + invertedDangerLevel);

                byte invertedDangerLevelByte = (byte)adjustedDangerLevel;
                Debug.Log("GameController/DisplayLoggedText(): adjustedDangerLevel converted to byte with value " + adjustedDangerLevel);

                roomText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                Debug.Log("GameController/DisplayLoggedText(): invertedDangerLevel was >= 1 so set roomText.color to " + roomText.color);
            }
            else if (invertedDangerLevel <= 0)
            {
                roomText.color = new Color32(255, 0, 0, 255);
                Debug.Log("GameController/DisplayLoggedText(): invertedDangerLevel was 0 so set roomText.color to " + roomText.color);
            }
        }
        else
        {
            roomText.color = new Color32(255, 255, 255, 255);
            Debug.Log("GameController/DisplayLoggedText(): playerDangerLevel was " + variableTracker.playerDangerLevel + " and dangerLevelTextThreshold was " + variableTracker.dangerLevelTextThreshold + " so defaulted roomText.color to " + roomText.color);
        }

        roomText.text = logRoomAsText;
    }

    // Calls the UnpackExitsInRoom and UnpackMobsInRoom functions in RoomNavigation, which sends descriptions to this script.
    void UnpackInteractables()
    {
        Debug.Log("GameController's UnpackInteractables was called.");
        roomNavigation.UnpackExitsInRoom();
        roomNavigation.UnpackMobsInRoom();
        roomNavigation.UnpackStaticsInRoom();
    }

    // Clears everything from a room so we can go to a new one.
    void ClearCollectionsForNewRoom()
    {
        Debug.Log("GameController's ClearCollectionsForNewRoom was called.");
        roomNavigation.ClearExits();
    }

    // Adds whatever string you give it to the room log, to later be displayed in the text field by UpdateRoomText.
    public void RoomLogReturn(string roomDescriptionToAdd)
    {
        Debug.Log("GameController's RoomLogReturn was called.");
        roomLog.Add(roomDescriptionToAdd + "\n");
    }
}