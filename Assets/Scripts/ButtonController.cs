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
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as QuitButton, the application will quit.");
            Application.Quit();
        }
        else if (gameObject.name == "RestartButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Button was clicked and recognized as RestartButton, the scene will reload.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (gameObject.name == "InventoryButton")
        {
            controller.previousCanvasState = controller.canvasState;
            controller.CanvasModeSwitch("inventory");
        }
        else if (gameObject.name == "BackButton")
        {
            Debug.Log("ButtonController.OnPointerClick(): Back button pressed, returning to previousCanvasState " + controller.previousCanvasState);

            controller.CanvasModeSwitch(controller.previousCanvasState);
        }
        else
        {
            Debug.Log("ButtonController.OnPointerClick(): Button click detected, but button name did not match known button.");
        }
    }
}