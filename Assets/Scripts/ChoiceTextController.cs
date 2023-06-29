using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ChoiceTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public GameController controller;

    private void Awake()
    {
        Debug.Log("ChoiceTextController for + " + name + " woke up.");
        controller = GetComponent<GameController>();
    }

    // Makes text styling changes to interactable text objects when mouse hovers.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ChoiceTextController/OnPointerEnter() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        Debug.Log("ChoiceTextController/OnPointerEnter(): FontStyle for " + gameObject + "starts as " + interactableText.fontStyle);

        interactableText.fontStyle = FontStyles.Bold;

        Debug.Log("ChoiceTextController/OnPointerEnter(): FontStyle for " + gameObject + "ends as " + interactableText.fontStyle);
    }

    // Reverses text styling changes to interactable text objects when mouse stops hovering.
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("ChoiceTextController/OnPointerExit() was called for " + gameObject);

        TMP_Text interactableText = gameObject.GetComponent<TMP_Text>();

        Debug.Log("ChoiceTextController/OnPointerExit(): FontStyle for " + gameObject + "starts as " + interactableText.fontStyle);

        interactableText.fontStyle = FontStyles.Normal;

        Debug.Log("InteractableTextController/OnPointerExit(): FontStyle for " + gameObject + "ends as " + interactableText.fontStyle);
    }
}