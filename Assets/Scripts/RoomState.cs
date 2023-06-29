using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomState
{
    public int roomState; // The current state of the room.
    [TextArea]
    public string roomDescriptionByState; // The room description that accompanies that state.
}