using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mob : MonoBehaviour
{
    public string mobName;
    public int mobState;

    public List<Dialogue> mobStories = new List<Dialogue>();

    [TextArea]
    public string mobDescription;
}