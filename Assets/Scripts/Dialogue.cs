using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue
{
    // public int keyInt; // The keyword to use a specific exit. Disabled this because I'm not even sure we're actually using it?

    public TextAsset valueStory; // The room the exit points to, configurable by the content creator.

    public Room roomAssignment;
    [TextArea]
    public string dialogueDescription; // The description of the exit visible to the player and configurable by the content creator.
}