using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{
    public string staticName;
    public int staticState;
    public string reagentType;
    public string colorProperty;
    public string colorCategory;
    public string materialProperty;
    public string materialCategory;
    public string vesselProperty;
    public string vesselCategory;

    public List<Dialogue> staticStories = new List<Dialogue>();

    [TextArea]
    public string staticDescription;
}
