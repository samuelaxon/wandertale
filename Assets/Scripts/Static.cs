using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{
    public string staticName;
    public int staticState;

    public List<Dialogue> staticStories = new List<Dialogue>();

    [TextArea]
    public string staticDescription;
}
