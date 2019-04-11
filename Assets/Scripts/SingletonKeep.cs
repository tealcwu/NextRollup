using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonKeep : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
