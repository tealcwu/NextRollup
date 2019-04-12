using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour {

    Vector3 offset;
    Vector3 mousePosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            // get offset
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = gameObject.transform.position - mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("GetMouseButton triggered.");

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y+offset.y, 0);
        }
	}
}
