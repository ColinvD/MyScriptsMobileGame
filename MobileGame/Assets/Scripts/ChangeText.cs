using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public Text coordinates;
    public GPS gps;

    void Start()
    {
        gps = this.gameObject.AddComponent<GPS>();
    }
    private void Update()
    {
        coordinates.text = "Lat: " + (float)gps.latitude + "  Lon: " + (float)gps.longitude;
    }
}
