using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Ink.Runtime;

public class InteractableTextController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public GameController controller;
    [HideInInspector] public bool hasStory;

    private void Awake()
    {
        Debug.Log("InteractableTextController for + " + name + " woke up.");
        controller = GetComponent<GameController>(); // Allows this script to access things from the GameController.
    }

    // Makes text styling changes to interactable text objects when mouse hovers.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("InteractableTextController/OnPointerEnter() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        Debug.Log("InteractableTextController/OnPointerEnter(): FontStyle for " + gameObject + "starts as " + interactableText.fontStyle);

        interactableText.fontStyle = FontStyles.Bold;

        Debug.Log("InteractableTextController/OnPointerEnter(): FontStyle for " + gameObject + "ends as " + interactableText.fontStyle);
    }

    // Reverses text styling changes to interactable text objects when mouse stops hovering.
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("InteractableTextController/OnPointerExit() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        Debug.Log("InteractableTextController/OnPointerExit(): FontStyle for " + gameObject + "starts as " + interactableText.fontStyle);

        interactableText.fontStyle = FontStyles.Normal;

        Debug.Log("InteractableTextController/OnPointerExit(): FontStyle for " + gameObject + "ends as " + interactableText.fontStyle);
    }

    // When an interactable text object is clicked, checks if it is an exit or a story and either calls function to change rooms or calls functions to load a story.
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("InteractableTextController/OnPointerClick() was called for exit key " + name);

        if (CompareTag("Exit Text"))
        {
            controller.roomNavigation.AttemptToChangeRooms(name); // Attempt to change rooms, passing the name of this object as the key with which to choose a room.
        }
        else if (hasStory == true)
        {
            controller.CanvasModeSwitch("story");
            controller.inkController.LoadStory(name);
        }
        else
        {
            Debug.Log("InteractableTextController/OnPointerClick(): This is not an exit or a story, no click action available.");
        }
    }
}