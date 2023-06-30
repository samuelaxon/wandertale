using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public GameController controller;

    public List<string> inventory = new List<string>();
    public TMP_Text inventoryText;
    [HideInInspector] public string objectToAdd;
    [TextArea] public string inventoryStartingText;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackInventory()
    {
        if (inventory.Count < 1)
        {
            Debug.Log("Inventory.UnpackInventory(): Inventory is empty, so adding the word nothing to the string.");

            inventoryText.text = inventoryStartingText;
            inventoryText.text = inventoryText.text + "\n" + "nothing";
        }
        else
        {
            Debug.Log("Inventory.UnpackInventory(): Inventory is not empty, so adding items to string.");
            
            inventoryText.text = inventoryStartingText;
            string baseText = inventoryText.text;
            string lastText = baseText;

            for (int i = 0; i < inventory.Count; i++)
            {
                if (!inventoryText.text.Contains(inventory[i]))
                {
                    Debug.Log("Inventory.UnpackInventory(): Adding inventory item " + inventory[i] + " to inventory text.");

                    string newText = lastText + "\n" + inventory[i];

                    lastText = newText;
                }
                else
                {
                    Debug.Log("Inventory.UnpackInventory(): Inventory text already contained the item " + inventory[i] + " so this item was skipped.");
                }
            }

            Debug.Log("Inventory.UnpackInventory(): Finished adding inventory items to inventory text.");

            inventoryText.text = lastText;
        }
    }

    // Adds any Static the player just picked up to the inventory.
    public void CollectStatic()
    {
        Debug.Log("Inventory.CollectStatic() was called.");

        objectToAdd = (string)controller.inkController.story.variablesState["objectToAdd"];

        if (objectToAdd != "" && objectToAdd != null)
        {
            Debug.Log("Inventory.CollectStatic(): Before addition, objectToAdd is " + objectToAdd);

            inventory.Add(objectToAdd);
            objectToAdd = "";

            controller.inkController.story.variablesState["objectToAdd"] = objectToAdd;

            Debug.Log("Inventory.CollectStatic(): After addition, objectToAdd is " + objectToAdd);
        }
        else
        {
            Debug.Log("Inventory.CollectStatic(): objectToAdd was empty or null, so nothing happened.");
        }
    }

    // Removes statics that the player already picked up from the room.
    public void RemoveFoundStaticsFromRoom()
    {
        if (inventory.Count > 0)
        {
            Debug.Log("Inventory/RemoveFoundStaticsFromRoom(): Inventory count was greater than 0 at " + inventory.Count);

            for (int k = 0; k < controller.roomNavigation.currentRoom.statics.Count; k++)
            {
                Debug.Log("Inventory/RemoveFoundStaticsFromRoom(): Assessing static " + controller.roomNavigation.currentRoom.statics[k].staticName + " in room " + controller.roomNavigation.currentRoom.roomName);

                for (int l = 0; l < inventory.Count; l++)
                {
                    Debug.Log("Inventory/RemoveFoundStaticsFromRoom(): Assessing foundStatics entry " + inventory[l] + " with static " + controller.roomNavigation.currentRoom.statics[k].staticName + " in room " + controller.roomNavigation.currentRoom.roomName);

                    if (inventory[l].Contains(controller.roomNavigation.currentRoom.statics[k].staticName))
                    {
                        Debug.Log("Inventory/RemoveFoundStaticsFromRoom(): Removing static " + controller.roomNavigation.currentRoom.statics[k].staticName + " from room " + controller.roomNavigation.currentRoom.roomName + " because the player already found it.");
                        controller.roomNavigation.currentRoom.statics.RemoveAt(k);
                        break;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Inventory.RemoveFoundStaticsFromRoom(): Inventory count was 0, so nothing happens.");
        }
    }
}