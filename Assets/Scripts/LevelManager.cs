using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class LevelManager : MonoBehaviour {

    public LevelRoot LevelRoot;

	// Use this for initialization
	void Start () {
        // get levels from Resources/level.xml
        TextAsset textAsset = (TextAsset)Resources.Load("levels");

        if (textAsset == null) { Debug.Log("ERROR: Cannot load levels.xml");return; }

        StreamReader sr = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(textAsset.text)), System.Text.Encoding.UTF8);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(LevelRoot));
        LevelRoot = (LevelRoot)xmlSerializer.Deserialize(sr);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
