using UnityEngine;
using System.Collections;

/** 
* Hack way of getting a Dictionary-styled mapping in the
* Unity inspector.
**/

[System.Serializable]
public struct ObjectByColor
{
    public Color c;
    public GameObject obj;
}
