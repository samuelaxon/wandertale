using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    [HideInInspector] public TextAsset currentRoomStory;
    [HideInInspector] public int currentMobState;

    [HideInInspector] public Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    [HideInInspector] public Dictionary<string, TextAsset> mobOrStaticStoryDictionary = new Dictionary<string, TextAsset>();

    public TMP_Text interactableTextPrefab;

    public TextAsset finalStory;

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
        Debug.Log("RoomNavigation.UnpackExitsInRoom() was called.");
        Debug.Log("RoomNavigation.UnpackExitsInRoom(): Current room is " + currentRoom);

        foreach (Exit e in currentRoom.exits)
        {
            Debug.Log("RoomNavigation.UnpackExitsInRoom(): Exit in room is " + e.name);
        }

        for (int i = 0; i < currentRoom.exits.Count; i++)
        {
            Debug.Log("RoomNavigation.UnpackExitsInRoom(): Processing exit " + currentRoom.exits[i].name + "in room " + currentRoom.name);

            TMP_Text interactableText = Instantiate(interactableTextPrefab);
            interactableText.name = currentRoom.exits[i].name + "InteractableText";
            interactableText.tag = "Exit Text";
            interactableText.transform.SetParent(controller.interactablesPanel.transform, false);
            interactableText.GetComponent<InteractableTextController>().controller = controller;
            interactableText.text = currentRoom.exits[i].exitDescription;

            exitDictionary.Add(interactableText.name, currentRoom.exits[i].valueRoom);
        }

        foreach (KeyValuePair<string, Room> kvp in exitDictionary)
        {
            Debug.Log("RoomNavigation.UnpackExitsInRoom(): exitDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
        }
    }

    // Sorts through the mobs assigned to a room in the editor, and creates interactable text objects to display on the screen to indicate their presence.
    public void UnpackMobsInRoom()
    {
        Debug.Log("RoomNavigation.UnpackMobsInRoom() was called.");
        Debug.Log("RoomNavigation.UnpackMobsInRoom(): Current room is " + currentRoom);

        foreach (Mob m in currentRoom.mobs)
        {
            Debug.Log("RoomNavigation.UnpackMobsInRoom(): Mob in room is " + m);
        }

        for (int i = 0; i < currentRoom.mobs.Count; i++) // Goes through each available mob story or mob and instantiates a clickable text object for it.
        {
            if (currentRoom.mobs[i].mobStories.Count != 0 && currentRoom.mobs[i].mobState != 3 && currentRoom.mobs[i].mobState != 5)
            {
                Debug.Log("RoomNavigation.UnpackMobsInRoom(): Processing mob " + currentRoom.mobs[i].mobName + " and its mobStories.Count is greater than 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the mob story description.

                if (currentRoom.mobs[i].mobName == "Mnemosyne")
                {
                    interactableText.name = "MnemosyneInteractableText"; // Renames this text object so it is identifiable as associated with this mob.
                }
                else
                {
                    interactableText.name = currentRoom.mobs[i].mobStories[currentRoom.mobs[i].mobState].valueStory.name; // Renames this text object so it is identifiable as associated with this mob.
                }
                
                interactableText.tag = "Mob Text";
                interactableText.transform.SetParent(controller.interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = true; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                if (currentRoom.mobs[i].mobName == "Mnemosyne")
                {
                    interactableText.text = "Go to the lobby";
                }
                else
                {
                    interactableText.text = currentRoom.mobs[i].mobStories[currentRoom.mobs[i].mobState].dialogueDescription; // Sets the text's contents to be equal to the relevant mob description.
                }

                if (currentRoom.mobs[i].mobName == "Mnemosyne")
                {
                    mobOrStaticStoryDictionary.Add(interactableText.name, finalStory); // Stores this text object as the key and the associated mob story as a value.
                }
                else
                {
                    mobOrStaticStoryDictionary.Add(interactableText.name, currentRoom.mobs[i].mobStories[currentRoom.mobs[i].mobState].valueStory); // Stores this text object as the key and the associated mob story as a value.
                }

                Debug.Log("RoomNavigation.UnpackMobsInRoom(): A new text object has been instantiated from " + currentRoom.mobs[i].name + " for mobState " + currentRoom.mobs[i].mobState + " and it's named " + interactableText.name);
            }
            else
            {
                Debug.Log("RoomNavigation.UnpackMobsInRoom(): Processing mob " + currentRoom.mobs[i].mobName + " and its mobStories.Count is 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the mob description.
                interactableText.name = currentRoom.mobs[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this mob.
                interactableText.tag = "Mob Text";
                interactableText.transform.SetParent(controller.interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = false; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.


                interactableText.text = currentRoom.mobs[i].mobDescription; // Sets the text's contents to be equal to the relevant mob description.

                Debug.Log("RoomNavigation.UnpackMobsInRoom(): A new text object has been instantiated from " + currentRoom.mobs[i].name + " for no mobState and it's named " + interactableText.name);
            }
        }

        /*
        if (mobOrStaticStoryDictionary.Count > 0)
        {
            foreach (KeyValuePair<string, TextAsset> kvp in mobOrStaticStoryDictionary)
            {
                Debug.Log("RoomNavigation.UnpackMobsInRoom(): mobOrStaticStoryDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
            }
        }*/
    }

    // Sorts through the statics assigned to a room in the editor, and creates interactable text objects to display on the screen to indicate their presence.
    public void UnpackStaticsInRoom()
    {
        Debug.Log("RoomNavigation.UnpackStaticsInRoom() was called.");
        Debug.Log("RoomNavigation.UnpackStaticsInRoom(): Current room is " + currentRoom);

        foreach (Static s in currentRoom.statics)
        {
            Debug.Log("RoomNavigation.UnpackStaticsInRoom(): Static in room is " + s);
        }

        controller.inventory.RemoveFoundStaticsFromRoom(); // When the player has picked up an item, removes it from the room once found.

        for (int i = 0; i < currentRoom.statics.Count; i++)
        {
            if (currentRoom.statics[i].staticStories.Count != 0)
            {
                Debug.Log("RoomNavigation.UnpackStaticsInRoom(): Processing static " + currentRoom.statics[i].staticName + " and its staticStories.Count is greater than 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the static story description.
                interactableText.name = currentRoom.statics[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this static.
                interactableText.tag = "Static Text";
                interactableText.transform.SetParent(controller.interactablesPanel.transform, false); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = true; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                interactableText.text = currentRoom.statics[i].staticStories[currentRoom.statics[i].staticState].dialogueDescription; // Sets the text's contents to be equal to the relevant static description.
                mobOrStaticStoryDictionary.Add(interactableText.name, currentRoom.statics[i].staticStories[currentRoom.statics[i].staticState].valueStory); // Stores this text object as the key and the associated static story as a value.

                Debug.Log("RoomNavigation.UnpackStaticssInRoom(): A new text object has been instantiated from " + currentRoom.statics[i].name + " for staticState " + currentRoom.statics[i].staticState + " and it's named " + interactableText.name);
            }
            else
            {
                Debug.Log("RoomNavigation.UnpackStaticsInRoom(): Processing static " + currentRoom.statics[i].staticName + " and its staticStories.Count is 0.");

                TMP_Text interactableText = Instantiate(interactableTextPrefab); // Creates a text object to correspond to the static story description.
                interactableText.name = currentRoom.statics[i].name + "InteractableText"; // Renames this text object so it is identifiable as associated with this static.
                interactableText.tag = "Static Text";
                interactableText.transform.SetParent(controller.interactablesPanel.transform); // Sets the panel as a parent so these UI elements are automatically sorted properly in the viewport.
                interactableText.GetComponent<InteractableTextController>().controller = controller; // Tells the new text object how to find the GameController.
                interactableText.GetComponent<InteractableTextController>().hasStory = false; // Sets the variable for whether this object a story to load so InteractableTextController knows whether to load one on click.

                interactableText.text = currentRoom.statics[i].staticDescription; // Sets the text's contents to be equal to the relevant static description.
            }

            foreach (KeyValuePair<string, TextAsset> kvp in mobOrStaticStoryDictionary)
            {
                Debug.Log("RoomNavigation.UnpackStaticsInRoom(): mobOrStaticStoryDictionary includes key " + kvp.Key + " and value " + kvp.Value.name);
            }
        }
    }

    // Takes a key (likely from link text) to pick an exit and move to another room.
    public void AttemptToChangeRooms(string exitChoice)
    {
        Debug.Log("RoomNavigation.AttemptToChangeRooms() was called with key " + exitChoice);
        if (exitDictionary.ContainsKey(exitChoice))
        {
            Debug.Log("RoomNavigation.AttemptToChangeRooms(): Exit dictionary contained this key.");
            Debug.Log("RoomNavigation.AttemptToChangeRooms(): Will change rooms because exit was not locked.");

            controller.StopFade();
            currentRoom = exitDictionary[exitChoice];
            controller.ChangeRoom();

            Debug.Log("RoomNavigation.AttemptToChangeRooms(): Current room is: " + currentRoom);
        }
        else
        {
            Debug.Log("RoomNavigation.AttemptToChangeRooms(): There was no value for this exit key.");
        }
    }

    // Removes exits from the exit dictionary so they can be replaced.
    public void ClearExits()
    {
        Debug.Log("RoomNavigation.ClearExits() was called.");
        exitDictionary.Clear();
    }
}