using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScript : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Material[] materials;
    public GameObject trailPrefab;
    GameObject thisTrail;
    Vector3 startPos;
    Plane objPlane;

    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            thisTrail = (GameObject)Instantiate(trailPrefab, this.transform.position, Quaternion.identity);
            thisTrail.GetComponent<TrailRenderer>().material = materials[0];
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                startPos = mRay.GetPoint(rayDistance);
            }
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                thisTrail.transform.position = mRay.GetPoint(rayDistance);
            }
            sprite.gameObject.transform.position = thisTrail.transform.position;
        }
        else if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(thisTrail.transform.position, startPos) < 0.1)
            {
                Destroy(thisTrail);
            }
        }
	}
}
