using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    [HideInInspector] public TextAsset currentRoomStory;
    [HideInInspector] public int currentMobState;

    [HideInInspector] public Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    [HideInInspector] public Dictionary<string, bool> exitStatusTable = new Dictionary<string, bool>();
    [HideInInspector] public Dictionary<string, TextAsset> mobOrStaticStoryDictionary = new Dictionary<string, TextAsset>();

    public GameObject interactablesPanel;
    public TMP_Text interactableTextPrefab;

    GameController controller; // A reference to the game controller.

    // Called when the application starts.
    void Awake()
    {
        Debug.Log("RoomNavigation woke up.");
        controller = GetComponent<GameController>(); // Allows this script to access things from the GameController.
    }

    // Goes through each exit in the room, adds it to the exitDictionary, and sends its description to exitDescriptionsInRoom in GameController.
    public void UnpackExitsInRoom()
    {
        Debug.Log("RoomNavigation's UnpackExitsInRoom was called.");
        Debug.Log("RoomNavigation/UnpackExitsInRoom(): Current room is " + currentRoom);

        foreach (Exit e in currentRoom.exits)
        {
            Debug.Log("RoomNavigation/UnpackExitsInRoom(): Exit in room is " + e.name);
        }

        for (int i = 0; i < currentRoom.exits.Count; i++)
        {
            Debug.Log("RoomNavigation/UnpackExitsInRoom(): Processing exit " + currentRoom.exits[i].name + "in room " + currentRoom.name);

            TMP_Text interactableText = Instantiate(interactableTextPrefab);
            interactableText.name = currentRoom.exits[i].name + "InteractableText";
            interactableText.tag = "Exit Text";
            interactableText.transform.SetParent(interactablesPanel.transform, false);
            interactableText.GetComponent<InteractableTextController>().controller = controller;

            // SLEUTH: Changes interactable text color based on danger level. This is Sleuth-specific, so remove later.
            if (controller.variableTracker.playerDangerLevel >= controller.variableTracker.dangerLevelTextThreshold)
            {
                int invertedDangerLevel = controller.variableTracker.dangerEnd - controller.variableTracker.playerDangerLevel;

                if (invertedDangerLevel >= 1)
                {
                    int adjustedDangerLevel = invertedDangerLevel / 3;

                    byte invertedDangerLevelByte = (byte)adjustedDangerLevel;

                    interactableText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                }
                else if (invertedDangerLevel <= 0)
                {
                    interactableText.color = new Color32(255, 0, 0, 255);
                }
            }
            else
            {
                interactableText.color = new Color32(255, 255, 255, 255);
            }

            // The below if statements check if the exit is open or closed, and logs the appropriate description.
            if (currentRoom.exits[i].exitIsClosed == false)
            {
                Debug.Log("RoomNavigation/UnpackExitsInRoom(): Exit " + currentRoom.exits[i].name + " was determined open with exitIsClosed bool value " + currentRoom.exits[i].exitIsClosed);
                interactableText.text = currentRoom.exits[i].exitDescriptionOpen;
            }
            else if (currentRoom.exits[i].exitIsClosed == true)
            {
                if (controller.variableTracker.playerFoundKey == 1)
                {
                    currentRoom.exits[i].exitIsClosed = false;
                    Debug.Log("RoomNavigation/UnpackExitsInRoom(): Player found key, so exit " + currentRoom.exits[i].name + " was determined open with exitIsClosed bool value " + currentRoom.exits[i].exitIsClosed);
                    interactableText.text = currentRoom.exits[i].exitDescriptionOpen;
                }
                else
                {
                    Debug.Log("RoomNavigation/UnpackExitsInRoom(): Exit " + currentRoom.exits[i].name + " was determined closed with exitIsCClosed bool value " + currentRoom.exits[i].exitIsClosed);
                    interactableText.text = currentRoom.exits[i].exitDescriptionClosed;
                }
            }

            exitDictionary.Add(interactableText.name, currentRoom.exits[i].valueRoom);
            exitStatusTable.Add(interactableText.name, currentRoom.exits[i].exitIsClosed);
        }

        foreach (KeyValuePair<string, Room> kvp in exitDictionary)
        {
            Debug.Log("RoomNavigation/UnpackExitsInRoom(): exitDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
        }
    }

    // Sorts through the mobs assigned to a room in the editor, and creates interactable text objects to display on the screen to indicate their presence.
    public void UnpackMobsInRoom()
    {
        Debug.Log("RoomNavigation's UnpackMobsInRoom was called.");
        Debug.Log("RoomNavigation/UnpackMobsInRoom(): Current room is " + currentRoom);

        foreach (Mob m in currentRoom.mobs)
        {
            Debug.Log("RoomNavigation/UnpackMobsInRoom(): Mob in room is " + m);
        }

        for (int i = 0; i < currentRoom.mobs.Count; i++) // Goes through each available mob story or mob and instantiates a clickable text object for it.
        {
            if (currentRoom.mobs[i].mobStories.Count != 0)
            {
                Debug.Log("RoomNavigation/UnpackMobsInRoom(): Processing mob " + currentRoom.mobs[i].mobName + " and its mobStories.Count is greater than 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the mob story description.
                interactableText.name = currentRoom.mobs[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this mob.
                interactableText.tag = "Mob Text";
                interactableText.transform.SetParent(interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = true; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                // SLEUTH: Changes interactable text color based on danger level. This is Sleuth-specific, so remove later.
                if (controller.variableTracker.playerDangerLevel >= controller.variableTracker.dangerLevelTextThreshold)
                {
                    int invertedDangerLevel = controller.variableTracker.dangerEnd - controller.variableTracker.playerDangerLevel;

                    if (invertedDangerLevel >= 1)
                    {
                        int adjustedDangerLevel = invertedDangerLevel / 3;

                        byte invertedDangerLevelByte = (byte)adjustedDangerLevel;

                        interactableText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                    }
                    else if (invertedDangerLevel <= 0)
                    {
                        interactableText.color = new Color32(255, 0, 0, 255);
                    }
                }
                else
                {
                    interactableText.color = new Color32(255, 255, 255, 255);
                }

                interactableText.text = currentRoom.mobs[i].mobStories[currentRoom.mobs[i].mobState].dialogueDescription; // Sets the text's contents to be equal to the relevant mob description.
                mobOrStaticStoryDictionary.Add(interactableText.name, currentRoom.mobs[i].mobStories[currentRoom.mobs[i].mobState].valueStory); // Stores this text object as the key and the associated mob story as a value.

                Debug.Log("RoomNavigation/UnpackMobsInRoom(): A new text object has been instantiated from " + currentRoom.mobs[i].name + " for mobState " + currentRoom.mobs[i].mobState + " and it's named " + interactableText.name);
            }
            else
            {
                Debug.Log("RoomNavigation/UnpackMobsInRoom(): Processing mob " + currentRoom.mobs[i].mobName + " and its mobStories.Count is 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the mob description.
                interactableText.name = currentRoom.mobs[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this mob.
                interactableText.tag = "Mob Text";
                interactableText.transform.SetParent(interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = false; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                // SLEUTH: Changes interactable text color based on danger level. This is Sleuth-specific, so remove later.
                if (controller.variableTracker.playerDangerLevel >= controller.variableTracker.dangerLevelTextThreshold)
                {
                    int invertedDangerLevel = controller.variableTracker.dangerEnd - controller.variableTracker.playerDangerLevel;

                    if (invertedDangerLevel >= 1)
                    {
                        int adjustedDangerLevel = invertedDangerLevel / 3;

                        byte invertedDangerLevelByte = (byte)adjustedDangerLevel;

                        interactableText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                    }
                    else if (invertedDangerLevel <= 0)
                    {
                        interactableText.color = new Color32(255, 0, 0, 255);
                    }
                }
                else
                {
                    interactableText.color = new Color32(255, 255, 255, 255);
                }

                interactableText.text = currentRoom.mobs[i].mobDescription; // Sets the text's contents to be equal to the relevant mob description.

                Debug.Log("RoomNavigation/UnpackMobsInRoom(): A new text object has been instantiated from " + currentRoom.mobs[i].name + " for no mobState and it's named " + interactableText.name);
            }
        }

        foreach (KeyValuePair<string, TextAsset> kvp in mobOrStaticStoryDictionary)
        {
            Debug.Log("RoomNavigation/UnpackMobsInRoom(): mobOrStaticStoryDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
        }
    }

    // Sorts through the statics assigned to a room in the editor, and creates interactable text objects to display on the screen to indicate their presence.
    public void UnpackStaticsInRoom()
    {
        Debug.Log("RoomNavigation's UnpackStaticsInRoom was called.");
        Debug.Log("RoomNavigation/UnpackStaticsInRoom(): Current room is " + currentRoom);

        foreach (Static s in currentRoom.statics)
        {
            Debug.Log("RoomNavigation/UnpackStaticsInRoom(): Static in room is " + s);
        }

        controller.variableTracker.RemoveFoundStaticsFromRoom(); // SLEUTH: Removes key, murder weapon, or hiding place from room once found.

        for (int i = 0; i < currentRoom.statics.Count; i++)
        {
            if (currentRoom.statics[i].staticStories.Count != 0)
            {
                Debug.Log("RoomNavigation/UnpackStaticsInRoom(): Processing static " + currentRoom.statics[i].staticName + " and its staticStories.Count is greater than 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the static story description.
                interactableText.name = currentRoom.statics[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this static.
                interactableText.tag = "Static Text";
                interactableText.transform.SetParent(interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = true; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                // SLEUTH: Changes interactable text color based on danger level. This is Sleuth-specific, so remove later.
                if (controller.variableTracker.playerDangerLevel >= controller.variableTracker.dangerLevelTextThreshold)
                {
                    int invertedDangerLevel = controller.variableTracker.dangerEnd - controller.variableTracker.playerDangerLevel;

                    if (invertedDangerLevel >= 1)
                    {
                        int adjustedDangerLevel = invertedDangerLevel / 3;

                        byte invertedDangerLevelByte = (byte)adjustedDangerLevel;

                        interactableText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                    }
                    else if (invertedDangerLevel <= 0)
                    {
                        interactableText.color = new Color32(255, 0, 0, 255);
                    }
                }
                else
                {
                    interactableText.color = new Color32(255, 255, 255, 255);
                }

                interactableText.text = currentRoom.statics[i].staticStories[currentRoom.statics[i].staticState].dialogueDescription; // Sets the text's contents to be equal to the relevant static description.
                mobOrStaticStoryDictionary.Add(interactableText.name, currentRoom.statics[i].staticStories[currentRoom.statics[i].staticState].valueStory); // Stores this text object as the key and the associated static story as a value.

                Debug.Log("RoomNavigation/UnpackStaticssInRoom(): A new text object has been instantiated from " + currentRoom.statics[i].name + " for staticState " + currentRoom.statics[i].staticState + " and it's named " + interactableText.name);
            }
            else
            {
                Debug.Log("RoomNavigation/UnpackStaticsInRoom(): Processing static " + currentRoom.statics[i].staticName + " and its staticStories.Count is 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the static story description.
                interactableText.name = currentRoom.statics[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this static.
                interactableText.tag = "Static Text";
                interactableText.transform.SetParent(interactablesPanel.transform); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = false; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                // SLEUTH: Changes interactable text color based on danger level. This is Sleuth-specific, so remove later.
                if (controller.variableTracker.playerDangerLevel >= controller.variableTracker.dangerLevelTextThreshold)
                {
                    int invertedDangerLevel = controller.variableTracker.dangerEnd - controller.variableTracker.playerDangerLevel;

                    if (invertedDangerLevel >= 1)
                    {
                        int adjustedDangerLevel = invertedDangerLevel / 3;

                        byte invertedDangerLevelByte = (byte)adjustedDangerLevel;

                        interactableText.color = new Color32(255, invertedDangerLevelByte, invertedDangerLevelByte, 255);
                    }
                    else if (invertedDangerLevel <= 0)
                    {
                        interactableText.color = new Color32(255, 0, 0, 255);
                    }
                }
                else
                {
                    interactableText.color = new Color32(255, 255, 255, 255);
                }

                interactableText.text = currentRoom.statics[i].staticDescription; // Sets the text's contents to be equal to the relevant static description.
            }

            foreach (KeyValuePair<string, TextAsset> kvp in mobOrStaticStoryDictionary)
            {
                Debug.Log("RoomNavigation/UnpackStaticsInRoom(): mobOrStaticStoryDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
            }
        }
    }

    // Takes a key (likely from link text) to pick an exit and move to another room.
    public void AttemptToChangeRooms(string exitChoice)
    {
        Debug.Log("RoomNavigation/AttemptToChangeRooms() was called with key " + exitChoice);
        if (exitDictionary.ContainsKey(exitChoice))
        {
            if (exitStatusTable[exitChoice] == true)
            {
                Debug.Log("Exit dictionary contained this key.");
                Debug.Log("RoomNavigation/AttemptToChangeRooms(): Exit to room " + exitChoice + " lock status was " + exitStatusTable[exitChoice]);
                Debug.Log("RoomNavigation/AttemptToChangeRooms(): Did not change rooms because exit was locked.");
            }
            else
            {
                Debug.Log("Exit dictionary contained this key.");
                Debug.Log("RoomNavigation/AttemptToChangeRooms(): Exit to room " + exitChoice + " lock status was " + exitStatusTable[exitChoice]);
                Debug.Log("RoomNavigation/AttemptToChangeRooms(): Will change rooms because exit was not locked.");

                currentRoom = exitDictionary[exitChoice];
                controller.ChangeRoom();

                Debug.Log("Current room is: " + currentRoom);

                // Sleuth; this is specific to this game ,remove for future games.
                if (currentRoom.name == "HiddenHallway")
                {
                    controller.variableTracker.playerVisitedHiddenHallway = 1;
                }
                else if (currentRoom.name == "Distillery")
                {
                    controller.variableTracker.playerVisitedDistillery = 1;
                }

                controller.variableTracker.UpdateDangerLevel("exit"); // Sleuth; this is specific to this game ,remove for future games.
                controller.variableTracker.UpdateDangerLevel("check"); // Sleuth; this is specific to this game ,remove for future games.
            }
        }
        else
        {
            Debug.Log("RoomNavigation/AttemptToChangeRooms(): There was no value for this exit key.");
        }
    }

    // Removes exits from the exit dictionary so they can be replaced.
    public void ClearExits()
    {
        Debug.Log("RoomNavigation's ClearExits was called.");
        exitDictionary.Clear();
        exitStatusTable.Clear();
    }
}