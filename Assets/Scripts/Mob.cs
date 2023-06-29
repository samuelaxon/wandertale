using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mob : MonoBehaviour
{
    public string mobName;
    public int mobState;
    public int isMurderer = 0; // Same as above, but for the murderer if this is an NPC.
    public int isVictim = 0; // Same as above, but victim.
    public int gender = 2; // The gender of this mob. 0 for female, 1 for male, 2 for nonbinary.

    public List<Dialogue> mobStories = new List<Dialogue>();

    [TextArea]
    public string mobDescription;

    [HideInInspector]
    public string alibi;
}