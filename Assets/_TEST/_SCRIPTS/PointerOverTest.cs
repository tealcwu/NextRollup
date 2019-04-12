using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerOverTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hitInfo;

            //if(Physics.Raycast(ray, out hitInfo))
            //{
                if(EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("the UI");
                }
                else
                {
                    Debug.Log("not on UI");
                    //hitInfo.collider.GetComponent<Renderer>().material.color = Color.red;
                }
            //}
        }
	}
}
