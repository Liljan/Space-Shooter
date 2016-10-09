using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuToolTip : MonoBehaviour {

    public Text tipTxt;
    public string text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetToolTip()
    {
        tipTxt.text = text;
    }


}
