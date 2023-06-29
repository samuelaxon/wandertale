using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Exit
{
    public string name; // The keyword to use a specific exit.
    public string exitDescriptionOpen; // The description of the exit visible to the player and configurable by the content creator when the exit is open.
    public string exitDescriptionClosed; //  The description of the exit visible to the player and configurable by the content creator when the exit is closed.
    public bool exitIsClosed;

    public Room valueRoom;
}