using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNow : MonoBehaviour
{
    private bool isTiming;
    private float countDown;

    // Update is called once per frame
    void Update()
    {
        Input.backButtonLeavesApp = true;
    }

    private void exitDetection()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (countDown == 0)
            {
                countDown = Time.time;
                isTiming = true;
            }
            else
            {
                Application.Quit();
            }
        }

        if (isTiming)
        {
            if ((Time.time - countDown) > 2.0)
            {
                countDown = 0;
                isTiming = false;
            }
        }
    }
}