using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    private DrawScript draw;
    [SerializeField]
    private int myColor;

	// Use this for initialization
	void Start () {
        draw = FindObjectOfType<DrawScript>();
	}
	
	public void ActivateChange()
    {
        draw.ChangeColor(myColor);
    }
}
