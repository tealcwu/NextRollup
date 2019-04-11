using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonTypes
{
    SFX, BGM, PAUSE
}


public class AudioControl : MonoBehaviour {

    public ButtonTypes ButtonType;
    bool isStatusOn = true;

    private Image currentImage;
    private Sprite statusOnImage;
    private Sprite statusOffImage;

    private string sfxonStr = "Images/sfxon";
    private string sfxoffStr = "Images/sfxoff";
    private string bgmonStr = "Images/bgmon";
    private string bgmoffStr = "Images/bgmoff";
    private string pauseStr = "Images/pause";
    private string resumeStr = "Images/resume";

    private string statusOnStr;
    private string statusOffStr;

    // Use this for initialization
    void Start()
    {
        switch(ButtonType)
        {
            case ButtonTypes.SFX:
                statusOnStr = sfxonStr;
                statusOffStr = sfxoffStr;
                break;
            case ButtonTypes.BGM:
                statusOnStr = bgmonStr;
                statusOffStr = bgmoffStr;
                break;
            case ButtonTypes.PAUSE:
                statusOnStr = pauseStr;
                statusOffStr = resumeStr;
                break;
        }

        gameObject.GetComponent<Button>().onClick.AddListener(delegate() { ChangeStatus(); });
        currentImage = gameObject.GetComponent<Image>();

        statusOnImage = Resources.Load(statusOnStr, typeof(Sprite)) as Sprite;
        statusOffImage = Resources.Load(statusOffStr, typeof(Sprite)) as Sprite;
    }
	
	// Update is called once per frame
	void ChangeStatus () {
		if(isStatusOn)
        {
            isStatusOn = false;
            currentImage.sprite = statusOffImage;
        }
        else
        {
            isStatusOn = true;
            currentImage.sprite = statusOnImage;
        }
	}
}
