using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName; // A text field for the room builder to define a name for this room.

    [TextArea] // Makes it possible to edit the below in a larger text box in the inspector.
    public string roomDescription; // A text field for the room builder to write a description in to display to the player.

    public List<Exit> exits = new List<Exit>(); // A list for all the exits in the room, editable in the inspector.
    public List<Mob> mobs = new List<Mob>(); // A list for all the mobs in the room, editable in the inspector.
    public List<Static> statics = new List<Static>(); // A list for all the statics in the room, editable in the inspector.
    public List<RoomState> roomStates = new List<RoomState>(); // A list for all the room states in the room, editable in the inspector.
}
