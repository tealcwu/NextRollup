using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioControl : MonoBehaviour {

    private AudioSource friendAudio;

	// Use this for initialization
	void Start () {
        friendAudio = GameObject.Find("FriendAudio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
