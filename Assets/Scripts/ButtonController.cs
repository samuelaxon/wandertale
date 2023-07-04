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
        if (gameObject.name == "QuitButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as QuitButton, quitting application.");
            Application.Quit();
        }
        else if (gameObject.name == "RestartButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as RestartButton, reloading scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (gameObject.name == "InventoryButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as InventoryButton, loading inventory canvas.");
            controller.previousCanvasState = controller.canvasState;
            controller.CanvasModeSwitch("inventory");
        }
        else if (gameObject.name == "BackButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as BackButton, returning to previousCanvasState " + controller.previousCanvasState);

            controller.CanvasModeSwitch(controller.previousCanvasState);
        }
        else
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and button name was unknown.");
        }
    }
}