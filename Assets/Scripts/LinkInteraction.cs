using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LinkInteraction : MonoBehaviour, IPointerClickHandler
{
    public GameController controller;

    void Awake ()
    {
        Debug.Log("LinkInteraction woke up.");
    }

    // Called when the user clicks anywhere.
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick (LinkInteraction) was called.");

        // Determines if there is an intersecting link where the play clicked.
        TMP_Text pTextMeshPro = GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);

        // If there is a link with an index.
        if (linkIndex != -1)
        {
            Debug.Log("A link was recognized in OnPointerClick (LinkInteraction).");

            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            string linkID = linkInfo.GetLinkID();

            // If the ID says it's an exit...
            if (linkID.Contains("exit") == true)
            {
                Debug.Log("The link is recognized as an exit by OnPointerClick (LinkInteraction).");

                controller.roomNavigation.AttemptToChangeRooms(linkInfo.GetLinkText()); // Attempt to change rooms, passing link text as the key for the exit dictionary.
            }
            // If there is no recognized link ID present, do this.
            else
            {
                Debug.Log("No valid link found by OnPointerClick (LinkInteraction).");
            }
        }
    }
}