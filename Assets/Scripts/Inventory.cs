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
    public List<Static> allReagents = new List<Static>();

    private void Awake()
    {
        controller = GetComponent<GameController>(); // Allows this script to access things from the GameController.
    }

    public void UnpackInventory()
    {
        RemoveGiftedStatics();

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
                    
                    for (int r = 0; r < allReagents.Count; r++)
                    {
                        if (allReagents[r].staticName == inventory[i])
                        {
                            if (allReagents[r].reagentType == "color")
                            {
                                newText = newText + " - " + allReagents[r].reagentType + ": " + allReagents[r].colorProperty + " (" + allReagents[r].colorCategory + ")";
                            }
                            else if (allReagents[r].reagentType == "material")
                            {
                                newText = newText + " - " + allReagents[r].reagentType + ": " + allReagents[r].materialProperty + " (" + allReagents[r].materialCategory + ")";
                            }
                            else if (allReagents[r].reagentType == "vessel")
                            {
                                newText = newText + " - " + allReagents[r].reagentType + ": " + allReagents[r].vesselProperty + " (" + allReagents[r].vesselCategory + ")";
                            }
                        }
                    }

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

    public void CollectStaticFromCrafting()
    {
        Debug.Log("Inventory.CollectStatic() was called.");

        if (objectToAdd != "" && objectToAdd != null)
        {
            Debug.Log("Inventory.CollectStatic(): Before addition, objectToAdd is " + objectToAdd);

            inventory.Add(objectToAdd);
            objectToAdd = "";

            Debug.Log("Inventory.CollectStatic(): After addition, objectToAdd is " + objectToAdd);
        }
        else
        {
            Debug.Log("Inventory.CollectStatic(): objectToAdd was empty or null, so nothing happened.");
        }
    }

    private void RemoveGiftedStatics()
    {
        Debug.Log("Inventory.RemoveGiftedStatics() was called.");

        if (controller.dossier.gloria.mobState == 5)
        {
            Debug.Log("Inventory.RemoveGiftedStatics(): Gloria's mobState is 5, so a gift has been given. Removing Gloria's gift from inventory.");

            for (int g = 0; g < inventory.Count; g++)
            {
                Debug.Log("Inventory.RemoveGiftedStatics(): Addressing inventory item " + inventory[g]);

                if (inventory[g] == controller.crafting.giftForGloria + " (for " + "gloria)")
                {
                    Debug.Log("Inventory.RemoveGiftedStatics(): giftForJulian named " + controller.crafting.giftForGloria + " matched inventory item " + inventory[g] + ". Removing item from inventory.");

                    inventory.RemoveAt(g);
                }
            }
        }

        if (controller.dossier.julian.mobState == 5)
        {
            Debug.Log("Inventory.RemoveGiftedStatics(): Julian's mobState is 5, so a gift has been given. Removing Julian's gift from inventory.");

            for (int g = 0; g < inventory.Count; g++)
            {
                if (inventory[g] == controller.crafting.giftForJulian + " (for " + "julian)")
                {
                    Debug.Log("Inventory.RemoveGiftedStatics(): giftForJulian named " + controller.crafting.giftForJulian + " matched inventory item " + inventory[g] + ". Removing item from inventory.");

                    inventory.RemoveAt(g);
                }
            }
        }

        if (controller.dossier.li.mobState == 5)
        {
            Debug.Log("Inventory.RemoveGiftedStatics(): Li's mobState is 5, so a gift has been given. Removing Li's gift from inventory.");

            for (int g = 0; g < inventory.Count; g++)
            {
                if (inventory[g] == controller.crafting.giftForLi + " (for " + "li)")
                {
                    Debug.Log("Inventory.RemoveGiftedStatics(): giftForLi named " + controller.crafting.giftForLi + " matched inventory item " + inventory[g] + ". Removing item from inventory.");

                    inventory.RemoveAt(g);
                }
            }
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