using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text txtTimer;
    private float nextTime = 1;
    private float seconds = 10f;

    private float beginTime = 0;

    private void Timer()
    {
        if (nextTime <= Time.time)
        {
            seconds--;
            txtTimer.text = string.Format("{0:d2}:{1:d2}", seconds / 60, seconds % 60);
            nextTime = Time.time + 1;
            if (seconds <= 0) this.enabled = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        float time = 5;
        StartCoroutine(Timer(time));
    }

    // Update is called once per frame
    void Update()
    {
        // Timer();
        // txtTimer.text = Time.fixedDeltaTime.ToString();

        string timeString = string.Format("deltaTime:{0}\r\nfixedDeltaTime:{1}\r\nfixedUnscaledDeltaTime:{2}\r\nfixedUnscaledTime:{3}\r\nframeCount:{4}\r\nTime.time:{5}\r\nsmoothDeltaTime:{6}", Time.deltaTime.ToString(), Time.fixedDeltaTime.ToString(), Time.fixedUnscaledDeltaTime.ToString(), Time.fixedUnscaledTime.ToString(), Time.frameCount, Time.time, Time.smoothDeltaTime);
        txtTimer.text = timeString;

        beginTime += Time.deltaTime;
        seconds -= Time.deltaTime;

        txtTimer.text = seconds.ToString();

    }

    public IEnumerator Timer(float time)
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);

            print(time);
            time--;
        }
    }
}
