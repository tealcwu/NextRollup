using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSTest : MonoBehaviour
{
    public Text OSText;

    // Use this for initialization
    void Start()
    {

#if UNITY_ANDROID
        OSText.text = "OS: Android";
#endif

#if UNITY_IPHONE
        OSText.text = "OS:iPhone";
#endif

#if UNIYT_STANDALONE_WIN
        OSText.text = "OS:PC Win";
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
