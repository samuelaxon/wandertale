using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public GameController controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "MapButton")
        {
            Debug.Log("ButtonController/OnPointerClick(): Button was clicked as recognized as MapButton, enabling map.");

            if (controller.variableTracker.playerVisitedHiddenHallway == 1)
            {
                Debug.Log("ButtonController/OnPointerClick(): Player has found key, so enabling fully revealed map.");
                controller.variableTracker.mapUnlocked.SetActive(true);
            }
            else
            {
                Debug.Log("ButtonController/OnPointerClick(): Player has not found key, so enabling partially obscured map.");
                controller.variableTracker.mapLocked.SetActive(true);
            }
        }
        else if (gameObject.name == "QuitButton")
        {
            Debug.Log("QuitButton/OnPointerClick(): Button was clicked and recognized as QuitButton, the application will quit.");
            Application.Quit();
        }
        else if (gameObject.name == "RestartButton")
        {
            Debug.Log("QuitButton/OnPointerClick(): Button was clicked and recognized as RestartButton, the scene will reload.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (gameObject.name == "HelpButton")
        {
            Debug.Log("QuitButton/OnPointerClick(): Button was clicked and recognized as HelpButton, loading instructions story.");
            controller.CanvasModeSwitch("story");
            controller.inkController.LoadStory("Help");
        }
        else if (gameObject.name == "AccuseButton")
        {
            Debug.Log("QuitButton/OnPointerClick(): Button was clicked and recognized as AccuseButton, loading accuse story.");
            controller.CanvasModeSwitch("story");
            controller.inkController.LoadStory("EndGameAccuse");
        }
        else
        {
            Debug.Log("QuitButton/OnPointerClick(): Button click detected, but button name did not match known button.");
        }
    }
}