using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    public GameObject Friend;
    public GameObject Energy;

    public int MaxWidth = 10;
    public int MaxHeight = 5;
    public int MaxEnemy = 5;
    public int MaxFriend = 3;
    public int maxEnerty = 5;

    // private variables
    private List<Vector3> PositionList;
    private int max;
    private bool IsSpaceFull = false;

    private bool IsSpawn = false;
    private float timer = 1f;

    // list of enemy
    // list of aliens
    // list of energy

	// Use this for initialization
	void Start () {
	  // get screen width and height
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
