
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
    public Button quitButton; // The quit button.

    public Canvas roomCanvas; // The UI for the room navigation mode.
    public Canvas storyCanvas; // The UI for the Ink story dialogue mode.
    public Canvas menuCanvas; // The UI for the menu.
    public Canvas endCanvas; // The UI for the kill screen.
    public Canvas craftingCanvas; // The UI for the crafting menu.
    public Canvas inventoryCanvas;
    public Canvas dossierCanvas;
    public GameObject interactablesPanel;
    public GameObject storyChoicePanel;
    public GameObject craftingChoicePanel;

    public float fadeSpeed;

    public string previousCanvasState; // Stores a canvas state to return to later.
    public string canvasState; // The current mode the canvas is in (story, room, etc).
    public bool wasCrafting;
    public int gameHasStarted = 0; // Has the game started? 0 for no, 1 for yes.

    [HideInInspector] public RoomNavigation roomNavigation; // A reference to roomNavigation for knowing which room we're in.
    [HideInInspector] public InkController inkController; // A reference to inkController so various scripts can communicate and work with Ink stories.
    [HideInInspector] public VariableTracker variableTracker; // A reference to variable tracker so various scripts can access, use, and define the variables.
    // [HideInInspector] public SFXController sfxController; // A reference to the script that plays and stops sound effects and music. Disabled for SLEUTH.
    [HideInInspector] public Inventory inventory;
    [HideInInspector] public Dossier dossier;
    [HideInInspector] public Crafting crafting;

    List<string> roomLog = new List<string>(); // Creates a List of strings called room log that will go to the text field.

    // Called when the script is activated.
    private void Awake()
    {
        Debug.Log("GameController.Awake() was called.");
        roomNavigation = GetComponent<RoomNavigation>();
        inkController = GetComponent<InkController>();
        variableTracker = GetComponent<VariableTracker>();
        // sfxController = GetComponent<SFXController>();
        inventory = GetComponent<Inventory>();
        dossier = GetComponent<Dossier>();
        crafting = GetComponent<Crafting>();
    }

    private void Update()
    {
        // Intended to start the game when the player clicks start or equivalent in the main menu.
        if (gameHasStarted == 0)
        {
            if (Input.anyKey)
            {
                Debug.Log("GameController.Update(): A key or mouse click has been detected.");
                gameHasStarted = 1;

                // Enable if we start with a story, not the room view.
                CanvasModeSwitch("story");
                inkController.LoadStory("Mnemosyne0");


                /* Enable if we start with crafting, not the room or story view, for testing only. 555
                CanvasModeSwitch("crafting");
                inkController.LoadStory("StartGame");*/

                /* Enable if we start with a room, not the story view.
                sfxController.PlaySFX();
                CanvasModeSwitch("room");
                */
            }
        }

        /* Ends the game if a story calls for it. Disabled temporarily because we moved it to InkController.
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
        Debug.Log("GameController.CanvasModeSwitch() was called.");
        if (canvasMode == "story")
        {
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as story.");
            canvasState = "story";

            storyCanvas.gameObject.SetActive(true);
            roomCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(false);
            craftingCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);
        }
        else if (canvasMode == "room")
        {
            canvasState = "room";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as room.");

            roomCanvas.gameObject.SetActive(true);
            storyCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(false);
            craftingCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);

            // Tells buttons about the controller when they become active at this point.
            quitButton.GetComponent<ButtonController>().controller = this;

            ChangeRoom();
        }
        else if (canvasMode == "menu")
        {
            canvasState = "menu";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as menu.");

            menuCanvas.gameObject.SetActive(true);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
            craftingCanvas.gameObject.SetActive(false);
            inventoryCanvas.gameObject.SetActive(false);
            dossierCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);
        }
        else if (canvasMode == "crafting")
        {
            canvasState = "crafting";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as crafting.");

            craftingCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
            inventoryCanvas.gameObject.SetActive(false);
            dossierCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);

            if (wasCrafting == true)
            {
                Debug.Log("GameController.CanvasModeSwitch: wasCrafting's value is " + wasCrafting + " so loading lastActiveStage.");

                crafting.RefreshCraftingUI(crafting.lastActiveStage);
            }
            else
            {
                Debug.Log("GameController.CanvasModeSwitch: wasCrafting's value is " + wasCrafting + " so loading pickRecipient.");

                crafting.RefreshCraftingUI(crafting.pickRecipient);
            }

            wasCrafting = false;
        }
        else if (canvasMode == "inventory")
        {
            canvasState = "inventory";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as inventory.");

            inventoryCanvas.gameObject.SetActive(true);
            craftingCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(false);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
            dossierCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);

            inventory.UnpackInventory();
        }
        else if (canvasMode == "dossier")
        {
            canvasState = "dossier";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as dossier.");

            dossierCanvas.gameObject.SetActive(true);
            craftingCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(false);
            roomCanvas.gameObject.SetActive(false);
            storyCanvas.gameObject.SetActive(false);
            inventoryCanvas.gameObject.SetActive(false);
            endCanvas.gameObject.SetActive(false);

            dossier.UpdateDossier();
        }
        else if (canvasMode == "end")
        {
            canvasState = "end";
            Debug.Log("GameController.CanvasModeSwitch: The canvas mode parameter was recognized as end.");

            endCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            roomCanvas.gameObject.SetActive(false);
            craftingCanvas.gameObject.SetActive(false);
            inventoryCanvas.gameObject.SetActive(false);
            dossierCanvas.gameObject.SetActive(false);
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
        Debug.Log("GameController.ChangeRoom() was called.");

        roomLog.Clear();
        roomNavigation.mobOrStaticStoryDictionary.Clear(); // Added while testing new object refactor.
        roomNavigation.exitDictionary.Clear(); // Added while testing new object refactor.

        foreach (Transform child in interactablesPanel.transform)
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
        Debug.Log("GameController.UpdateRoomText() was called.");
        ClearCollectionsForNewRoom();
        Debug.Log("GameController.UpdateRoomText: The current room name is " + roomNavigation.currentRoom.name);
 
        string combinedRoomText = roomNavigation.currentRoom.roomDescription + "\n";

        RoomLogReturn(combinedRoomText);
    }

    // Sets the text field's text value to match what was in our room log.
    public void DisplayLoggedText()
    {
        Debug.Log("GameController.DisplayLoggedText() was called.");

        string logRoomAsText = string.Join("\n", roomLog.ToArray());

        roomText.text = logRoomAsText;
    }

    // Calls the UnpackExitsInRoom and UnpackMobsInRoom functions in RoomNavigation, which sends descriptions to this script.
    void UnpackInteractables()
    {
        Debug.Log("GameController.UnpackInteractables() was called.");
        roomNavigation.UnpackExitsInRoom();
        roomNavigation.UnpackMobsInRoom();
        roomNavigation.UnpackStaticsInRoom();
        // StartInteractablesFade();
    }

    // Clears everything from a room so we can go to a new one.
    void ClearCollectionsForNewRoom()
    {
        Debug.Log("GameController.ClearCollectionsForNewRoom() was called.");
        roomNavigation.ClearExits();
    }

    // Adds whatever string you give it to the room log, to later be displayed in the text field by UpdateRoomText.
    public void RoomLogReturn(string roomDescriptionToAdd)
    {
        Debug.Log("GameController.RoomLogReturn() was called.");
        roomLog.Add(roomDescriptionToAdd + "\n");
    }

    public void StartInteractablesFade()
    {
        Debug.Log("GameController.StartInteractablesFade() was called.");

        if (canvasState == "room")
        {
            if (interactablesPanel.transform.childCount > 0)
            {
                Debug.Log("GameController.StartInteractablesFade(): interactablesPanel had a childCount greater than 0.");

                foreach (Transform child in interactablesPanel.transform)
                {
                    Debug.Log("GameController.StartInteractablesFade(): Addressing text component on object " + child.name);

                    StartCoroutine(FadeInText(child));
                }
            }
            else
            {
                Debug.Log("RoomNavigation.StartInteractablesFade(): interactablesPanel had a childCount of 0.");
            }
        }
        else if (canvasState == "story")
        {
            if (storyChoicePanel.transform.childCount > 0)
            {
                Debug.Log("GameController.StartInteractablesFade(): storyChoicePanel had a childCount greater than 0.");

                foreach (Transform child in storyChoicePanel.transform)
                {
                    Debug.Log("GameController.StartInteractablesFade(): Addressing text component on object " + child.name);

                    if (child.transform.childCount > 0)
                    {
                        Debug.Log("GameController.StartInteractablesFade(): " + child + " had a childCount greater than 0.");

                        foreach (Transform textChild in child.transform)
                        {
                            Debug.Log("GameController.StartInteractablesFade(): Addressing text component on object " + textChild.name);

                            StartCoroutine(FadeInText(textChild));
                        }
                    }
                }
            }
            else
            {
                Debug.Log("GameController.StartInteractablesFade(): storyChoicePanel had a childCount of 0.");
            }
        }
        else if (canvasState == "crafting")
        {
            if (craftingChoicePanel.transform.childCount > 0)
            {
                Debug.Log("GameController.StartInteractablesFade(): craftingChoicePanel had a childCount greater than 0.");

                foreach (Transform child in craftingChoicePanel.transform)
                {
                    Debug.Log("RoomNavigation.StartInteractablesFade(): Addressing text component on object " + child.name);

                    StartCoroutine(FadeInButton(child));

                    if (child.transform.childCount > 0)
                    {
                        Debug.Log("GameController.StartInteractablesFade(): " + child + " had a childCount greater than 0.");

                        foreach (Transform textChild in child.transform)
                        {
                            Debug.Log("GameController.StartInteractablesFade(): Addressing text component on object " + textChild.name);

                            StartCoroutine(FadeInText(textChild));
                        }
                    }
                }
            }
            else
            {
                Debug.Log("RoomNavigation.StartInteractablesFade(): craftingChoicePanel had a childCount of 0.");
            }
        }
    }

    private IEnumerator FadeInText(Transform textToFade)
    {
        Debug.Log("GameController.FadeInText() coroutine started.");
        Debug.Log("GameController.FadeInText(): textToFade is " + textToFade + " and gameObject + " + textToFade.gameObject + " with gameObject name + " + textToFade.gameObject.name);
        Debug.Log("GameController.FadeInText(): Alpha value is " + textToFade.gameObject.GetComponent<TMP_Text>().color.a);
        Debug.Log("GameController.FadeInText(): Text value is " + textToFade.gameObject.GetComponent<TMP_Text>().text);

        while (textToFade.gameObject.GetComponent<TMP_Text>().color.a < 255)
        {
            Color objectColor = textToFade.gameObject.GetComponent<TMP_Text>().color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            textToFade.gameObject.GetComponent<TMP_Text>().color = objectColor;

            yield return null;
        }
    }

    private IEnumerator FadeInButton(Transform imageToFade)
    {
        Debug.Log("GameController.FadeInButton() coroutine started.");
        Debug.Log("GameController.FadeInButton(): textToFade is " + imageToFade + " and gameObject + " + imageToFade.gameObject + " with gameObject name + " + imageToFade.gameObject.name);
        Debug.Log("GameController.FadeInButton(): Alpha value is " + imageToFade.gameObject.GetComponent<Image>().color.a);

        while (imageToFade.gameObject.GetComponent<Image>().color.a < 255)
        {
            Color objectColor = imageToFade.gameObject.GetComponent<Image>().color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            imageToFade.gameObject.GetComponent<Image>().color = objectColor;

            yield return null;
        }
    }

    public void StopFade()
    {
        Debug.Log("GameController.StopFade() was called.");

        StopAllCoroutines();
    }
}