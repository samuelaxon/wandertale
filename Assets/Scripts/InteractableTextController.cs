using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InteractableTextController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public GameController controller;
    [HideInInspector] public bool hasStory;

    public TMP_FontAsset hoverFont;
    private TMP_FontAsset startingFont;

    private void Awake()
    {
        Debug.Log("InteractableTextController for + " + name + " woke up.");
    }

    // Makes text styling changes to interactable text objects when mouse hovers.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("InteractableTextController/OnPointerEnter() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        startingFont = interactableText.font;

        Debug.Log("InteractableTextController/OnPointerEnter(): Font for " + gameObject + "starts as " + interactableText.font);

        interactableText.font = hoverFont;

        Debug.Log("InteractableTextController/OnPointerEnter(): Font for " + gameObject + "ends as " + interactableText.font);
    }

    // Reverses text styling changes to interactable text objects when mouse stops hovering.
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("InteractableTextController/OnPointerExit() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        Debug.Log("InteractableTextController/OnPointerExit(): Font for " + gameObject + "starts as " + interactableText.font);

        interactableText.font = startingFont;

        Debug.Log("InteractableTextController/OnPointerExit(): Font for " + gameObject + "ends as " + interactableText.font);
    }

    // When an interactable text object is clicked, checks if it is an exit or a story and either calls function to change rooms or calls functions to load a story.
    public void OnPointerClick(PointerEventData eventData)
    {
        // TEMP
        controller.variableTracker.DebugBody();

        Debug.Log("InteractableTextController/OnPointerClick() was called for exit key " + name);

        // SLEUTH: Specific to this project.
        if (CompareTag("Exit Text"))
        {
            controller.variableTracker.priorDangerStage = controller.variableTracker.playerDangerStage; // SLEUTH
            controller.roomNavigation.AttemptToChangeRooms(name); // Attempt to change rooms, passing the name of this object as the key with which to choose a room.
        }
        else if (hasStory == true)
        {
            controller.variableTracker.UpdateDangerLevel("story"); // SLEUTH
            controller.CanvasModeSwitch("story");
            controller.inkController.LoadStory(name);
        }
        else
        {
            Debug.Log("InteractableTextController/OnPointerClick(): This is not an exit or a story, no click action available.");
        }
    }
}